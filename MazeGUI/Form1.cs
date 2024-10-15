using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGUI
{
    public partial class Form1 : Form
    {
        private char[,] maze = new char[,]
        {
            { '1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', '0', '1', '1', '0', '0', '1', '0', '0', '0', '1'},
            { '1', '0', '1', '0', '0', '1', '0', '0', '1', '0', '1'},
            { '1', '0', '1', '1', '0', '0', '1', '0', '1', '0', '1'},
            { '1', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1'},
            { '1', '0', '1', '0', '1', '0', '0', '0', '1', 'S', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
        };

        private int playerX = 5; // ตำแหน่ง Y ของผู้เล่น (S)
        private int playerY = 9; // ตำแหน่ง X ของผู้เล่น (S)
        private Timer moveTimer;
        private Stack<(int, int)> positionHistory = new Stack<(int, int)>(); // Stack เก็บประวัติตำแหน่ง

        public Form1()
        {
            InitializeComponent();
            InitializeMaze();
            moveTimer = new Timer();
            moveTimer.Interval = 500; // เวลาระหว่างการเคลื่อนที่ (500 ms)
            moveTimer.Tick += MoveTimer_Tick;
            moveTimer.Start(); // เริ่ม Timer
        }

        private void InitializeMaze()
        {
            DisplayMaze(); // แสดงเขาวงกตตอนเริ่มต้น
        }

        private void MoveTimer_Tick(object sender, EventArgs e)
        {
            CheckPossibleMoves(); // ตรวจสอบการเคลื่อนที่
        }

        private void DisplayMaze()
        {
            Bitmap bitmap = new Bitmap(maze.GetLength(1) * 20, maze.GetLength(0) * 20);
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    Color color;
                    switch (maze[i, j])
                    {
                        case '1': color = Color.Black; break;  // กำแพง
                        case '0': color = Color.White; break;  // ทางเดิน
                        case 'E': color = Color.Green; break;  // เป้าหมาย
                        case 'S': color = Color.DarkRed; break; // ผู้เล่น
                        case '.': color = Color.LightPink; break; // ทางเดินที่ผ่านแล้ว
                        default: color = Color.White; break; // ค่าสำรอง
                    }
                    bitmap.SetPixel(j * 20, i * 20, color);
                }
            }
            //mazePictureBox.Image = bitmap; // แสดงภาพใน PictureBox
        }

        private void CheckPossibleMoves()
        {
            // ลำดับทิศทาง: ขึ้น, ลง, ซ้าย, ขวา
            int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
            bool moved = false;

            // เก็บตำแหน่งปัจจุบันใน stack ก่อนเคลื่อนที่
            positionHistory.Push((playerX, playerY));

            // ใช้ for loop แทน foreach
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int newX = playerX + directions[i, 0];
                int newY = playerY + directions[i, 1];

                if (newX >= 0 && newX < maze.GetLength(0) && newY >= 0 && newY < maze.GetLength(1))
                {
                    if (maze[newX, newY] == '0' || maze[newX, newY] == 'E')
                    {
                        // เปลี่ยน S เป็น .
                        maze[playerX, playerY] = '.';

                        // อัปเดตตำแหน่งผู้เล่น
                        playerX = newX;
                        playerY = newY;
                        maze[playerX, playerY] = 'S'; // อัปเดตตำแหน่งใหม่ของ S

                        moved = true;
                        break; // ออกจาก loop ถ้าเคลื่อนที่ได้
                    }
                }
            }

            if (moved)
            {
                DisplayMaze(); // แสดงเขาวงกตหลังการเคลื่อนที่
            }
        }


        private void UndoMove()
        {
            if (positionHistory.Count > 0)
            {
                // ดึงตำแหน่งก่อนหน้าจาก stack
                var lastPosition = positionHistory.Pop();

                // เปลี่ยนตำแหน่งปัจจุบันเป็น .
                maze[playerX, playerY] = '.';

                // อัปเดตตำแหน่งผู้เล่น
                playerX = lastPosition.Item1;
                playerY = lastPosition.Item2;
                maze[playerX, playerY] = 'S'; // อัปเดตตำแหน่งใหม่ของ S

                DisplayMaze(); // แสดงเขาวงกตหลังการ undo
            }
        }

        // เรียก UndoMove() จากปุ่มหรือ event ใด ๆ เพื่อทำการย้อนกลับตำแหน่ง
    }
}
