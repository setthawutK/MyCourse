using System;

namespace Puzzle15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] initialBoard =
            {
                {1, 2, 3, 4},
                {5, 6, 0, 8},
                {9, 10, 7, 11},
                {13, 14, 15, 12}
            };

            Puzzle puzzle = new Puzzle();
            puzzle.Solve(initialBoard);
            Console.ReadLine();
        }
    }
}
