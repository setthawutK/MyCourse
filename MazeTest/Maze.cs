using Stacks;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace MazeTest
{
    public class Maze
    {
        private static char[,] maze1 = new char[,] //ไม่ต้องลบไว้เปลี่ยน maze
        {
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '0', '1', '0', '0', '0', '0', '0', '0', 'S', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
        };

        private static char[,] maze = new char[,]
        {
            { '1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '0', '1', '1', '0', '0', '1', '0', '0', '0', '1'},
            { '1', '0', '1', '0', '0', '1', '0', '0', '1', '0', '1'},
            { '1', '0', '1', '1', '0', '0', '1', '0', '1', '0', '1'},
            { '1', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1'},
            { '1', '0', '1', '0', '1', '0', '0', '0', '1', 'S', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
        };

        private Pos start;

        private class Pos
        {
            public int row;
            public int col;

            public Pos(int r, int c)
            {
                row = r;
                col = c;
            }
        }

        private Pos FindStart()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                    if (maze[i, j] == 'S')
                        return new Pos(i, j);
            }
            throw new InvalidOperationException("'S' not found!");
        }

        private Pos FindEnd()
        {
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                    if (maze[i, j] == 'E')
                        return new Pos(i, j);
            }
            throw new InvalidOperationException("'E' not found!");
        }

        private int[] dRow = { 0, 0, 1, -1 };
        private int[] dCol = { 1, -1, 0, 0 };

        private bool IsConnect(Pos a, Pos b)
        {
            int i = a.row;
            int j = a.col;

            // ตรวจสอบแต่ละทิศทางว่าตำแหน่งถัดไปเชื่อมต่อกับตำแหน่ง b หรือไม่
            for (int k = 0; k < 4; k++)
            {
                int newRow = i + dRow[k];
                int newCol = j + dCol[k];
                if (newRow == b.row && newCol == b.col)
                {
                    return true;
                }
            }
            return false;
        }

        private async void walkingPath(Pos start)
        {
            Stack path = new ArrayStack(1);
            Stack stack = new ArrayStack(1); // Stack สำหรับทางแยก

            Pos current = start;
            int i = current.row;
            int j = current.col;

            while (maze[i, j] != 'E')
            {
                maze[i, j] = 'S';

                path.push(new Pos(i, j)); // เพิ่มตำแหน่งปัจจุบันลงใน Stack ของเส้นทาง

                // อัปเดตการแสดงผลใน GUI
                DisplayMaze();
                await Task.Delay(500); // รอ 500 ms ก่อนอัปเดตภาพ

                // ทำเครื่องหมายตำแหน่งปัจจุบันว่าเยี่ยมชมแล้ว
                maze[i, j] = '.'; ;
                // ตรวจทางเดินจาก ขึ้น ลง ซ้าย ขวา ตามลำดับ
                for (int k = 0; k < 4; k++)
                {
                    int newRow = i + dRow[k];
                    int newCol = j + dCol[k];
                    if (maze[newRow, newCol] == '0' || maze[newRow, newCol] == 'E')
                    {
                        stack.push(new Pos(newRow, newCol));
                    }
                }

                // อัปเดตตำแหน่งปัจจุบัน
                if (!stack.isEmpty())
                {
                    Pos update = (Pos)stack.pop();
                    i = update.row;
                    j = update.col;
                }
                else
                {
                    //MessageBox.Show("Cannot exit!");
                    Console.WriteLine("Cannot exit!");
                    break;
                }
                // ถ้าเจอทางตันหรือถอยหลังได้ ให้ pop กลับไปยังตำแหน่งที่เชื่อมต่อ             
                while (!path.isEmpty())
                {
                    Pos lastPos = (Pos)path.peek();
                    int x = lastPos.row;
                    int y = lastPos.col;

                    if (IsConnect(new Pos(i, j), lastPos))
                    {
                        break; // ถ้าสามารถเชื่อมต่อได้ให้หยุดย้อนกลับ
                    }

                    Pos back = (Pos)path.pop(); // ดึงตำแหน่งสุดท้ายจาก Stack
                    int m = back.row;
                    int n = back.col;

                    maze[m, n] = 'S'; // ทำเครื่องหมายว่าตำแหน่งนี้คือ S ขณะย้อนกลับ
                    DisplayMaze();
                    await Task.Delay(500); // รอ 300 ms เพื่อแสดงการเปลี่ยนแปลง

                    maze[x, y] = '.'; // เปลี่ยนค่าตำแหน่งที่ย้อนกลับมาเป็น .
                }
            }

            if (maze[i, j] == 'E') // ถ้าพบทางออก
            {
                maze[i, j] = 'S'; // ทำเครื่องหมายทางออก
                DisplayMaze();
                await Task.Delay(500); // รอเพื่อให้แสดงผล
                Console.WriteLine("Found!");
                //MessageBox.Show("Found!"); // แจ้งเตือนว่าพบทางออก
            }
        }

        private void DisplayMaze()
        {
            // แสดงการพิมพ์ maze บน console
            Console.Clear();
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Console.Write(maze[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Maze maze = new Maze();
            // Find the starting position and initiate the walking path
            Pos start = maze.FindStart();
            maze.walkingPath(start); // Call the walking path function with the starting position
            Console.ReadLine();
        }
    }

  
}
