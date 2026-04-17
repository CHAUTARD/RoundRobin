namespace RoundRobin
{
    /// <summary>
    /// Classe pour gérer la sélection des joueurs présents
    /// </summary>
    public class PlayerSelection
    {
        public string Name { get; set; }
        public bool IsPresent { get; set; }

        public PlayerSelection(string name, bool isPresent = true)
        {
            Name = name;
            IsPresent = isPresent;
        }
    }
}