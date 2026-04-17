using System;

namespace RoundRobin
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public int Abandonments { get; set; }
        public int MatchesPlayed { get; set; }
        public bool RankedByHeadToHead { get; set; } // Nouveau : indique si départagé par confrontation directe

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
            Points = 0;
            Victories = 0;
            Defeats = 0;
            Abandonments = 0;
            MatchesPlayed = 0;
            RankedByHeadToHead = false;
        }
    }
}   