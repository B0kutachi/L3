namespace lab2
{
    partial class MainForm
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
            panel1 = new Panel();
            radioButton1 = new RadioButton();
            CDA_THICC_button = new RadioButton();
            fill_color_button = new Button();
            color_button = new Button();
            use_button = new Button();
            Fill_radio = new RadioButton();
            Clear_button = new Button();
            CDA_radio = new RadioButton();
            pictureBox1 = new PictureBox();
            colorDialog1 = new ColorDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(CDA_THICC_button);
            panel1.Controls.Add(fill_color_button);
            panel1.Controls.Add(color_button);
            panel1.Controls.Add(use_button);
            panel1.Controls.Add(Fill_radio);
            panel1.Controls.Add(Clear_button);
            panel1.Controls.Add(CDA_radio);
            panel1.Location = new Point(471, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 248);
            panel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(29, 89);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(170, 19);
            radioButton1.TabIndex = 7;
            radioButton1.TabStop = true;
            radioButton1.Text = "Построчный алг. заливки ";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // CDA_THICC_button
            // 
            CDA_THICC_button.AutoSize = true;
            CDA_THICC_button.Location = new Point(29, 65);
            CDA_THICC_button.Margin = new Padding(3, 2, 3, 2);
            CDA_THICC_button.Name = "CDA_THICC_button";
            CDA_THICC_button.Size = new Size(167, 19);
            CDA_THICC_button.TabIndex = 6;
            CDA_THICC_button.TabStop = true;
            CDA_THICC_button.Text = "Обычный Цда(ТОЛСТЫЙ)";
            CDA_THICC_button.UseVisualStyleBackColor = true;
            // 
            // fill_color_button
            // 
            fill_color_button.Location = new Point(117, 170);
            fill_color_button.Margin = new Padding(3, 2, 3, 2);
            fill_color_button.Name = "fill_color_button";
            fill_color_button.Size = new Size(82, 38);
            fill_color_button.TabIndex = 5;
            fill_color_button.Text = "Цвет заливки";
            fill_color_button.UseVisualStyleBackColor = true;
            fill_color_button.Click += fill_color_button_Click;
            // 
            // color_button
            // 
            color_button.Location = new Point(22, 170);
            color_button.Margin = new Padding(3, 2, 3, 2);
            color_button.Name = "color_button";
            color_button.Size = new Size(82, 38);
            color_button.TabIndex = 4;
            color_button.Text = "Цвет Линии";
            color_button.UseVisualStyleBackColor = true;
            color_button.Click += color_button_Click;
            // 
            // use_button
            // 
            use_button.Location = new Point(22, 212);
            use_button.Margin = new Padding(3, 2, 3, 2);
            use_button.Name = "use_button";
            use_button.Size = new Size(82, 22);
            use_button.TabIndex = 3;
            use_button.Text = "Применить";
            use_button.UseVisualStyleBackColor = true;
            use_button.Click += use_button_Click;
            // 
            // Fill_radio
            // 
            Fill_radio.AutoSize = true;
            Fill_radio.Location = new Point(29, 43);
            Fill_radio.Margin = new Padding(3, 2, 3, 2);
            Fill_radio.Name = "Fill_radio";
            Fill_radio.Size = new Size(70, 19);
            Fill_radio.TabIndex = 2;
            Fill_radio.TabStop = true;
            Fill_radio.Text = "Заливка";
            Fill_radio.UseVisualStyleBackColor = true;
            // 
            // Clear_button
            // 
            Clear_button.Location = new Point(117, 212);
            Clear_button.Margin = new Padding(3, 2, 3, 2);
            Clear_button.Name = "Clear_button";
            Clear_button.Size = new Size(82, 22);
            Clear_button.TabIndex = 1;
            Clear_button.Text = "Отчистить";
            Clear_button.UseVisualStyleBackColor = true;
            Clear_button.Click += Clear_button_Click;
            // 
            // CDA_radio
            // 
            CDA_radio.AutoSize = true;
            CDA_radio.Location = new Point(29, 20);
            CDA_radio.Margin = new Padding(3, 2, 3, 2);
            CDA_radio.Name = "CDA_radio";
            CDA_radio.Size = new Size(104, 19);
            CDA_radio.TabIndex = 0;
            CDA_radio.TabStop = true;
            CDA_radio.Text = "Обычный Цда";
            CDA_radio.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 9);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(444, 326);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            Paint += MainForm_Paint;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Clear_button;
        private RadioButton CDA_radio;
        private PictureBox pictureBox1;
        private RadioButton Fill_radio;
        private ColorDialog colorDialog1;
        private Button use_button;
        private Button color_button;
        private Button fill_color_button;
        private RadioButton CDA_THICC_button;
        private RadioButton radioButton1;
    }
}
