using Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            //x = new ArrayCollection(5); ต้องการ prelocation เร็วกว่า 
            // x = new LinkedCollection(); waste memory 
            //x = new LinkedHeaderCollection();
            //x = new LinkedSet();
            //x = new ArraySet(5);
            updateLabel1();
        }

       // Collection x = new LinkedCollection();

        Collection x = new LinkedHeaderCollection();
        // public Collection x;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (x.size() == 0 || x.contains(textBox3.Text) == false)
            {
                MessageBox.Show("ไม่มีรายการให้ลบ"); return;
            }     
            if (textBox3.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อ"); return;
            }
            x.remove(textBox3.Text);
            updateLabel1();
            textBox3.Text = string.Empty;
            MessageBox.Show("ลบชื่อเรียบร้อยแล้ว");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อ"); return;
            }
            if(x.contains(textBox2.Text) == true)
            {
                MessageBox.Show("พบชื่อ " + textBox2.Text);
                textBox2.Text = string.Empty; return;
            }
            MessageBox.Show("ไม่พบชื่อดังกล่าว");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
            if(textBox1.Text != "")
            {
                if (!x.contains(textBox1.Text))
                {
                    x.add(textBox1.Text);
                    updateLabel1();
                    textBox1.Text = string.Empty;
                    MessageBox.Show("เพิ่มชื่อเรียบร้อยแล้ว"); return;
                }
                MessageBox.Show("มีชื่อนี้อยู่แล้ว"); return;
            }
            MessageBox.Show("กรุณากรอกชื่อ");


        }
        private void updateLabel1()
        {
            int Sizes = x.size(); 
            label1.Text = "จำนวน " + Sizes.ToString() + " คน";
        }
    }
}
