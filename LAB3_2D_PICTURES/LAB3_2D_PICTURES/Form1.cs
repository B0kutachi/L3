using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Resolvers;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Threading;


namespace LAB3_2D_PICTURES
{
    public partial class Form1 : Form
    {
        int[,] kv = new int[4, 3]; // ������� ����
        int[,] fig = new int[5, 3]; // ������� ���� ������
        int[,] osi = new int[4, 3]; // ������� ��������� ����
        int[,] matr_sdv = new int[3, 3]; //������� ��������������
        int k, l; // �������� ������� ������
        int k_osi, l_osi;
        bool f;
        string sdvig;

        public Form1()
        {
            InitializeComponent();
        }

        //������������� ������� ���� ������
        private void Init_figure()
        {
            fig[0, 0] = -64; fig[0, 1] = -64; fig[0, 2] = 1;
            fig[1, 0] = 44; fig[1, 1] = -24; fig[1, 2] = 1;
            fig[2, 0] = 72; fig[2, 1] = 0; fig[2, 2] = 1;
            fig[3, 0] = 44; fig[3, 1] = 24; fig[3, 2] = 1;
            fig[4, 0] = -64; fig[4, 1] = 64; fig[4, 2] = 1;
        }


        //������������� ������� ���� ��������
        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
        }


