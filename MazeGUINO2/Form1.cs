using Stacks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGUINO2
{
    public partial class Form1 : Form
    {
        private static char[,] maze1 = new char[,] //ไม่ต้องลบไว้เปลี่ยน maze
        {
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
            { '1', 'E', '1', '1', '1', '0', '1', '1', '0', '0', '1'},
            { '1', '0', '1', '1', '1', '0', '1', '1', '0', '1', '1'},
            { '1', '0', '1', '0', '0', '0', '0', '0', '0', 'S', '1'},
            { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
        };

        private static char[,] maze = new char[,]
             {
                { '1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
                { '1', '0', '1', '1', '0', '0', '1', '0', '1', '0', '1'},
                { '1', '0', '1', '0', '0', '1', '0', '0', '1', '0', '1'},
                { '1', '0', '1', '1', '0', '0', '1', '1', '0', '0', '1'},
                { '1', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1'},
                { '1', '0', '1', '0', '1', '0', '0', '0', '1', 'S', '1'},
                { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
            };

        private Pos start;

        public Form1()
        {
            InitializeComponent();
            start = FindStart();
            walkingPath(start);
        }

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

        //private int[] dRow = { -1, 1, 0, 0 };
        //private int[] dCol = { 0, 0, -1, 1 };
        private int[] dRow = { 0, 0, 1, -1 };
        private int[] dCol = { 1,-1, 0,  0 };


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
                    return true;
            }
            return false;
        }

        private async void walkingPath(Pos start)
        {
            Stack path = new ArrayStack(1);
            Stack stack = new ArrayStack(1); 


            Pos current = start;
            int i = current.row;
            int j = current.col;

            while (maze[i, j] != 'E')
            {

                maze[i, j] = 'S';
                
                path.push(new Pos(i, j)); 


                DisplayMaze();
                await Task.Delay(300); 


                maze[i, j] = '.'; ;
                // ตรวจทางเดินจาก ขึ้น ลง ซ้าย ขวา ตามลำดับ
                for (int k = 0; k < 4; k++)
                {
                    int newRow = i + dRow[k];
                    int newCol = j + dCol[k];
                    if (maze[newRow, newCol] == '0' || maze[newRow, newCol] == 'E')
                        stack.push(new Pos(newRow, newCol));
                      
                }
    
                if (!stack.isEmpty())
                {
                    Pos update = (Pos)stack.pop();
                    i = update.row;
                    j = update.col;


                }
                else
                {
                    MessageBox.Show("Cannot exit!");
                    break;
                }          
                while (!path.isEmpty())
                {
                    Pos lastPos = (Pos)path.peek();
                    

                    if (IsConnect(new Pos(i, j), lastPos)== true)
                    {
                  
                        break; 
                    }

                    Pos back = (Pos)path.pop(); 

                    maze[back.row, back.col] = 'S'; 
                    DisplayMaze();
                    await Task.Delay(300);
                    maze[lastPos.row, lastPos.col] = '.';

                    //maze[lastPos.row, lastPos.col] = '.'; 
                }

            }
            if (maze[i, j] == 'E') 
            {
                maze[i, j] = 'S'; 
                DisplayMaze();
                await Task.Delay(300); 
                MessageBox.Show("Found!"); 
            }
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
                            color = Color.Red; // จุดเริ่มต้น
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

                    g.FillRectangle(new SolidBrush(color), j * 40, i * 40, 40, 40); 
                }
            }

            pictureBox1.Image = img; 
        }
      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
