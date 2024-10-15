using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class Maze
    {
        private static readonly int SPACE = -1;
        private static readonly int BLOCK = -9;
        private static int[,] map = new int[10, 10];
        private class Pos
        {
            public int row, col;
            public Pos(int r, int c) { row = r; col = c; }
        }

        public static void Main(string[] args)
        {
            Random rand = new Random();

            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                    map[i, j] = rand.NextDouble() < 0.2 ? BLOCK : SPACE;

            findPath(new Pos(0, 0), new Pos(0, map.GetLength(1) - 1));

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                    Console.Write($"{map[i, j],4}");
                Console.WriteLine();
            }
            Console.ReadLine();

        }

        static void findPath(Pos source, Pos target)
        {
            map[source.row, source.col] = 0;
            map[target.row, target.col] = SPACE;

            Queue<Pos> q = new Queue<Pos>();
            q.Enqueue(source);

            while (q.Count > 0)
            {
                Pos p = q.Dequeue();
                if (p.row == target.row && p.col == target.col) break;

                expand(q, p.row + 1, p.col, map[p.row, p.col]);
                expand(q, p.row - 1, p.col, map[p.row, p.col]);
                expand(q, p.row, p.col + 1, map[p.row, p.col]);
                expand(q, p.row, p.col - 1, map[p.row, p.col]);
            }
        }

        static void expand(Queue<Pos> q, int r, int c, int k)
        {
            if (r < 0 || r >= map.GetLength(0) || c < 0 || c >= map.GetLength(1) || map[r, c] != SPACE) return;
            map[r, c] = k + 1;
            q.Enqueue(new Pos(r, c));
        }
    }
}
