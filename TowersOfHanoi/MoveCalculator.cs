using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    public static class MoveCalculator
    {
        private static List<Move> Moves { get; set; }

        public static List<Move> GetMoves(int numberOfDisks)
        {
            Moves = new List<Move>();
            Calculate(numberOfDisks - 1, 0, 2);
            return Moves;
        }

        public static int GetMoveCount(int numberOfDisks)
        {
            var numberOfDisksDouble = numberOfDisks;
            return (int) Math.Pow(2.0, numberOfDisksDouble) - 1;
        }

        private static void Calculate(int n, int fromPole, int toPole)
        {
            if (n == -1)
                return;

            var intermediatePole = GetIntermediatePole(fromPole, toPole);
            
            Calculate(n - 1, fromPole, intermediatePole);
            Moves.Add(new Move(fromPole, toPole));
            Calculate(n - 1, intermediatePole, toPole);
        }

        private static int GetIntermediatePole(int startPole, int endPole)
        {
            return (3 - startPole - endPole);
        }
    }
}