        //������������� ������� ������
        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }


        //������������� ������� ����
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }


        //��������� ������
        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);

            int[,] r = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }


        //����� �������� �� �����
        private void Draw_Kv()
        {
            Init_kvadrat(); //������������� ������� ����
            Init_matr_preob(k, l); //������������� ������� ��������������
            int[,] kv1 = Multiply_matr(kv, matr_sdv); //������������ ������

            Pen myPen = new Pen(Color.Blue, 2);// ���� ����� � ������

            //������� ����� ������ Graphics (����������� ���������) �� pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // ������ 1 ������� ��������
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            // ������ 2 ������� ��������
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            // ������ 3 ������� ��������
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            // ������ 4 ������� ��������
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);

            g.Dispose();// ����������� ��� �������, ��������� � ����������
            myPen.Dispose(); //����������� �������, ��������� � Pen
        }

        // ����� 19-�� �������� ������ �� �����
        private void Draw_Figure()
        {
            Init_matr_preob(k, l); //������������� ������� ��������������
            int[,] fig1 = Multiply_matr(fig, matr_sdv); //������������ ������

            Pen myPen = new Pen(Color.RebeccaPurple, 2);// ���� ����� � ������

            //������� ����� ������ Graphics (����������� ���������) �� pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // ������ 1 ����� ������
            g.DrawLine(myPen, fig1[0, 0], fig1[0, 1], fig1[1, 0], fig1[1, 1]);
            // ������ 2 ����� ������
            g.DrawLine(myPen, fig1[1, 0], fig1[1, 1], fig1[2, 0], fig1[2, 1]);
            // ������ 3 ����� ������
            g.DrawLine(myPen, fig1[2, 0], fig1[2, 1], fig1[3, 0], fig1[3, 1]);
            // ������ 4 ����� ������
            g.DrawLine(myPen, fig1[3, 0], fig1[3, 1], fig1[4, 0], fig1[4, 1]);
            // ������ 5 ����� ������
            g.DrawLine(myPen, fig1[4, 0], fig1[4, 1], fig1[0, 0], fig1[0, 1]);

            g.Dispose();// ����������� ��� �������, ��������� � ����������
            myPen.Dispose(); //����������� �������, ��������� � Pen
        }


        //����� ���� �� �����
        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(k_osi, l_osi);
            int[,] osi1 = Multiply_matr(osi, matr_sdv);

            Pen myPen = new Pen(Color.Red, 1);// ���� ����� � ������
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // ������ ��� ��
            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);

            // ������ ��� ��
            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        //���������� ���
        private void button1_Click(object sender, EventArgs e)
        {
            k_osi = pictureBox1.Width / 2;
            l_osi = pictureBox1.Height / 2;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }


        //����� ���������� � ������ pictureBox
        private void button2_Click(object sender, EventArgs e)
        {
            //�������� pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            //����� ���������� � ��������
            Draw_Kv();

            f = true;
        }

        //��������
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Color newPixelColor = Color.White;
            g.Clear(newPixelColor);
        }

        //����� ������
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            k += 5; //��������� ���������������� �������� ������� ������
            Draw_Figure(); //����� ������
        }

        //����� �����
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            k -= 5; //��������� ���������������� �������� ������� ������
            Draw_Figure(); //����� ������
        }

        //����� ����
        private void button7_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            l += 5; //��������� ���������������� �������� ������� ������
            Draw_Figure(); //����� ������
        }

        //����� �����
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            l -= 5; //��������� ���������������� �������� ������� ������
            Draw_Figure(); //����� ������
        }

        //����������� ����������� ������
        private void button8_Click(object sender, EventArgs e)
        {
            sdvig = "pravo";

            timer1.Interval = 100;

            button8.Text = "����";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "�����";
            }
            f = !f;
        }

        //������, ���������� �� ��, � ����� ������� � ��� ����� ��������� ������
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (sdvig == "pravo")
                k++;

            if (sdvig == "levo")
                k--;

            if (sdvig == "niz")
                l++;

            if (sdvig == "verh")
                l--;

            Draw_Figure();
            Thread.Sleep(100);
        }

        //����� ������
        private void button9_Click(object sender, EventArgs e)
        {
            Init_figure(); //������������� ������� ����
            //�������� pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            //����� ������ � ��������
            Draw_Figure();

            f = true;
        }

        //����������� ����������� �����
        private void button10_Click(object sender, EventArgs e)
        {
            sdvig = "levo";

            timer1.Interval = 100;

            button8.Text = "����";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "�����";
            }
            f = !f;
        }

        //����������� ����������� ����
        private void button11_Click(object sender, EventArgs e)
        {
            sdvig = "niz";

            timer1.Interval = 100;

            button8.Text = "����";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "�����";
            }
            f = !f;
        }

        //����������� ����������� �����
        private void button12_Click(object sender, EventArgs e)
        {
            sdvig = "verh";

            timer1.Interval = 100;

            button8.Text = "����";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "�����";
            }
            f = !f;
        }

        //��������� ��� ��������� ������ ������������ ��� X:
        private void Reflect_Figure_X()
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] = -fig[i, 0];
            }
        }

        //�������� �� X
        private void button13_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Init_figure();
            Reflect_Figure_X();

            Init_matr_preob(k, l); //������������� ������� ��������������
            int[,] fig1 = Multiply_matr(fig, matr_sdv); //������������ ������

            Pen myPen = new Pen(Color.RebeccaPurple, 2);// ���� ����� � ������

            //������� ����� ������ Graphics (����������� ���������) �� pictureBox

            // ������ 1 ����� ������
            g.DrawLine(myPen, fig1[0, 0], fig1[0, 1], fig1[1, 0], fig1[1, 1]);
            // ������ 2 ����� ������
            g.DrawLine(myPen, fig1[1, 0], fig1[1, 1], fig1[2, 0], fig1[2, 1]);
            // ������ 3 ����� ������
            g.DrawLine(myPen, fig1[2, 0], fig1[2, 1], fig1[3, 0], fig1[3, 1]);
            // ������ 4 ����� ������
            g.DrawLine(myPen, fig1[3, 0], fig1[3, 1], fig1[4, 0], fig1[4, 1]);
            // ������ 5 ����� ������
            g.DrawLine(myPen, fig1[4, 0], fig1[4, 1], fig1[0, 0], fig1[0, 1]);

            g.Dispose();// ����������� ��� �������, ��������� � ����������
            myPen.Dispose(); //����������� �������, ��������� � Pen
        }

        //��������� ��� ��������������� (���������)
        private void Scale_Figure_umn(int sx, int sy)
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] *= sx;
                fig[i, 1] *= sy;
            }
        }

        //��������� ��� ��������������� (�������)
        private void Scale_Figure_del(int sx, int sy)
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] /= sx;
                fig[i, 1] /= sy;
            }
        }


        //��������������� (��������)
        private void button14_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Scale_Figure_umn(2, 2);
            Draw_Figure();
        }

        //��������������� (������)
        private void button15_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Scale_Figure_del(2, 2);
            Draw_Figure();
        }


        //��������� ��� �������� ������ �� ���� angle
        private void Rotate_Figure(double angle)
        {
            double radians = angle * Math.PI / 180;
            double cosTheta = Math.Cos(radians);
            double sinTheta = Math.Sin(radians);

            for (int i = 0; i < 5; i++)
            {
                double x = fig[i, 0];
                double y = fig[i, 1];

                fig[i, 0] = (int)(x * cosTheta - y * sinTheta);
                fig[i, 1] = (int)(x * sinTheta + y * cosTheta);
            }
        }



        //������� �� 15*
        private void button16_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Rotate_Figure(15);
            Draw_Figure();
        }

        //������� �� -15*
        private void button17_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Rotate_Figure(-15);
            Draw_Figure();
        }
    }
}
