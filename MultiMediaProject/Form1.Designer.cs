namespace MultiMediaProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            trackBar1 = new TrackBar();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            button8 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ImageInfo = new Button();
            button9 = new Button();
            button10 = new Button();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1426, 12);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(214, 75);
            button1.TabIndex = 0;
            button1.Text = "UploadImage";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(7, 8);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(697, 597);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.DragDrop += pictureBox1_DragDrop;
            pictureBox1.DragEnter += pictureBox1_DragEnter;
            // 
            // button2
            // 
            button2.Location = new Point(1426, 107);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(214, 73);
            button2.TabIndex = 2;
            button2.Text = "RGB_To_HSV";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1150, 12);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(214, 77);
            button4.TabIndex = 4;
            button4.Text = "RGB_To_YCBCR";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1150, 223);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(214, 68);
            button3.TabIndex = 5;
            button3.Text = "RGB_To_LAB";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1150, 107);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(214, 73);
            button5.TabIndex = 6;
            button5.Text = "RGB_To_YUV";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(1426, 223);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(214, 63);
            button6.TabIndex = 7;
            button6.Text = "RGB_To_CMYK";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(1170, 437);
            trackBar1.Margin = new Padding(4, 5, 4, 5);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = -100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(204, 69);
            trackBar1.TabIndex = 9;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(724, 8);
            pictureBox2.Margin = new Padding(4, 5, 4, 5);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(229, 148);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(724, 223);
            pictureBox3.Margin = new Padding(4, 5, 4, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(229, 153);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(724, 437);
            pictureBox4.Margin = new Padding(4, 5, 4, 5);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(229, 153);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // button8
            // 
            button8.Location = new Point(1150, 323);
            button8.Margin = new Padding(4, 5, 4, 5);
            button8.Name = "button8";
            button8.Size = new Size(214, 70);
            button8.TabIndex = 13;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(11, 642);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 280);
            panel1.TabIndex = 14;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.Location = new Point(340, 642);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 280);
            panel2.TabIndex = 15;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.Location = new Point(660, 642);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 280);
            panel3.TabIndex = 16;
            panel3.Paint += panel3_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1019, 642);
            label1.Name = "label1";
            label1.Size = new Size(59, 25);
            label1.TabIndex = 17;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1019, 713);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 18;
            label2.Text = "label2";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1019, 782);
            label3.Name = "label3";
            label3.Size = new Size(59, 25);
            label3.TabIndex = 19;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // ImageInfo
            // 
            ImageInfo.Location = new Point(1426, 610);
            ImageInfo.Name = "ImageInfo";
            ImageInfo.Size = new Size(214, 57);
            ImageInfo.TabIndex = 20;
            ImageInfo.Text = "ImageInfo";
            ImageInfo.UseVisualStyleBackColor = true;
            ImageInfo.Click += button9_Click;
            // 
            // button9
            // 
            button9.Location = new Point(1426, 697);
            button9.Name = "button9";
            button9.Size = new Size(214, 57);
            button9.TabIndex = 21;
            button9.Text = "button9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click_1;
            // 
            // button10
            // 
            button10.Location = new Point(1426, 782);
            button10.Name = "button10";
            button10.Size = new Size(214, 57);
            button10.TabIndex = 22;
            button10.Text = "button10";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1416, 352);
            checkBox1.Margin = new Padding(4, 5, 4, 5);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(141, 29);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "checkBoxRed";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(1416, 400);
            checkBox2.Margin = new Padding(4, 5, 4, 5);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(157, 29);
            checkBox2.TabIndex = 24;
            checkBox2.Text = "checkBoxGreen";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(1416, 450);
            checkBox3.Margin = new Padding(4, 5, 4, 5);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(144, 29);
            checkBox3.TabIndex = 25;
            checkBox3.Text = "checkBoxBlue";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // button7
            // 
            button7.Location = new Point(1426, 866);
            button7.Name = "button7";
            button7.Size = new Size(214, 57);
            button7.TabIndex = 26;
            button7.Text = "button7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1831, 935);
            Controls.Add(button7);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(ImageInfo);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button8);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(trackBar1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button4;
        private Button button3;
        private Button button5;
        private Button button6;
        private TrackBar trackBar1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Button button8;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button ImageInfo;
        private Button button9;
        private Button button10;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private Button button7;
    }
}
