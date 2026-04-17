using System;

namespace RoundRobin
{
    public enum MatchResult
    {
        NotPlayed,
        Player1Won,
        Player2Won,
        Player1Abandoned,
        Player2Abandoned
    }

    public class Match
    {
        public int Id { get; set; }
        public int Round { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public MatchResult Result { get; set; }

        public Match(int id, int round, Player player1, Player player2)
        {
            Id = id;
            Round = round;
            Player1 = player1;
            Player2 = player2;
            Result = MatchResult.NotPlayed;
        }

        public bool IsPlayed()
        {
            return Result != MatchResult.NotPlayed;
        }
    }
}