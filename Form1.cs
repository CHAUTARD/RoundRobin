using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RoundRobin
{
    public partial class Form1 : Form
    {
        private TournamentManager _tournamentManager;
        private int _currentRound = 1;
        private int _rightClickedRowIndex = -1;
        private int _rightClickedColumnIndex = -1;

        // Références aux onglets pour pouvoir les réajouter après suppression
        private TabPage _tabPageMatches;
        private TabPage _tabPageRankings;

        // Liste de tous les joueurs (pour le filtre)
        private List<string> _allPlayersList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            _tournamentManager = new TournamentManager();
            InitializeMatchesGridStyle();
            InitializeRankingsGridStyle();

            // Sauvegarder les références aux onglets
            _tabPageMatches = TabPageMatches;
            _tabPageRankings = TabPageRankings;

            // Désactiver les onglets Matchs et Classement au démarrage
            UpdateTabsState();

            // Mettre à jour le StatusStrip avec les informations de version
            UpdateStatusStrip();
        }

        private void UpdateStatusStrip()
        {
            // Récupérer les informations de l'assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Récupérer le copyright
            var copyrightAttribute = (AssemblyCopyrightAttribute)assembly
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                .FirstOrDefault();

            // Récupérer la version
            Version version = assembly.GetName().Version;

            // Construire le texte du copyright avec la version
            string copyrightText = copyrightAttribute != null
                ? copyrightAttribute.Copyright
                : "Copyright © 2026 Patrick CH";

            string versionText = $"v{version.Major}.{version.Minor}";

            toolStripStatusLabel1.Text = $"{copyrightText} - {versionText}";
        }

        private void UpdateTabsState()
        {
            // Afficher ou masquer les onglets seulement si des matchs ont été générés
            bool hasMatches = _tournamentManager.Matches != null && _tournamentManager.Matches.Count > 0;

            if (hasMatches)
            {
                // Ajouter les onglets s'ils ne sont pas déjà présents
                if (!TabControl1.TabPages.Contains(_tabPageMatches))
                {
                    // Insérer à la position 1 (après Setup)
                    TabControl1.TabPages.Insert(1, _tabPageMatches);
                }
                if (!TabControl1.TabPages.Contains(_tabPageRankings))
                {
                    // Insérer à la position 2 (après Matchs)
                    TabControl1.TabPages.Insert(2, _tabPageRankings);
                }
            }
            else
            {
                // Retirer les onglets
                if (TabControl1.TabPages.Contains(_tabPageMatches))
                {
                    TabControl1.TabPages.Remove(_tabPageMatches);
                }
                if (TabControl1.TabPages.Contains(_tabPageRankings))
                {
                    TabControl1.TabPages.Remove(_tabPageRankings);
                }

                // S'assurer que l'onglet Setup est sélectionné
                if (TabControl1.TabPages.Contains(TabPageSetup))
                {
                    TabControl1.SelectedTab = TabPageSetup;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tentative de restauration depuis la sauvegarde
            if (_tournamentManager.LoadFromFile())
            {
                var result = MessageBox.Show(
                    "Une sauvegarde de tournoi a été trouvée. Voulez-vous la restaurer?",
                    "Restauration",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Restaurer l'interface
                    _allPlayersList.Clear();
                    ListBoxPresentPlayers.Items.Clear();

                    foreach (var player in _tournamentManager.Players)
                    {
                        _allPlayersList.Add(player.Name);
                        ListBoxPresentPlayers.Items.Add(player.Name);
                    }

                    RefreshAllPlayersList();

                    if (_tournamentManager.Matches.Count > 0)
                    {
                        InitializeRoundComboBox();
                        _currentRound = 1;
                        ComboBoxRound.SelectedIndex = 0;
                        RefreshMatchesGrid();
                        RefreshRankingsGrid();
                        UpdateTabsState(); // Activer les onglets
                        TabControl1.SelectedTab = TabPageMatches;
                    }

                    UpdateTournamentInfo();
                }
                else
                {
                    _tournamentManager.DeleteSaveFile();
                    LoadDefaultPlayers();
                }
            }
            else
            {
                LoadDefaultPlayers();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Sauvegarde automatique à la fermeture
            if (_tournamentManager.Players.Count > 0)
            {
                _tournamentManager.SaveToFile();
            }
        }

        private void InitializeMatchesGridStyle()
        {
            // Centrer la colonne VS
            // ColVS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Style pour les en-têtes
            DataGridViewMatches.EnableHeadersVisualStyles = false;
            DataGridViewMatches.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            DataGridViewMatches.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewMatches.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Événements pour le curseur et le formatage
            DataGridViewMatches.CellMouseEnter += DataGridViewMatches_CellMouseEnter;
            DataGridViewMatches.CellMouseLeave += DataGridViewMatches_CellMouseLeave;
            DataGridViewMatches.CellFormatting += DataGridViewMatches_CellFormatting;
        }

        private void InitializeRankingsGridStyle()
        {
            // S'abonner aux événements
            DataGridViewRankings.DataBindingComplete += DataGridViewRankings_DataBindingComplete;
            DataGridViewRankings.CellFormatting += DataGridViewRankings_CellFormatting;

            // Ajouter un tooltip pour expliquer le symbole ⚖
            DataGridViewRankings.CellMouseEnter += DataGridViewRankings_CellMouseEnter;
            DataGridViewRankings.CellMouseLeave += DataGridViewRankings_CellMouseLeave;
        }

        private ToolTip _rankingsToolTip = new ToolTip();

        private void DataGridViewRankings_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var departageH2HCell = DataGridViewRankings.Rows[e.RowIndex].Cells["DepartageH2H"];  // Enlevé l'accent
                if (departageH2HCell != null && departageH2HCell.Value is bool && (bool)departageH2HCell.Value)
                {
                    if (DataGridViewRankings.Columns[e.ColumnIndex].HeaderText == "Joueur")
                    {
                        _rankingsToolTip.Show(
                            "⚖ Position départagée par confrontation directe (égalité de points)",
                            DataGridViewRankings,
                            DataGridViewRankings.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location,
                            3000);
                    }
                }
            }
        }

        private void DataGridViewRankings_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            _rankingsToolTip.Hide(DataGridViewRankings);
        }

        private void DataGridViewMatches_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Mettre en gras le nom du joueur gagnant
            if (e.RowIndex < 0)
                return;

            var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);

            // Vérifier si c'est la dernière ligne (joueur au repos)
            var restingPlayer = _tournamentManager.GetRestingPlayerForRound(_currentRound);
            bool isRestingPlayerRow = (restingPlayer != null && e.RowIndex == matchesForRound.Count);

            if (isRestingPlayerRow)
            {
                // Style pour la ligne du joueur au repos
                e.CellStyle.BackColor = Color.LightYellow;
                e.CellStyle.Font = new Font(DataGridViewMatches.Font, FontStyle.Italic);
                e.CellStyle.ForeColor = Color.DarkOrange;
                return;
            }

            if (e.RowIndex >= matchesForRound.Count)
                return;

            Match match = matchesForRound[e.RowIndex];

            // Fond de couleur pastel pour toute la ligne selon l'état du match
            if (match.IsPlayed())
            {
                // Abandon : fond rouge pastel
                if (match.Result == MatchResult.Player1Abandoned || match.Result == MatchResult.Player2Abandoned)
                {
                    e.CellStyle.BackColor = Color.MistyRose;
                    e.CellStyle.SelectionBackColor = Color.LightCoral;
                }
                // Match joué normalement : fond vert pastel
                else
                {
                    e.CellStyle.BackColor = Color.Honeydew;
                    e.CellStyle.SelectionBackColor = Color.LightGreen;
                }
            }
            else
            {
                // Match non joué : fond blanc (par défaut)
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionBackColor = SystemColors.Highlight;
            }

            // Colonne Joueur1 (index 1)
            if (e.ColumnIndex == 1)
            {
                if (match.Result == MatchResult.Player1Won)
                {
                    e.CellStyle.Font = new Font(DataGridViewMatches.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (match.Result == MatchResult.Player1Abandoned)
                {
                    e.CellStyle.Font = new Font(DataGridViewMatches.Font, FontStyle.Italic);
                    e.CellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
            // Colonne Joueur2 (index 3)
            else if (e.ColumnIndex == 3)
            {
                if (match.Result == MatchResult.Player2Won)
                {
                    e.CellStyle.Font = new Font(DataGridViewMatches.Font, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
                else if (match.Result == MatchResult.Player2Abandoned)
                {
                    e.CellStyle.Font = new Font(DataGridViewMatches.Font, FontStyle.Italic);
                    e.CellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
            else
            {
                // Autres colonnes : couleur de texte par défaut
                e.CellStyle.ForeColor = Color.Black;
            }
        }

        private void DataGridViewRankings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Centrer toutes les colonnes sauf la colonne "Joueur"
            foreach (DataGridViewColumn column in DataGridViewRankings.Columns)
            {
                if (column.HeaderText != "Joueur")
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    // Aligner à gauche la colonne des noms
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            // Style pour les en-têtes
            DataGridViewRankings.EnableHeadersVisualStyles = false;
            DataGridViewRankings.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            DataGridViewRankings.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridViewRankings.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);
        }

        private void DataGridViewRankings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Récupérer la valeur de la colonne Abandons pour cette ligne
            var abandonValue = DataGridViewRankings.Rows[e.RowIndex].Cells["Abandons"].Value;

            if (abandonValue != null && abandonValue.ToString() == "Oui")
            {
                // Mettre toute la ligne en rouge clair
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.SelectionBackColor = Color.LightCoral;

                // Formater spécifiquement la colonne Abandons
                if (DataGridViewRankings.Columns[e.ColumnIndex].HeaderText == "Abandons")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(DataGridViewRankings.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
            }

            // Formater les joueurs départagés par confrontation directe
            var departageH2HCell = DataGridViewRankings.Rows[e.RowIndex].Cells["DepartageH2H"];  // Enlevé l'accent
            if (departageH2HCell != null && departageH2HCell.Value is bool && (bool)departageH2HCell.Value)
            {
                // Ajouter un fond léger pour les joueurs départagés
                if (abandonValue == null || abandonValue.ToString() != "Oui") // Ne pas écraser le style des abandons
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                    e.CellStyle.SelectionBackColor = Color.Gold;
                }

                // Mettre en italique le nom du joueur
                if (DataGridViewRankings.Columns[e.ColumnIndex].HeaderText == "Joueur")
                {
                    e.CellStyle.Font = new Font(DataGridViewRankings.Font, FontStyle.Italic);
                    e.CellStyle.ForeColor = Color.DarkOrange;
                }
            }
        }

        private void DataGridViewMatches_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Changer le curseur en main uniquement sur les colonnes Joueur1 (index 1) et Joueur2 (index 3)
            if (e.RowIndex >= 0 && (e.ColumnIndex == 1 || e.ColumnIndex == 3))
            {
                var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);
                // Ne pas changer le curseur sur la ligne du joueur au repos
                if (e.RowIndex < matchesForRound.Count)
                {
                    DataGridViewMatches.Cursor = Cursors.Hand;
                }
            }
        }

        private void DataGridViewMatches_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Remettre le curseur par défaut
            DataGridViewMatches.Cursor = Cursors.Default;
        }

        private void LoadDefaultPlayers()
        {
            string defaultPlayersFile = "joueurs.txt";

            // Vérifier si le fichier joueurs.txt existe
            if (System.IO.File.Exists(defaultPlayersFile))
            {
                try
                {
                    // Lire toutes les lignes du fichier avec l'encodage UTF-8
                    string[] lines = System.IO.File.ReadAllLines(defaultPlayersFile, System.Text.Encoding.UTF8);

                    // Filtrer les lignes vides et supprimer les espaces
                    List<string> players = lines
                        .Select(line => line.Trim())
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .ToList();

                    if (players.Count > 0)
                    {
                        _allPlayersList.Clear();
                        _allPlayersList.AddRange(players);

                        RefreshAllPlayersList();

                        // Ajouter tous les joueurs dans la liste des présents par défaut
                        foreach (string playerName in players)
                        {
                            ListBoxPresentPlayers.Items.Add(playerName);
                        }

                        UpdateTournamentInfoFromPresentPlayers();
                        UpdateGenerateButtonState();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Le fichier joueurs.txt est vide.\n\nVeuillez ajouter des joueurs manuellement ou charger un fichier.",
                            "Fichier vide",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Erreur lors de la lecture du fichier joueurs.txt :\n{ex.Message}\n\nVeuillez ajouter des joueurs manuellement.",
                        "Erreur de lecture",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(
                    "Le fichier joueurs.txt est introuvable.\n\nVeuillez ajouter des joueurs manuellement ou charger un fichier.",
                    "Fichier introuvable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void BtnAddPlayer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPlayerName.Text))
            {
                MessageBox.Show("Veuillez entrer un nom de joueur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string playerName = TxtPlayerName.Text.Trim();

            // Vérifier si le joueur n'existe pas déjà
            if (_allPlayersList.Contains(playerName))
            {
                MessageBox.Show("Ce joueur existe déjà dans la liste.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ajouter le joueur à la liste complète et à la liste des présents
            _allPlayersList.Add(playerName);
            RefreshAllPlayersList();
            ListBoxPresentPlayers.Items.Add(playerName);

            TxtPlayerName.Clear();
            TxtPlayerName.Focus();

            UpdateTournamentInfoFromPresentPlayers();
            UpdateGenerateButtonState();

            // Pas de sauvegarde ici, car on sauvegarde uniquement les joueurs présents lors de la génération
        }

        private void BtnLoadFromFile_Click(object sender, EventArgs e)
        {
            // Ouvrir une boîte de dialogue pour sélectionner le fichier
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*";
                openFileDialog.Title = "Sélectionner le fichier de joueurs";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lire toutes les lignes du fichier
                        string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName, System.Text.Encoding.UTF8);

                        // Filtrer les lignes vides et supprimer les espaces
                        List<string> allPlayers = lines
                            .Select(line => line.Trim())
                            .Where(line => !string.IsNullOrWhiteSpace(line))
                            .ToList();

                        if (allPlayers.Count == 0)
                        {
                            MessageBox.Show("Le fichier ne contient aucun nom de joueur valide.",
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Effacer les listes actuelles
                        _allPlayersList.Clear();
                        ListBoxAllPlayers.Items.Clear();
                        ListBoxPresentPlayers.Items.Clear();

                        // Ajouter tous les joueurs
                        _allPlayersList.AddRange(allPlayers);
                        RefreshAllPlayersList();

                        // Tous présents par défaut
                        foreach (string playerName in allPlayers)
                        {
                            ListBoxPresentPlayers.Items.Add(playerName);
                        }

                        UpdateTournamentInfoFromPresentPlayers();
                        UpdateGenerateButtonState();

                        MessageBox.Show(
                            $"{allPlayers.Count} joueur(s) chargé(s) avec succès!\n\n" +
                            "Utilisez le drag & drop pour gérer les joueurs présents",
                            "Succès",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Erreur lors de la lecture du fichier :\n{ex.Message}",
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnGenerateMatches_Click(object sender, EventArgs e)
        {
            // Vérifier le nombre de joueurs présents
            int presentPlayersCount = ListBoxPresentPlayers.Items.Count;

            if (presentPlayersCount < 2)
            {
                MessageBox.Show(
                    "Vous devez avoir au moins 2 joueurs présents pour générer les matchs.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Mettre à jour le TournamentManager avec les joueurs présents
            _tournamentManager.Players.Clear();
            int playerId = 1;
            foreach (string playerName in ListBoxPresentPlayers.Items)
            {
                _tournamentManager.Players.Add(new Player(playerId, playerName));
                playerId++;
            }

            _tournamentManager.GenerateMatches();
            InitializeRoundComboBox();
            _currentRound = 1;
            ComboBoxRound.SelectedIndex = 0;
            RefreshMatchesGrid();
            UpdateTabsState(); // Activer les onglets après génération
            TabControl1.SelectedTab = TabPageMatches;

            string message = $"Tournoi généré avec succès!\n\n";
            message += $"Nombre de joueurs : {presentPlayersCount}\n";
            message += $"Nombre de tours : {_tournamentManager.TotalRounds}\n";
            message += $"Total de matchs : {_tournamentManager.Matches.Count}\n";
            message += $"Matchs par tour : {_tournamentManager.Matches.Count / _tournamentManager.TotalRounds}";

            MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Sauvegarde après génération
            _tournamentManager.SaveToFile();
        }

        private void InitializeRoundComboBox()
        {
            ComboBoxRound.Items.Clear();
            for (int i = 1; i <= _tournamentManager.TotalRounds; i++)
            {
                ComboBoxRound.Items.Add($"Tour {i}");
            }

            if (ComboBoxRound.Items.Count > 0)
            {
                UpdateRoundNavigationButtons();
            }
        }

        private void ComboBoxRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxRound.SelectedIndex >= 0)
            {
                _currentRound = ComboBoxRound.SelectedIndex + 1;
                RefreshMatchesGrid();
                RefreshRankingsGrid();
                UpdateRoundNavigationButtons();
            }
        }

        private void BtnPreviousRound_Click(object sender, EventArgs e)
        {
            if (ComboBoxRound.SelectedIndex > 0)
            {
                ComboBoxRound.SelectedIndex--;
            }
        }

        private void BtnNextRound_Click(object sender, EventArgs e)
        {
            if (ComboBoxRound.SelectedIndex < ComboBoxRound.Items.Count - 1)
            {
                ComboBoxRound.SelectedIndex++;
            }
        }

        private void UpdateRoundNavigationButtons()
        {
            // Activer/Désactiver les boutons selon le tour actuel
            BtnPreviousRound.Enabled = ComboBoxRound.SelectedIndex > 0;
            BtnNextRound.Enabled = ComboBoxRound.SelectedIndex < ComboBoxRound.Items.Count - 1;

            // Changer l'apparence des boutons désactivés
            BtnPreviousRound.ForeColor = BtnPreviousRound.Enabled ? Color.Black : Color.Gray;
            BtnNextRound.ForeColor = BtnNextRound.Enabled ? Color.Black : Color.Gray;
        }

        private void RefreshMatchesGrid()
        {
            var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);
            var restingPlayer = _tournamentManager.GetRestingPlayerForRound(_currentRound);

            var matchesData = matchesForRound.Select(m => new
            {
                Match = $"Match {m.Id}",
                Joueur1 = m.Player1.Name,
                VS = "vs",
                Joueur2 = m.Player2.Name,
                Resultat = GetResultText(m.Result)  // Enlevé l'accent
            }).ToList();

            // Ajouter une ligne pour le joueur au repos si nombre impair de joueurs
            if (restingPlayer != null)
            {
                matchesData.Add(new
                {
                    Match = "---",
                    Joueur1 = restingPlayer.Name,
                    VS = "",
                    Joueur2 = "(Ne joue pas ce tour)",
                    Resultat = "Au repos"  // Enlevé l'accent
                });
            }

            DataGridViewMatches.DataSource = matchesData;
        }

        private string GetResultText(MatchResult result)
        {
            switch (result)
            {
                case MatchResult.NotPlayed:
                    return "Non joué";
                case MatchResult.Player1Won:
                    return "Victoire Joueur 1";
                case MatchResult.Player2Won:
                    return "Victoire Joueur 2";
                case MatchResult.Player1Abandoned:
                    return "Abandon Joueur 1";
                case MatchResult.Player2Abandoned:
                    return "Abandon Joueur 2";
                default:
                    return "Non joué";
            }
        }

        private void DataGridViewMatches_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Gestion du clic droit
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);

                // Ignorer le clic sur la ligne du joueur au repos
                if (e.RowIndex >= matchesForRound.Count)
                    return;

                // Vérifier si le clic est sur la colonne Joueur1 (index 1) ou Joueur2 (index 3)
                if (e.ColumnIndex == 1 || e.ColumnIndex == 3)
                {
                    _rightClickedRowIndex = e.RowIndex;
                    _rightClickedColumnIndex = e.ColumnIndex;

                    Match selectedMatch = matchesForRound[e.RowIndex];

                    string playerName = (e.ColumnIndex == 1) ? selectedMatch.Player1.Name : selectedMatch.Player2.Name;
                    MenuItemAbandon.Text = $"Déclarer l'abandon de {playerName}";

                    ContextMenuStripPlayer.Show(DataGridViewMatches, e.Location);
                }
            }
        }

        private void MenuItemAbandon_Click(object sender, EventArgs e)
        {
            if (_rightClickedRowIndex < 0)
                return;

            var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);
            Match selectedMatch = matchesForRound[_rightClickedRowIndex];

            Player abandoningPlayer;
            MatchResult matchResult;

            if (_rightClickedColumnIndex == 1)
            {
                abandoningPlayer = selectedMatch.Player1;
                matchResult = MatchResult.Player1Abandoned;
            }
            else
            {
                abandoningPlayer = selectedMatch.Player2;
                matchResult = MatchResult.Player2Abandoned;
            }

            var result = MessageBox.Show(
                $"Confirmez-vous l'abandon de {abandoningPlayer.Name}?\n\n" +
                $"Cet abandon sera automatiquement reporté sur tous ses matchs restants dans les tours suivants.",
                "Confirmer l'abandon",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Enregistrer l'abandon du match actuel
                _tournamentManager.RecordMatchResult(selectedMatch, matchResult);

                // Reporter l'abandon sur tous les matchs restants
                int abandonedMatchesCount = _tournamentManager.ApplyAbandonToRemainingMatches(abandoningPlayer, _currentRound);

                RefreshMatchesGrid();
                RefreshRankingsGrid();

                // Sauvegarde après modification
                _tournamentManager.SaveToFile();

                string message = $"Abandon enregistré pour {abandoningPlayer.Name}.";
                if (abandonedMatchesCount > 0)
                {
                    message += $"\n\n{abandonedMatchesCount} match(s) restant(s) ont été automatiquement marqués comme abandonnés.";
                }

                MessageBox.Show(message, "Abandon enregistré", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _rightClickedRowIndex = -1;
            _rightClickedColumnIndex = -1;
        }

        private void DataGridViewMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorer les clics sur l'en-tête
            if (e.RowIndex < 0)
                return;

            var matchesForRound = _tournamentManager.GetMatchesByRound(_currentRound);

            // Ignorer le clic sur la ligne du joueur au repos
            if (e.RowIndex >= matchesForRound.Count)
                return;

            // Vérifier si le clic est sur la colonne Joueur1 (index 1) ou Joueur2 (index 3)
            if (e.ColumnIndex != 1 && e.ColumnIndex != 3)
                return;

            Match selectedMatch = matchesForRound[e.RowIndex];

            // Si le match est déjà joué, demander confirmation
            if (selectedMatch.IsPlayed())
            {
                var result = MessageBox.Show(
                    $"Ce match a déjà un résultat : {GetResultText(selectedMatch.Result)}\n\nVoulez-vous le modifier?",
                    "Match déjà joué",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;
            }

            // Déterminer quel joueur a gagné selon la colonne cliquée
            MatchResult matchResult = (e.ColumnIndex == 1)
                ? MatchResult.Player1Won
                : MatchResult.Player2Won;

            // Enregistrer le résultat
            _tournamentManager.RecordMatchResult(selectedMatch, matchResult);
            RefreshMatchesGrid();
            RefreshRankingsGrid();

            // Sauvegarde après modification
            _tournamentManager.SaveToFile();
        }

        private void RefreshRankingsGrid()
        {
            var rankings = _tournamentManager.GetRankings();
            var rankingsData = rankings.Select((p, index) => new RankingDisplay
            {
                Position = index + 1,
                Joueur = p.Name + (p.RankedByHeadToHead ? " ⚖" : ""),
                Points = p.Points,
                Victoires = p.Victories,
                Defaites = p.Defeats,  // Enlevé l'accent
                Abandons = p.Abandonments > 0 ? "Oui" : "Non",
                AbandonCount = p.Abandonments,
                MatchsJoues = p.MatchesPlayed,  // Enlevé l'accent
                DepartageH2H = p.RankedByHeadToHead  // Enlevé l'accent
            }).ToList();

            DataGridViewRankings.DataSource = rankingsData;

            // Masquer la colonne AbandonCount (utilisée uniquement pour le formatage)
            if (DataGridViewRankings.Columns["AbandonCount"] != null)
            {
                DataGridViewRankings.Columns["AbandonCount"].Visible = false;
            }

            // Masquer la colonne DepartageH2H (utilisée uniquement pour le formatage)
            if (DataGridViewRankings.Columns["DepartageH2H"] != null)  // Enlevé l'accent
            {
                DataGridViewRankings.Columns["DepartageH2H"].Visible = false;
            }
        }

        private void UpdateTournamentInfo()
        {
            int playerCount = _tournamentManager.Players.Count;

            if (playerCount < 2)
            {
                LabelTotalMatches.Text = "Total de matchs : --";
                LabelTotalRounds.Text = "Nombre de tours : --";
                LabelDuration3Sets.Text = "⏱️ Durée totale (3 manches) : --";
                LabelDuration5Sets.Text = "⏱️ Durée totale (5 manches) : --";
                LabelDurationPerRound3Sets.Text = "   Durée par tour : --";
                LabelDurationPerRound5Sets.Text = "   Durée par tour : --";
                return;
            }

            // Calculs
            int totalMatches = (playerCount * (playerCount - 1)) / 2;
            int totalRounds = playerCount % 2 == 0 ? playerCount - 1 : playerCount;
            int matchesPerRound = playerCount / 2;

            // Durées en minutes (1 tour = 15 ou 25 min car matchs en parallèle)
            int duration3Sets = totalRounds * 15;  // 15 min par tour
            int duration5Sets = totalRounds * 25;  // 25 min par tour

            // Mise à jour des labels
            LabelTotalMatches.Text = $"Total de matchs : {totalMatches}";
            LabelTotalRounds.Text = $"Nombre de tours : {totalRounds}";

            LabelDuration3Sets.Text = $"⏱️ Durée totale (3 manches) : {FormatDuration(duration3Sets)}";
            LabelDuration5Sets.Text = $"⏱️ Durée totale (5 manches) : {FormatDuration(duration5Sets)}";

            LabelDurationPerRound3Sets.Text = $"   • {matchesPerRound} matchs simultanés : 15 min/tour";
            LabelDurationPerRound5Sets.Text = $"   • {matchesPerRound} matchs simultanés : 25 min/tour";
        }

        private string FormatDuration(int minutes)
        {
            if (minutes < 60)
            {
                return $"{minutes} min";
            }
            else
            {
                int hours = minutes / 60;
                int remainingMinutes = minutes % 60;

                if (remainingMinutes == 0)
                {
                    return $"{hours}h";
                }
                else
                {
                    return $"{hours}h{remainingMinutes:D2}";
                }
            }
        }

        private void BtnResetTournament_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Êtes-vous sûr de vouloir réinitialiser le tournoi? Toutes les données seront perdues.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _tournamentManager.ResetTournament();
                _allPlayersList.Clear();
                ListBoxAllPlayers.Items.Clear();
                ListBoxPresentPlayers.Items.Clear();
                TxtFilterPlayers.Clear();
                ComboBoxRound.Items.Clear();
                DataGridViewMatches.DataSource = null;
                DataGridViewRankings.DataSource = null;
                TxtPlayerName.Clear();
                _currentRound = 1;

                UpdateTabsState(); // Désactiver les onglets après réinitialisation
                TabControl1.SelectedTab = TabPageSetup;

                // Recharger les joueurs par défaut
                LoadDefaultPlayers();

                MessageBox.Show("Tournoi réinitialisé.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTournamentInfoFromPresentPlayers()
        {
            int presentCount = ListBoxPresentPlayers.Items.Count;

            if (presentCount < 2)
            {
                LabelTotalMatches.Text = "Total de matchs : --";
                LabelTotalRounds.Text = "Nombre de tours : --";
                LabelDuration3Sets.Text = "⏱️ Durée totale (3 manches) : --";
                LabelDuration5Sets.Text = "⏱️ Durée totale (5 manches) : --";
                LabelDurationPerRound3Sets.Text = "   Durée par tour : --";
                LabelDurationPerRound5Sets.Text = "   Durée par tour : --";
                return;
            }

            // Calculs basés sur les joueurs présents
            int totalMatches = (presentCount * (presentCount - 1)) / 2;
            int totalRounds = presentCount % 2 == 0 ? presentCount - 1 : presentCount;
            int matchesPerRound = presentCount / 2;

            // Durées en minutes
            int duration3Sets = totalRounds * 15;
            int duration5Sets = totalRounds * 25;

            // Mise à jour des labels
            LabelTotalMatches.Text = $"Total de matchs : {totalMatches}";
            LabelTotalRounds.Text = $"Nombre de tours : {totalRounds} ({presentCount} joueurs présents)";

            LabelDuration3Sets.Text = $"⏱️ Durée totale (3 manches) : {FormatDuration(duration3Sets)}";
            LabelDuration5Sets.Text = $"⏱️ Durée totale (5 manches) : {FormatDuration(duration5Sets)}";

            LabelDurationPerRound3Sets.Text = $"   • {matchesPerRound} matchs simultanés : 15 min/tour";
            LabelDurationPerRound5Sets.Text = $"   • {matchesPerRound} matchs simultanés : 25 min/tour";
        }

        private void UpdateGenerateButtonState()
        {
            // Activer le bouton seulement si au moins 2 joueurs sont présents
            BtnGenerateMatches.Enabled = ListBoxPresentPlayers.Items.Count >= 2;
        }

        private void BtnCheckAll_Click(object sender, EventArgs e)
        {
            // Ajouter tous les joueurs de la liste complète dans la liste des présents
            ListBoxPresentPlayers.Items.Clear();
            foreach (string playerName in _allPlayersList)
            {
                if (!ListBoxPresentPlayers.Items.Contains(playerName))
                {
                    ListBoxPresentPlayers.Items.Add(playerName);
                }
            }

            UpdateTournamentInfoFromPresentPlayers();
            UpdateGenerateButtonState();
        }

        private void BtnUncheckAll_Click(object sender, EventArgs e)
        {
            // Retirer tous les joueurs de la liste des présents
            ListBoxPresentPlayers.Items.Clear();

            UpdateTournamentInfoFromPresentPlayers();
            UpdateGenerateButtonState();
        }

        private bool ValidatePlayerName(string name)
        {
            // Vérifier les caractères spéciaux
            // Limiter la longueur
            // Éviter les doublons insensibles à la casse
            return Regex.IsMatch(name, @"^[a-zA-ZÀ-ÿ\s\-']{2,50}$");
        }

        #region Drag & Drop et Filtre

        private void RefreshAllPlayersList()
        {
            string filter = TxtFilterPlayers.Text.ToLower();
            ListBoxAllPlayers.Items.Clear();

            foreach (string playerName in _allPlayersList)
            {
                // N'afficher que les joueurs qui ne sont pas dans la liste des présents
                if (!ListBoxPresentPlayers.Items.Contains(playerName))
                {
                    // Appliquer le filtre
                    if (string.IsNullOrEmpty(filter) || playerName.ToLower().Contains(filter))
                    {
                        ListBoxAllPlayers.Items.Add(playerName);
                    }
                }
            }
        }

        private void TxtFilterPlayers_TextChanged(object sender, EventArgs e)
        {
            RefreshAllPlayersList();
        }

        private void BtnClearFilter_Click(object sender, EventArgs e)
        {
            TxtFilterPlayers.Clear();
            TxtFilterPlayers.Focus();
        }

        private void ListBoxAllPlayers_DoubleClick(object sender, EventArgs e)
        {
            // Transférer le joueur sélectionné vers la liste des présents
            if (ListBoxAllPlayers.SelectedItem != null)
            {
                string selectedPlayer = ListBoxAllPlayers.SelectedItem.ToString();

                // Ajouter à la liste des présents
                if (!ListBoxPresentPlayers.Items.Contains(selectedPlayer))
                {
                    ListBoxPresentPlayers.Items.Add(selectedPlayer);
                }

                // Rafraîchir la liste complète (le joueur sera automatiquement retiré)
                RefreshAllPlayersList();
                UpdateTournamentInfoFromPresentPlayers();
                UpdateGenerateButtonState();
            }
        }

        private void ListBoxPresentPlayers_DoubleClick(object sender, EventArgs e)
        {
            // Transférer le joueur sélectionné vers la liste complète (le retirer des présents)
            if (ListBoxPresentPlayers.SelectedItem != null)
            {
                string selectedPlayer = ListBoxPresentPlayers.SelectedItem.ToString();

                // Retirer de la liste des présents
                ListBoxPresentPlayers.Items.Remove(selectedPlayer);

                // Rafraîchir la liste complète (le joueur sera automatiquement ajouté)
                RefreshAllPlayersList();
                UpdateTournamentInfoFromPresentPlayers();
                UpdateGenerateButtonState();
            }
        }

        private void ListBoxAllPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (ListBoxAllPlayers.SelectedItems.Count == 0)
                return;

            var selectedItems = new List<string>();
            foreach (string item in ListBoxAllPlayers.SelectedItems)
            {
                selectedItems.Add(item);
            }

            ListBoxAllPlayers.DoDragDrop(selectedItems, DragDropEffects.Move);
        }

        private void ListBoxPresentPlayers_MouseDown(object sender, MouseEventArgs e)
        {
            if (ListBoxPresentPlayers.SelectedItems.Count == 0)
                return;

            var selectedItems = new List<string>();
            foreach (string item in ListBoxPresentPlayers.SelectedItems)
            {
                selectedItems.Add(item);
            }

            ListBoxPresentPlayers.DoDragDrop(selectedItems, DragDropEffects.Move);
        }

        private void ListBoxAllPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBoxPresentPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ListBoxAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                var items = (List<string>)e.Data.GetData(typeof(List<string>));

                // Retirer les joueurs de la liste des présents et rafraîchir la liste complète
                foreach (string item in items)
                {
                    ListBoxPresentPlayers.Items.Remove(item);
                }

                RefreshAllPlayersList();
                UpdateTournamentInfoFromPresentPlayers();
                UpdateGenerateButtonState();
            }
        }

        private void ListBoxPresentPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(List<string>)))
            {
                var items = (List<string>)e.Data.GetData(typeof(List<string>));

                // Ajouter les joueurs à la liste des présents
                foreach (string item in items)
                {
                    if (!ListBoxPresentPlayers.Items.Contains(item))
                    {
                        ListBoxPresentPlayers.Items.Add(item);
                    }
                }

                RefreshAllPlayersList();
                UpdateTournamentInfoFromPresentPlayers();
                UpdateGenerateButtonState();
            }
        }

        #endregion
    }
}