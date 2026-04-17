using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace RoundRobin
{
    [Serializable]
    public class TournamentData
    {
        public List<PlayerData> Players { get; set; }
        public List<MatchData> Matches { get; set; }
        public int TotalRounds { get; set; }
    }

    [Serializable]
    public class PlayerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public int Abandonments { get; set; }
        public int MatchesPlayed { get; set; }
    }

    [Serializable]
    public class MatchData
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public MatchResult Result { get; set; }
    }

    public class TournamentManager
    {
        public List<Player> Players { get; private set; }
        public List<Match> Matches { get; private set; }
        public int TotalRounds { get; private set; }

        private const string SaveFileName = "tournament_save.xml";

        public TournamentManager()
        {
            Players = new List<Player>();
            Matches = new List<Match>();
            TotalRounds = 0;
        }

        public void AddPlayer(string name)
        {
            int id = Players.Count + 1;
            Players.Add(new Player(id, name));
        }

        public void GenerateMatches()
        {
            Matches.Clear();
            int matchId = 1;

            if (Players.Count < 2)
                return;

            // Algorithme Round-Robin avec rotation
            List<Player> players = new List<Player>(Players);
            
            // Si nombre impair de joueurs, ajouter un "bye" (joueur fantôme)
            Player byePlayer = null;
            if (players.Count % 2 != 0)
            {
                byePlayer = new Player(0, "BYE");
                players.Add(byePlayer);
            }

            int numPlayers = players.Count;
            int numRounds = numPlayers - 1;
            TotalRounds = numRounds;

            // Génération des matchs par tour
            for (int round = 0; round < numRounds; round++)
            {
                for (int match = 0; match < numPlayers / 2; match++)
                {
                    Player player1 = players[match];
                    Player player2 = players[numPlayers - 1 - match];

                    // Ne pas créer de match avec le joueur BYE
                    if (player1 != byePlayer && player2 != byePlayer)
                    {
                        Matches.Add(new Match(matchId++, round + 1, player1, player2));
                    }
                }

                // Rotation des joueurs (le premier reste fixe)
                players.Insert(1, players[numPlayers - 1]);
                players.RemoveAt(numPlayers);
            }
        }

        public List<Match> GetMatchesByRound(int round)
        {
            return Matches.Where(m => m.Round == round).ToList();
        }

        public Player GetRestingPlayerForRound(int round)
        {
            // Trouver tous les joueurs qui jouent dans ce tour
            var matchesInRound = GetMatchesByRound(round);
            var playingPlayerIds = new HashSet<int>();

            foreach (var match in matchesInRound)
            {
                playingPlayerIds.Add(match.Player1.Id);
                playingPlayerIds.Add(match.Player2.Id);
            }

            // Trouver le joueur qui ne joue pas (s'il existe)
            return Players.FirstOrDefault(p => !playingPlayerIds.Contains(p.Id));
        }

        public void RecordMatchResult(Match match, MatchResult result)
        {
            if (match.IsPlayed())
            {
                // Annuler les points précédents
                UndoMatchPoints(match);
            }

            match.Result = result;

            // Appliquer les nouveaux points
            ApplyMatchPoints(match);
        }

        public int ApplyAbandonToRemainingMatches(Player player, int currentRound)
        {
            int abandonedMatchesCount = 0;

            // Trouver tous les matchs non joués du joueur dans les tours suivants
            var remainingMatches = Matches.Where(m => 
                !m.IsPlayed() && 
                m.Round > currentRound && 
                (m.Player1.Id == player.Id || m.Player2.Id == player.Id)).ToList();

            foreach (var match in remainingMatches)
            {
                MatchResult result;
                
                if (match.Player1.Id == player.Id)
                {
                    result = MatchResult.Player1Abandoned;
                }
                else
                {
                    result = MatchResult.Player2Abandoned;
                }

                RecordMatchResult(match, result);
                abandonedMatchesCount++;
            }

            return abandonedMatchesCount;
        }

        private void UndoMatchPoints(Match match)
        {
            switch (match.Result)
            {
                case MatchResult.Player1Won:
                    match.Player1.Points -= 2;
                    match.Player1.Victories--;
                    match.Player2.Points -= 1;
                    match.Player2.Defeats--;
                    match.Player1.MatchesPlayed--;
                    match.Player2.MatchesPlayed--;
                    break;
                case MatchResult.Player2Won:
                    match.Player2.Points -= 2;
                    match.Player2.Victories--;
                    match.Player1.Points -= 1;
                    match.Player1.Defeats--;
                    match.Player1.MatchesPlayed--;
                    match.Player2.MatchesPlayed--;
                    break;
                case MatchResult.Player1Abandoned:
                    match.Player2.Points -= 2;
                    match.Player2.Victories--;
                    match.Player1.Abandonments--;
                    match.Player1.MatchesPlayed--;
                    match.Player2.MatchesPlayed--;
                    break;
                case MatchResult.Player2Abandoned:
                    match.Player1.Points -= 2;
                    match.Player1.Victories--;
                    match.Player2.Abandonments--;
                    match.Player1.MatchesPlayed--;
                    match.Player2.MatchesPlayed--;
                    break;
            }
        }

        private void ApplyMatchPoints(Match match)
        {
            switch (match.Result)
            {
                case MatchResult.Player1Won:
                    match.Player1.Points += 2;
                    match.Player1.Victories++;
                    match.Player2.Points += 1;
                    match.Player2.Defeats++;
                    match.Player1.MatchesPlayed++;
                    match.Player2.MatchesPlayed++;
                    break;
                case MatchResult.Player2Won:
                    match.Player2.Points += 2;
                    match.Player2.Victories++;
                    match.Player1.Points += 1;
                    match.Player1.Defeats++;
                    match.Player1.MatchesPlayed++;
                    match.Player2.MatchesPlayed++;
                    break;
                case MatchResult.Player1Abandoned:
                    match.Player2.Points += 2;
                    match.Player2.Victories++;
                    match.Player1.Abandonments++;
                    match.Player1.MatchesPlayed++;
                    match.Player2.MatchesPlayed++;
                    break;
                case MatchResult.Player2Abandoned:
                    match.Player1.Points += 2;
                    match.Player1.Victories++;
                    match.Player2.Abandonments++;
                    match.Player1.MatchesPlayed++;
                    match.Player2.MatchesPlayed++;
                    break;
            }
        }

        public List<Player> GetRankings()
        {
            // Réinitialiser l'indicateur pour tous les joueurs
            foreach (var player in Players)
            {
                player.RankedByHeadToHead = false;
            }
            
            // Trier d'abord par points, puis par confrontation directe
            var sortedPlayers = Players.OrderByDescending(p => p.Points).ToList();
            
            // Appliquer le départage par confrontation directe pour les joueurs à égalité
            var finalRankings = new List<Player>();
            var tiedPlayers = new List<Player>();
            int? currentPoints = null;
            
            foreach (var player in sortedPlayers)
            {
                if (currentPoints.HasValue && player.Points == currentPoints.Value)
                {
                    // Joueur à égalité avec le(s) précédent(s)
                    tiedPlayers.Add(player);
                }
                else
                {
                    // Départager les joueurs à égalité précédents s'il y en a
                    if (tiedPlayers.Count > 1)
                    {
                        finalRankings.AddRange(ResolveHeadToHead(tiedPlayers));
                    }
                    else if (tiedPlayers.Count == 1)
                    {
                        finalRankings.Add(tiedPlayers[0]);
                    }
                    
                    // Commencer un nouveau groupe à égalité
                    tiedPlayers.Clear();
                    tiedPlayers.Add(player);
                    currentPoints = player.Points;
                }
            }
            
            // Départager le dernier groupe à égalité
            if (tiedPlayers.Count > 1)
            {
                finalRankings.AddRange(ResolveHeadToHead(tiedPlayers));
            }
            else if (tiedPlayers.Count == 1)
            {
                finalRankings.Add(tiedPlayers[0]);
            }
            
            return finalRankings;
        }

        private List<Player> ResolveHeadToHead(List<Player> tiedPlayers)
        {
            // Créer une liste avec le score de confrontation directe pour chaque joueur
            var headToHeadScores = new Dictionary<Player, int>();
            
            foreach (var player in tiedPlayers)
            {
                headToHeadScores[player] = 0;
            }
            
            // Calculer les points de confrontation directe entre joueurs à égalité
            foreach (var match in Matches.Where(m => m.IsPlayed()))
            {
                bool player1InGroup = tiedPlayers.Contains(match.Player1);
                bool player2InGroup = tiedPlayers.Contains(match.Player2);
                
                // Le match compte seulement si les deux joueurs sont dans le groupe à égalité
                if (player1InGroup && player2InGroup)
                {
                    if (match.Result == MatchResult.Player1Won)
                    {
                        headToHeadScores[match.Player1] += 2;
                        headToHeadScores[match.Player2] += 1;
                    }
                    else if (match.Result == MatchResult.Player2Won)
                    {
                        headToHeadScores[match.Player2] += 2;
                        headToHeadScores[match.Player1] += 1;
                    }
                    else if (match.Result == MatchResult.Player1Abandoned)
                    {
                        headToHeadScores[match.Player2] += 2;
                    }
                    else if (match.Result == MatchResult.Player2Abandoned)
                    {
                        headToHeadScores[match.Player1] += 2;
                    }
                }
            }
            
            // Marquer tous les joueurs comme départagés par confrontation directe
            foreach (var player in tiedPlayers)
            {
                player.RankedByHeadToHead = true;
            }
            
            // Trier par confrontation directe, puis par victoires, puis par nom
            return tiedPlayers.OrderByDescending(p => headToHeadScores[p])
                              .ThenByDescending(p => p.Victories)
                              .ThenBy(p => p.Name)
                              .ToList();
        }

        public void SaveToFile()
        {
            try
            {
                var data = new TournamentData
                {
                    Players = Players.Select(p => new PlayerData
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Points = p.Points,
                        Victories = p.Victories,
                        Defeats = p.Defeats,
                        Abandonments = p.Abandonments,
                        MatchesPlayed = p.MatchesPlayed
                    }).ToList(),
                    Matches = Matches.Select(m => new MatchData
                    {
                        Id = m.Id,
                        Round = m.Round,
                        Player1Id = m.Player1.Id,
                        Player2Id = m.Player2.Id,
                        Result = m.Result
                    }).ToList(),
                    TotalRounds = TotalRounds
                };

                XmlSerializer serializer = new XmlSerializer(typeof(TournamentData));
                using (StreamWriter writer = new StreamWriter(SaveFileName))
                {
                    serializer.Serialize(writer, data);
                }
            }
            catch (Exception)
            {
                // Ignorer les erreurs de sauvegarde silencieusement
            }
        }

        public bool LoadFromFile()
        {
            try
            {
                if (!File.Exists(SaveFileName))
                    return false;

                XmlSerializer serializer = new XmlSerializer(typeof(TournamentData));
                TournamentData data;

                using (StreamReader reader = new StreamReader(SaveFileName))
                {
                    data = (TournamentData)serializer.Deserialize(reader);
                }

                // Restaurer les joueurs
                Players.Clear();
                foreach (var pd in data.Players)
                {
                    var player = new Player(pd.Id, pd.Name)
                    {
                        Points = pd.Points,
                        Victories = pd.Victories,
                        Defeats = pd.Defeats,
                        Abandonments = pd.Abandonments,
                        MatchesPlayed = pd.MatchesPlayed
                    };
                    Players.Add(player);
                }

                // Restaurer les matchs
                Matches.Clear();
                foreach (var md in data.Matches)
                {
                    var player1 = Players.First(p => p.Id == md.Player1Id);
                    var player2 = Players.First(p => p.Id == md.Player2Id);
                    var match = new Match(md.Id, md.Round, player1, player2)
                    {
                        Result = md.Result
                    };
                    Matches.Add(match);
                }

                TotalRounds = data.TotalRounds;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void DeleteSaveFile()
        {
            try
            {
                if (File.Exists(SaveFileName))
                {
                    File.Delete(SaveFileName);
                }
            }
            catch (Exception)
            {
                // Ignorer les erreurs
            }
        }

        public void ResetTournament()
        {
            Players.Clear();
            Matches.Clear();
            TotalRounds = 0;
            DeleteSaveFile();
        }
    }
}