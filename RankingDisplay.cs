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
        public int Defaites { get; set; }  // Enlevé l'accent
        public string Abandons { get; set; }
        public int AbandonCount { get; set; }
        public int MatchsJoues { get; set; }  // Enlevé l'accent
        public bool DepartageH2H { get; set; }  // Enlevé l'accent
    }
}