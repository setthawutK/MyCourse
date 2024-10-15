using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

public class Mazes : Form
{
    private static char[,] map = new char[,]
    {
        {'1', 'E', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'},
        {'1', '1', '1', '1', '1', '1', '1', '1', '0', '1', '0', '1', '1'},
        {'1', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', 'S', '1'},
        {'1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'}
    };

    private static Stack<Pos> stack = new Stack<Pos>();
    private Pos currentPos;  // เก็บตำแหน่งหัวปัจจุบัน
    private List<Pos> path = new List<Pos>(); // เก็บเส้นทางที่เดินผ่านมา

    private class Pos
    {
        public int row, col;
        public Pos(int r, int c) { row = r; col = c; }
    }

    public Mazes()
    {
        this.DoubleBuffered = true;
        InitializeGrid();
        StartWalking();
    }

    private void InitializeGrid()
    {
        this.Size = new Size(520, 440);
    }

    private void StartWalking()
{
    // หาตำแหน่งเริ่มต้น
    for (int i = 0; i < map.GetLength(0); i++)
    {
        for (int j = 0; j < map.GetLength(1); j++)
        {
            if (map[i, j] == 'S') // ถ้าพบ S
            {
                currentPos = new Pos(i, j);
                stack.Push(currentPos); // เริ่มต้นที่ S
                break;
            }
        }
    }

    Timer timer = new Timer();
    timer.Interval = 500;  // ตั้งเวลาสำหรับแต่ละก้าว (500ms)
    timer.Tick += (sender, e) =>
    {
        if (stack.Count > 0)
        {
            // อัปเดตตำแหน่งปัจจุบัน
            Pos previousPos = currentPos; // เก็บตำแหน่งก่อนหน้า
            currentPos = stack.Pop(); // เอาตำแหน่งจาก stack ออก

            // ทับตำแหน่งก่อนหน้าเป็น . ถ้าไม่ใช่ E
            if (map[previousPos.row, previousPos.col] != 'E')
            {
                map[previousPos.row, previousPos.col] = '.'; // ทำเครื่องหมายเส้นทางที่ผ่านแล้ว
            }

            // เช็คว่าถึง E หรือไม่
            if (map[currentPos.row, currentPos.col] == 'E')
            {
                ((Timer)sender).Stop();  // หยุดเมื่อถึงเป้าหมาย
                map[currentPos.row, currentPos.col] = 'S'; // ทับ S ที่ E
            }
            else
            {
                Expand(currentPos.row + 1, currentPos.col);
                Expand(currentPos.row - 1, currentPos.col);
                Expand(currentPos.row, currentPos.col + 1);
                Expand(currentPos.row, currentPos.col - 1);
                
                map[currentPos.row, currentPos.col] = 'S';  // ทับ S ที่ตำแหน่งปัจจุบัน

                // ตรวจสอบหากไม่มีการเดินต่อไปได้ ให้วิ่งกลับ
                if (!CanContinue())
                {
                    stack.Push(previousPos); // กลับไปที่ตำแหน่งก่อนหน้า
                }
            }

            Invalidate();  // วาดใหม่หลังจากเดินแต่ละก้าว
        }
    };

    timer.Start();
}

    private void Expand(int r, int c)
    {
        if (r < 0 || r >= map.GetLength(0) || c < 0 || c >= map.GetLength(1) || (map[r, c] != '0' && map[r, c] != 'E'))
            return;

        // ใช้ isconnect เพื่อเช็คความเชื่อมต่อ
        if (isconnect(new Pos(currentPos.row, currentPos.col), new Pos(r, c)))
        {
            stack.Push(new Pos(r, c)); // เพิ่มตำแหน่งใน stack
        }
    }

    private bool isconnect(Pos a, Pos b)
    {
        int i = a.row, j = a.col;
        for (int m = -1; m <= 1; m++)
        {
            for (int n = -1; n <= 1; n++)
            {
                if (Math.Abs(m) + Math.Abs(n) == 1) // เช็คเฉพาะตำแหน่งด้านข้าง
                {
                    if (i + m == b.row && j + n == b.col)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool CanContinue()
    {
        // เช็คว่ามีการเชื่อมต่อกับตำแหน่งที่ยังไม่ถูกเดินผ่าน
        for (int r = currentPos.row - 1; r <= currentPos.row + 1; r++)
        {
            for (int c = currentPos.col - 1; c <= currentPos.col + 1; c++)
            {
                if (isconnect(currentPos, new Pos(r, c)))
                {
                    if (map[r, c] == '0' || map[r, c] == 'E')
                        return true;
                }
            }
        }
        return false;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // วาดกริด
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Brush brush;
                if (map[i, j] == '1') // กำแพง
                    brush = Brushes.Black;
                else if (map[i, j] == 'S') // ตำแหน่งเริ่มต้น
                    brush = Brushes.Cyan;
                else if (map[i, j] == 'E') // จุดหมาย
                    brush = Brushes.Green;
                else if (map[i, j] == '.')
                    brush = Brushes.LightCyan; // เส้นทางที่เดินผ่านแล้ว
                else
                    brush = Brushes.White; // ช่องว่างที่ยังไม่ได้เดิน

                g.FillRectangle(brush, j * 40, i * 40, 40, 40);
                g.DrawRectangle(Pens.Black, j * 40, i * 40, 40, 40);
            }
        }
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Mazes());
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Mazes
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Mazes";
            this.ResumeLayout(false);

    }
}
