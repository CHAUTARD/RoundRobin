namespace RoundRobin
{
    /// <summary>
    /// Classe pour afficher les données de classement dans le DataGridView
    /// avec formatage personnalisé pour la colonne Abandons (Oui/Non)
    /// </summary>
    public class RankingDisplay
    {
        public int Position { get; set; }
        public string Joueur { get; set; }
        public int Points { get; set; }
        public int Victoires { get; set; }
        public int Défaites { get; set; }
        public string Abandons { get; set; }
        public int AbandonCount { get; set; }
        public int MatchsJoués { get; set; }
        public bool DépartagéH2H { get; set; } // Nouveau : indicateur de départage
    }
}