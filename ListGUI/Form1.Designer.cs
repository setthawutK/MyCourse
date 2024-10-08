namespace ListGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addNameTextBox1 = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.nameListTextBox1 = new System.Windows.Forms.TextBox();
            this.countNameLabel = new System.Windows.Forms.Label();
            this.displayNameListButton = new System.Windows.Forms.Button();
            this.containsButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.indexButton = new System.Windows.Forms.Button();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addNameTextBox1
            // 
            this.addNameTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.addNameTextBox1.Location = new System.Drawing.Point(76, 84);
            this.addNameTextBox1.Name = "addNameTextBox1";
            this.addNameTextBox1.Size = new System.Drawing.Size(289, 20);
            this.addNameTextBox1.TabIndex = 0;
            this.addNameTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.addNameTextBox1.TextChanged += new System.EventHandler(this.addNameTextBox1_TextChanged);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Teal;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.addButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addButton.Location = new System.Drawing.Point(392, 76);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(89, 34);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "เพิ่มชื่อ";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // nameListTextBox1
            // 
            this.nameListTextBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.nameListTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.nameListTextBox1.Location = new System.Drawing.Point(76, 205);
            this.nameListTextBox1.Multiline = true;
            this.nameListTextBox1.Name = "nameListTextBox1";
            this.nameListTextBox1.Size = new System.Drawing.Size(502, 228);
            this.nameListTextBox1.TabIndex = 2;
            this.nameListTextBox1.TextChanged += new System.EventHandler(this.nameListTextBox1_TextChanged);
            // 
            // countNameLabel
            // 
            this.countNameLabel.AutoSize = true;
            this.countNameLabel.Font = new System.Drawing.Font("Cordia New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.countNameLabel.ForeColor = System.Drawing.Color.Azure;
            this.countNameLabel.Location = new System.Drawing.Point(262, 447);
            this.countNameLabel.Name = "countNameLabel";
            this.countNameLabel.Size = new System.Drawing.Size(112, 37);
            this.countNameLabel.TabIndex = 3;
            this.countNameLabel.Text = "จำนวน 0 คน";
            // 
            // displayNameListButton
            // 
            this.displayNameListButton.BackColor = System.Drawing.Color.Teal;
            this.displayNameListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.displayNameListButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.displayNameListButton.Location = new System.Drawing.Point(626, 288);
            this.displayNameListButton.Name = "displayNameListButton";
            this.displayNameListButton.Size = new System.Drawing.Size(77, 64);
            this.displayNameListButton.TabIndex = 4;
            this.displayNameListButton.Text = "แสดงรายชื่อทั้งหมด";
            this.displayNameListButton.UseVisualStyleBackColor = false;
            this.displayNameListButton.Click += new System.EventHandler(this.displayNameListButton_Click);
            // 
            // containsButton
            // 
            this.containsButton.AllowDrop = true;
            this.containsButton.BackColor = System.Drawing.Color.Teal;
            this.containsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.containsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.containsButton.Location = new System.Drawing.Point(507, 76);
            this.containsButton.Name = "containsButton";
            this.containsButton.Size = new System.Drawing.Size(89, 34);
            this.containsButton.TabIndex = 5;
            this.containsButton.Text = "ค้นหาชื่อ";
            this.containsButton.UseVisualStyleBackColor = false;
            this.containsButton.Click += new System.EventHandler(this.containsButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.Color.Teal;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.removeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.removeButton.Location = new System.Drawing.Point(626, 76);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(89, 34);
            this.removeButton.TabIndex = 6;
            this.removeButton.Text = "ลบชื่อ";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(76, 135);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(39, 20);
            this.indexTextBox.TabIndex = 7;
            this.indexTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // indexButton
            // 
            this.indexButton.BackColor = System.Drawing.Color.Teal;
            this.indexButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.indexButton.ForeColor = System.Drawing.SystemColors.Control;
            this.indexButton.Location = new System.Drawing.Point(137, 129);
            this.indexButton.Name = "indexButton";
            this.indexButton.Size = new System.Drawing.Size(133, 31);
            this.indexButton.TabIndex = 8;
            this.indexButton.Text = "ค้นหาชื่อจากลำดับที่";
            this.indexButton.UseVisualStyleBackColor = false;
            this.indexButton.Click += new System.EventHandler(this.indexButton_Click);
            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(307, 135);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(289, 20);
            this.displayNameTextBox.TabIndex = 9;
            this.displayNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // renameButton
            // 
            this.renameButton.BackColor = System.Drawing.Color.Teal;
            this.renameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.renameButton.ForeColor = System.Drawing.SystemColors.Control;
            this.renameButton.Location = new System.Drawing.Point(626, 130);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(89, 31);
            this.renameButton.TabIndex = 10;
            this.renameButton.Text = "แก้ไขชื่อ";
            this.renameButton.UseVisualStyleBackColor = false;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(63)))), ((int)(((byte)(77)))));
            this.ClientSize = new System.Drawing.Size(763, 493);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.displayNameTextBox);
            this.Controls.Add(this.indexButton);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.containsButton);
            this.Controls.Add(this.displayNameListButton);
            this.Controls.Add(this.countNameLabel);
            this.Controls.Add(this.nameListTextBox1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addNameTextBox1);
            this.Name = "Form1";
            this.Text = "Student Infomation Management";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox nameListTextBox;
        private System.Windows.Forms.TextBox addNameTextBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox nameListTextBox1;
        private System.Windows.Forms.Label countNameLabel;
        private System.Windows.Forms.Button displayNameListButton;
        private System.Windows.Forms.Button containsButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.Button indexButton;
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.Button renameButton;
    }
}

