using Lists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ListGUI
{
    public partial class Form1 : Form
    {
        List x = new ArrayList(5);

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            updateCountNameLabel();         
        }


        private void _TextChanged(object sender, EventArgs e)
        {

        }

      

        private void addButton_Click(object sender, EventArgs e)
        {
            if (addNameTextBox1.Text != "")
            {
                x.add(addNameTextBox1.Text);                
                addNameTextBox1.Clear(); 
                nameListTextBox1.Clear();
                updateCountNameLabel();
                //displayNameListButton_Click(null, null);
                //MessageBox.Show("เพิ่มชื่อเรียบร้อยแล้ว");
                return;
            }
            MessageBox.Show("กรุณากรอกข้อมูล");
        }

        private void addNameTextBox1_TextChanged(object sender, EventArgs e)
        {
                           

        }

        private void updateCountNameLabel()
        {
            int Sizes = x.size();
            countNameLabel.Text = "จำนวน " + Sizes.ToString() + " คน";
        }

        private void displayNameListButton_Click(object sender, EventArgs e)
        {
            nameListTextBox1.Clear();
            if (x.isEmpty() == true)
            {
                nameListTextBox1.AppendText("                                                                 ไม่มีรายชื่อของนักศึกษา" + Environment.NewLine);
                return;
            }               
            nameListTextBox1.AppendText("                                                                 รายชื่อของนักศึกษาทั้งหมด" + Environment.NewLine);

            for (int i = 0; i < x.size(); i++)
            {
                int index = i + 1;
                nameListTextBox1.AppendText(index + ". " + x.get(i) + Environment.NewLine);
                
            }

            //version ไม่มีเงื่อนไขเยอะ
            //nameListTextBox1.Clear();
            // for (int i = 0; i < x.size(); i++)
            //{
            //    int index = i + 1;
            //    nameListTextBox1.AppendText(index + ". " + x.get(i) + Environment.NewLine);

            //}
        }

        private void nameListTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void containsButton_Click(object sender, EventArgs e)
        {
            if ( addNameTextBox1.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล"); return;
            }
            if ( x.contains(addNameTextBox1.Text) == true)
            {
                MessageBox.Show("ค้นพบชื่อ " + addNameTextBox1.Text);
                //addNameTextBox1.Clear();
                return;

            }
            MessageBox.Show("ไม่พบชื่อดังกล่าว");

            //Version ไม่เยอะ
            //if ( x.contains(addNameTextBox1.Text) == true)
            //{
                //MessageBox.Show("ค้นพบชื่อ " + addNameTextBox1.Text);           
                //return;

            //}
            //MessageBox.Show("ไม่พบชื่อดังกล่าว");

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (addNameTextBox1.Text != "")
            {
                x.remove(addNameTextBox1.Text);
                addNameTextBox1.Clear(); nameListTextBox1.Clear();
                updateCountNameLabel();
                //displayNameListButton_Click(null, null);
                return;

            }              
            MessageBox.Show("กรุณากรอกข้อมูล");
        }

        private void indexButton_Click(object sender, EventArgs e)
        {
            if ( indexTextBox.Text != "")
            {

                int i;
                if ( int.TryParse(indexTextBox.Text, out i ) && i > 0)
                {
                    if ( i <= x.size())
                    {
                        displayNameTextBox.Text = x.get(i - 1) + ""; return;
                    }
                    MessageBox.Show("ไม่พบข้อมูล");
                    displayNameTextBox.Clear(); return;
                    
                }
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง");
                displayNameTextBox.Clear(); return;


            }
            MessageBox.Show("กรุณากรอกข้อมูล");
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            

            if ( displayNameTextBox.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่ต้องการเปลี่ยน"); return;
            }
            if (indexTextBox.Text != "")
            {
                int i;
                if (int.TryParse(indexTextBox.Text, out i) && i > 0 )
                {
                    if (x.get(i - 1) != null)
                    {
                        x.set(i - 1, displayNameTextBox.Text);
                        nameListTextBox1.Clear();
                        MessageBox.Show("แก้ไขข้อมูลแล้ว"); return;
                    }
                    MessageBox.Show("ไม่พบข้อมูล");
                    displayNameTextBox.Clear(); return;
                }
                MessageBox.Show("กรุณากรอกข้อมูลลำดับที่ให้ถูกต้อง"); return;




            }
            MessageBox.Show("กรุณากรอกข้อมูลลำดับที่");


        }
    }
}
