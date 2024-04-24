namespace LAB3_2D_PICTURES
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            button13 = new Button();
            label2 = new Label();
            label3 = new Label();
            button14 = new Button();
            button15 = new Button();
            label4 = new Label();
            button16 = new Button();
            button17 = new Button();
            button18 = new Button();
            button19 = new Button();
            button20 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(520, 426);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(552, 12);
            button1.Name = "button1";
            button1.Size = new Size(226, 30);
            button1.TabIndex = 1;
            button1.Text = "Нарисовать оси";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(552, 48);
            button2.Name = "button2";
            button2.Size = new Size(112, 40);
            button2.TabIndex = 2;
            button2.Text = "Нарисовать квадрат";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(552, 94);
            button3.Name = "button3";
            button3.Size = new Size(226, 30);
            button3.TabIndex = 3;
            button3.Text = "Очистить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(582, 127);
            label1.Name = "label1";
            label1.Size = new Size(161, 29);
            label1.TabIndex = 4;
            label1.Text = "Сдвиг";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Location = new Point(553, 159);
            button4.Name = "button4";
            button4.Size = new Size(133, 30);
            button4.TabIndex = 5;
            button4.Text = "По оси OX вправо";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(553, 195);
            button5.Name = "button5";
            button5.Size = new Size(133, 30);
            button5.TabIndex = 6;
            button5.Text = "По оси OX влево";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(553, 267);
            button6.Name = "button6";
            button6.Size = new Size(133, 30);
            button6.TabIndex = 7;
            button6.Text = "По оси OY вверх";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(553, 231);
            button7.Name = "button7";
            button7.Size = new Size(133, 30);
            button7.TabIndex = 8;
            button7.Text = "По оси OY вниз";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(692, 159);
            button8.Name = "button8";
            button8.Size = new Size(87, 30);
            button8.TabIndex = 9;
            button8.Text = "Старт";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick_1;
            // 
            // button9
            // 
            button9.Location = new Point(670, 48);
            button9.Name = "button9";
            button9.Size = new Size(108, 40);
            button9.TabIndex = 10;
            button9.Text = "Нарисовать фигуру";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(692, 195);
            button10.Name = "button10";
            button10.Size = new Size(87, 30);
            button10.TabIndex = 11;
            button10.Text = "Старт";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.Location = new Point(692, 231);
            button11.Name = "button11";
            button11.Size = new Size(87, 30);
            button11.TabIndex = 12;
            button11.Text = "Старт";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.Location = new Point(692, 267);
            button12.Name = "button12";
            button12.Size = new Size(87, 30);
            button12.TabIndex = 13;
            button12.Text = "Старт";
            button12.UseVisualStyleBackColor = true;
            button12.Click += button12_Click;
            // 
            // button13
            // 
            button13.Location = new Point(553, 333);
            button13.Name = "button13";
            button13.Size = new Size(100, 23);
            button13.TabIndex = 14;
            button13.Text = "Отразить по X";
            button13.UseVisualStyleBackColor = true;
            button13.Click += button13_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(553, 302);
            label2.Name = "label2";
            label2.Size = new Size(98, 27);
            label2.TabIndex = 16;
            label2.Text = "Отражение";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(657, 303);
            label3.Name = "label3";
            label3.Size = new Size(122, 27);
            label3.TabIndex = 17;
            label3.Text = "Масштабирование";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button14
            // 
            button14.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button14.Location = new Point(659, 333);
            button14.Name = "button14";
            button14.Size = new Size(58, 23);
            button14.TabIndex = 18;
            button14.Text = "Умн";
            button14.UseVisualStyleBackColor = true;
            button14.Click += button14_Click;
            // 
            // button15
            // 
            button15.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button15.Location = new Point(720, 333);
            button15.Name = "button15";
            button15.Size = new Size(58, 23);
            button15.TabIndex = 19;
            button15.Text = "Разд";
            button15.UseVisualStyleBackColor = true;
            button15.Click += button15_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(594, 359);
            label4.Name = "label4";
            label4.Size = new Size(133, 27);
            label4.TabIndex = 20;
            label4.Text = "Поворот";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button16
            // 
            button16.Location = new Point(553, 391);
            button16.Name = "button16";
            button16.Size = new Size(111, 23);
            button16.TabIndex = 21;
            button16.Text = "Поворот на 15*";
            button16.UseVisualStyleBackColor = true;
            button16.Click += button16_Click;
            // 
            // button17
            // 
            button17.Location = new Point(667, 391);
            button17.Name = "button17";
            button17.Size = new Size(111, 23);
            button17.TabIndex = 22;
            button17.Text = "Поворот на -15*";
            button17.UseVisualStyleBackColor = true;
            button17.Click += button17_Click;
            // 
            // button18
            // 
            button18.Location = new Point(797, 48);
            button18.Name = "button18";
            button18.Size = new Size(238, 30);
            button18.TabIndex = 23;
            button18.Text = "Нарисовать лодку и чайку";
            button18.UseVisualStyleBackColor = true;
            button18.Click += button18_Click;
            // 
            // button19
            // 
            button19.Location = new Point(797, 12);
            button19.Name = "button19";
            button19.Size = new Size(238, 30);
            button19.TabIndex = 24;
            button19.Text = "Нарисовать закат";
            button19.UseVisualStyleBackColor = true;
            button19.Click += button19_Click;
            // 
            // button20
            // 
            button20.Location = new Point(797, 84);
            button20.Name = "button20";
            button20.Size = new Size(238, 30);
            button20.TabIndex = 25;
            button20.Text = "Имитировать движение";
            button20.UseVisualStyleBackColor = true;
            button20.Click += button20_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 448);
            Controls.Add(button20);
            Controls.Add(button19);
            Controls.Add(button18);
            Controls.Add(button17);
            Controls.Add(button16);
            Controls.Add(label4);
            Controls.Add(button15);
            Controls.Add(button14);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button13);
            Controls.Add(button12);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private System.Windows.Forms.Timer timer1;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Label label2;
        private Label label3;
        private Button button14;
        private Button button15;
        private Label label4;
        private Button button16;
        private Button button17;
        private Button button18;
        private Button button19;
        private Button button20;
    }
}
