using System;
using System.Drawing;
using System.Windows.Forms;

public class Mazes : Form
{
    private static readonly int SPACE = -1;
    private static readonly int BLOCK = -9;
    private static int[,] map = new int[10, 10];
    private static Pos target;
    private Pos currentPos;  // เก็บตำแหน่งหัวปัจจุบัน
    private bool foundPath = false;  // สำหรับการตรวจสอบว่าพบเส้นทางหรือไม่

    private class Pos
    {
        public int row, col;
        public Pos(int r, int c) { row = r; col = c; }
    }

    public Mazes()
    {
        this.DoubleBuffered = true;
        InitializeGrid();
        target = new Pos(0, map.GetLength(1) - 1);
        FindPath(new Pos(0, 0), target);
        StartWalking();
    }

    private void InitializeGrid()
    {
        // สร้างแผนที่เริ่มต้นแบบสุ่ม
        Random rand = new Random();
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = rand.NextDouble() < 0.2 ? BLOCK : SPACE;
            }
        }

        this.Size = new Size(420, 440);
    }

    private void FindPath(Pos source, Pos target)
    {
        map[source.row, source.col] = 0;
        map[target.row, target.col] = SPACE;

        // เริ่มต้นการค้นหาเส้นทาง
        DFS(source.row, source.col, 1);
    }

    private void DFS(int row, int col, int steps)
    {
        if (foundPath || row < 0 || row >= map.GetLength(0) || col < 0 || col >= map.GetLength(1) || map[row, col] != SPACE)
            return;

        // ทำเครื่องหมายตำแหน่งที่เดินผ่าน
        map[row, col] = steps;

        // ตรวจสอบว่าถึงเป้าหมายหรือไม่
        if (row == target.row && col == target.col)
        {
            foundPath = true;  // พบเส้นทาง
            return;
        }

        // ขยายการค้นหาในทิศทางต่างๆ
        DFS(row + 1, col, steps + 1);
        DFS(row - 1, col, steps + 1);
        DFS(row, col + 1, steps + 1);
        DFS(row, col - 1, steps + 1);

        // ถ้าไม่พบเส้นทางให้กลับไปที่ตำแหน่งเดิม
        if (!foundPath)
            map[row, col] = SPACE;  // คืนค่าตำแหน่งที่เป็นช่องว่าง
    }

    private void StartWalking()
    {
        Timer timer = new Timer();
        timer.Interval = 500;  // ตั้งเวลาสำหรับแต่ละก้าว (500ms)
        timer.Tick += (sender, e) =>
        {
            if (foundPath)
            {
                // ดำเนินการแสดงหัวในเส้นทางที่เดิน
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        if (map[i, j] == 0)
                        {
                            currentPos = new Pos(i, j);  // หาตำแหน่งหัว
                            break;
                        }
                    }
                }
                Invalidate();  // วาดใหม่หลังจากเคลื่อนที่
            }
        };

        timer.Start();
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
                if (map[i, j] == BLOCK)
                    brush = Brushes.Black;
                else if (i == currentPos.row && j == currentPos.col)
                    brush = Brushes.Green;  // สีเข้มสำหรับหัวที่กำลังเดิน
                else if (map[i, j] >= 0)
                    brush = Brushes.LightGreen;  // สีเส้นทางที่เดินผ่านแล้ว
                else
                    brush = Brushes.White;  // ช่องว่างที่ยังไม่ได้เดิน

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
}
