using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze2
{
    public partial class Form1 : Form
    {
        private char[,] maze;
        private Stack<Point> stack = new Stack<Point>();
        private int currentX, currentY;

        public Form1()
        {
            InitializeComponent();
            InitializeMaze();
            StartMazeSolver(); // เริ่มการแก้ไข
        }

        private void InitializeMaze()
        {
            maze = new char[,]
            {
                { '1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
                { '1', '0', '1', '1', '0', '0', '1', '0', '0', '0', '1'},
                { '1', '0', '1', '0', '0', '1', '0', '0', '1', '0', '1'},
                { '1', '0', '1', '1', '0', '0', '1', '0', '1', '0', '1'},
                { '1', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1'},
                { '1', '0', '1', '0', '1', '0', '0', '0', '1', 'S', '1'},
                { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
            };

            // ค้นหาจุดเริ่มต้น 'S'
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    if (maze[i, j] == 'S')
                    {
                        currentX = i;
                        currentY = j;
                        break;
                    }
                }
            }

            DisplayMaze(); // แสดง maze เริ่มต้น
        }

        private void DisplayMaze()
        {
            Bitmap img = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(img);

            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Color color;
                    switch (maze[i, j])
                    {
                        case '1':
                            color = Color.Black; // กำแพง
                            break;
                        case '0':
                            color = Color.White; // ช่องว่าง
                            break;
                        case 'S':
                            color = Color.Blue; // จุดเริ่มต้น
                            break;
                        case 'E':
                            color = Color.Green; // จุดสิ้นสุด
                            break;
                        case '.':
                            color = Color.LightPink; // ช่องที่เยี่ยมชมแล้ว
                            break;
                        default:
                            color = Color.White; // ค่าเริ่มต้น
                            break;
                    }

                    g.FillRectangle(new SolidBrush(color), j * 20, i * 20, 20, 20); // 20x20 เป็นขนาดของแต่ละช่อง
                }
            }

            // แสดงตำแหน่งปัจจุบัน
            g.FillRectangle(new SolidBrush(Color.Red), currentY * 20, currentX * 20, 20, 20); // ใช้ตำแหน่งปัจจุบัน

            pictureBox1.Image = img; // แสดงภาพใน PictureBox
        }

        private async void StartMazeSolver()
        {
            stack.Push(new Point(currentX, currentY)); // เริ่มต้นที่จุดเริ่มต้น
            while (maze[currentX, currentY] != 'E')
            {
                maze[currentX, currentY] = '.'; // ทำเครื่องหมายว่าเยี่ยมชมแล้ว
                DisplayMaze(); // อัปเดตภาพ
                await Task.Delay(500); // รอ 500 ms ก่อนอัปเดตภาพ

                // ตรวจสอบทางที่สามารถเดินได้
                List<Point> neighbors = new List<Point>();
                foreach (var move in new Point[] { new Point(-1, 0), new Point(1, 0), new Point(0, -1), new Point(0, 1) })
                {
                    int newX = currentX + move.X;
                    int newY = currentY + move.Y;
                    if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) && newY < maze.GetLength(1))
                    {
                        if (maze[newX, newY] == '0' || maze[newX, newY] == 'E')
                        {
                            neighbors.Add(new Point(newX, newY));
                        }
                    }
                }

                // ถ้ามีทางเดินไปยัง E หรือ 0
                if (neighbors.Count > 0)
                {
                    // เลือกทางที่ใกล้ที่สุด
                    Point next = neighbors[0]; // เดินไปทางแรกที่พบ
                    currentX = next.X;
                    currentY = next.Y;
                    stack.Push(next);
                }
                else
                {
                    // หากไม่มีทางออก
                    if (stack.Count > 0)
                    {
                        Point previous = stack.Pop();
                        currentX = previous.X;
                        currentY = previous.Y;
                    }
                    else
                    {
                        MessageBox.Show("Cannot exit!");
                        break;
                    }
                }
            }

            // แสดงภาพครั้งสุดท้าย
            DisplayMaze();
        }
    }
}
