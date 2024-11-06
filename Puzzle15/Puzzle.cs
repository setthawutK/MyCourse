using System;
using System.Collections.Generic;
using System.Threading;

namespace Puzzle15
{
    public class Puzzle
    {
        private const int N = 4;
        private readonly int[,] goalState =
        {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12},
            {13, 14, 15, 0}
        };

        private bool IsAnswer(int[,] board)
        {
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    if (board[i, j] != goalState[i, j])
                        return false;
            return true;
        }

        private IEnumerable<int[,]> MoveBlank(int[,] board)
        {
            int blankRow = -1, blankCol = -1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 0)
                    {
                        blankRow = i;
                        blankCol = j;
                    }
                }
            }

            int[] dRow = { -1, 1, 0, 0 };
            int[] dCol = { 0, 0, -1, 1 };

            for (int k = 0; k < 4; k++)
            {
                int newRow = blankRow + dRow[k];
                int newCol = blankCol + dCol[k];

                if (newRow >= 0 && newRow < N && newCol >= 0 && newCol < N)
                {
                    int[,] newBoard = (int[,])board.Clone();
                    newBoard[blankRow, blankCol] = newBoard[newRow, newCol];
                    newBoard[newRow, newCol] = 0;
                    yield return newBoard;
                }
            }
        }

        public bool Solve(int[,] initialBoard)
        {
            Queue<int[,]> queue = new Queue<int[,]>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(initialBoard);
            visited.Add(BoardToString(initialBoard));

            while (queue.Count > 0)
            {
                int[,] currentBoard = queue.Dequeue();

                // แสดงสถานะบอร์ดแบบเรียลไทม์
                Console.Clear();
                PrintBoard(currentBoard);
                Thread.Sleep(500); // หน่วงเวลา 500 มิลลิวินาที

                if (IsAnswer(currentBoard))
                {
                    Console.WriteLine("Puzzle solved!");
                    return true;
                }

                foreach (var newBoard in MoveBlank(currentBoard))
                {
                    string boardString = BoardToString(newBoard);
                    if (!visited.Contains(boardString))
                    {
                        queue.Enqueue(newBoard);
                        visited.Add(boardString);
                    }
                }
            }

            Console.WriteLine("No solution found.");
            return false;
        }

        private string BoardToString(int[,] board)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    list.Add(board[i, j].ToString());
                }
            }
            return string.Join(",", list);
        }

        // ฟังก์ชันแสดงบอร์ดปัจจุบัน
        private void PrintBoard(int[,] board)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(board[i, j] == 0 ? "   " : $"{board[i, j],2} ");
                }
                Console.WriteLine();
            }
        }
    }
}
