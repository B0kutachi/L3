using System;
using System.Drawing;
using System.Security.AccessControl;
using System.Windows.Forms;
using System.Xml.Resolvers;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Threading;
using System.Drawing.Drawing2D;


namespace LAB3_2D_PICTURES
{
    public partial class Form1 : Form
    {
        int[,] kv = new int[4, 3]; // матрица тела
        int[,] fig = new int[5, 3]; // матрица тела фигуры
        int[,] fig_copy = new int[5, 3];
        int[,] osi = new int[4, 3]; // матрица координат осей
        int[,] matr_sdv = new int[3, 3]; //матрица преобразования
        int k, l; // элементы матрицы сдвига
        int k_osi, l_osi;
        bool f;
        string sdvig;
        int scale = 1;
        int scale_del = 1;
        bool sdvig_ver = false;
        int krilya = 0;

        //int[,] korma = new int[5, 3];


        public Form1()
        {
            InitializeComponent();
        }

        // инициализация кормы
        private void init_korma()
        {
            fig[0, 0] = -190; fig[0, 1] = 180; fig[0, 2] = 1;
            fig[1, 0] = -250; fig[1, 1] = 130; fig[1, 2] = 1;
            fig[2, 0] = -40; fig[2, 1] = 130; fig[2, 2] = 1;
            fig[3, 0] = -100; fig[3, 1] = 180; fig[3, 2] = 1;
            fig[4, 0] = -190; fig[4, 1] = 180; fig[4, 2] = 1;
        }

        // инициализация паруса
        private void init_parus()
        {
            fig[0, 0] = -150; fig[0, 1] = 130; fig[0, 2] = 1;
            fig[1, 0] = -150; fig[1, 1] = 30; fig[1, 2] = 1;
            fig[2, 0] = -70; fig[2, 1] = 120; fig[2, 2] = 1;
            fig[3, 0] = -150; fig[3, 1] = 120; fig[3, 2] = 1;
            fig[4, 0] = -150; fig[4, 1] = 120; fig[4, 2] = 1;
        }

        private void init_chaika()
        {
            fig[0, 0] = -205; fig[0, 1] = -110; fig[0, 2] = 1;
            fig[1, 0] = -180; fig[1, 1] = -90; fig[1, 2] = 1;
            fig[2, 0] = -160; fig[2, 1] = -125; fig[2, 2] = 1;
            fig[3, 0] = -180; fig[3, 1] = -90; fig[3, 2] = 1;
            fig[4, 0] = -180; fig[4, 1] = -90; fig[4, 2] = 1;
        }



        //инициализация матрицы тела фигуры
        private void Init_figure()
        {
            fig[0, 0] = -64; fig[0, 1] = -64; fig[0, 2] = 1;
            fig[1, 0] = 44; fig[1, 1] = -24; fig[1, 2] = 1;
            fig[2, 0] = 72; fig[2, 1] = 0; fig[2, 2] = 1;
            fig[3, 0] = 44; fig[3, 1] = 24; fig[3, 2] = 1;
            fig[4, 0] = -64; fig[4, 1] = 64; fig[4, 2] = 1;
        }

        private void Init_fig_copy()
        {
            if (scale > 1)
            {
                fig[0, 0] = -64 * scale; fig[0, 1] = -64 * scale; fig[0, 2] = 1;
                fig[1, 0] = 44 * scale; fig[1, 1] = -24 * scale; fig[1, 2] = 1;
                fig[2, 0] = 72 * scale; fig[2, 1] = 0 * scale; fig[2, 2] = 1;
                fig[3, 0] = 44 * scale; fig[3, 1] = 24 * scale; fig[3, 2] = 1;
                fig[4, 0] = -64 * scale; fig[4, 1] = 64 * scale; fig[4, 2] = 1;
            }

            if (scale == 1)
            {
                fig[0, 0] = -64; fig[0, 1] = -64; fig[0, 2] = 1;
                fig[1, 0] = 44; fig[1, 1] = -24; fig[1, 2] = 1;
                fig[2, 0] = 72; fig[2, 1] = 0; fig[2, 2] = 1;
                fig[3, 0] = 44; fig[3, 1] = 24; fig[3, 2] = 1;
                fig[4, 0] = -64; fig[4, 1] = 64; fig[4, 2] = 1;
            }

            if (scale_del > 1)
            {
                fig[0, 0] = -64 / scale; fig[0, 1] = -64 / scale; fig[0, 2] = 1;
                fig[1, 0] = 44 / scale; fig[1, 1] = -24 / scale; fig[1, 2] = 1;
                fig[2, 0] = 72 / scale; fig[2, 1] = 0 / scale; fig[2, 2] = 1;
                fig[3, 0] = 44 / scale; fig[3, 1] = 24 / scale; fig[3, 2] = 1;
                fig[4, 0] = -64 / scale; fig[4, 1] = 64 / scale; fig[4, 2] = 1;
            }
        }


        //инициализация матрицы тела квадрата
        private void Init_kvadrat()
        {
            kv[0, 0] = -50; kv[0, 1] = 0; kv[0, 2] = 1;
            kv[1, 0] = 0; kv[1, 1] = 50; kv[1, 2] = 1;
            kv[2, 0] = 50; kv[2, 1] = 0; kv[2, 2] = 1;
            kv[3, 0] = 0; kv[3, 1] = -50; kv[3, 2] = 1;
        }


        //инициализация матрицы сдвига
        private void Init_matr_preob(int k1, int l1)
        {
            matr_sdv[0, 0] = 1; matr_sdv[0, 1] = 0; matr_sdv[0, 2] = 0;
            matr_sdv[1, 0] = 0; matr_sdv[1, 1] = 1; matr_sdv[1, 2] = 0;
            matr_sdv[2, 0] = k1; matr_sdv[2, 1] = l1; matr_sdv[2, 2] = 1;
        }


        //инициализация матрицы осей
        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }


        //умножение матриц
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


        //вывод квадрата на экран
        private void Draw_Kv()
        {
            Init_kvadrat(); //инициализация матрицы тела
            Init_matr_preob(k, l); //инициализация матрицы преобразования
            int[,] kv1 = Multiply_matr(kv, matr_sdv); //перемножение матриц

            Pen myPen = new Pen(Color.Blue, 2);// цвет линии и ширина

            //создаем новый объект Graphics (поверхность рисования) из pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем 1 сторону квадрата
            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
            // рисуем 2 сторону квадрата
            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
            // рисуем 3 сторону квадрата
            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
            // рисуем 4 сторону квадрата
            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);

            g.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
            myPen.Dispose(); //освобождвем ресурсы, связанные с Pen
        }

        // вывод 19-го варианта фигуры на экран
        private void Draw_Figure()
        {
            Init_matr_preob(k, l); //инициализация матрицы преобразования
            int[,] fig1 = Multiply_matr(fig, matr_sdv); //перемножение матриц

            Pen myPen = new Pen(Color.RebeccaPurple, 2);// цвет линии и ширина

            //создаем новый объект Graphics (поверхность рисования) из pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем 1 точку фигуры
            g.DrawLine(myPen, fig1[0, 0], fig1[0, 1], fig1[1, 0], fig1[1, 1]);
            // рисуем 2 точку фигуры
            g.DrawLine(myPen, fig1[1, 0], fig1[1, 1], fig1[2, 0], fig1[2, 1]);
            // рисуем 3 точку фигуры
            g.DrawLine(myPen, fig1[2, 0], fig1[2, 1], fig1[3, 0], fig1[3, 1]);
            // рисуем 4 точку фигуры
            g.DrawLine(myPen, fig1[3, 0], fig1[3, 1], fig1[4, 0], fig1[4, 1]);
            // рисуем 5 точку фигуры
            g.DrawLine(myPen, fig1[4, 0], fig1[4, 1], fig1[0, 0], fig1[0, 1]);

            g.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
            myPen.Dispose(); //освобождвем ресурсы, связанные с Pen
        }

        private void Draw_indiv()
        {
            Init_matr_preob(k, l); //инициализация матрицы преобразования
            int[,] fig1 = Multiply_matr(fig, matr_sdv); //перемножение матриц

            Pen myPen = new Pen(Color.RebeccaPurple, 2);// цвет линии и ширина

            //создаем новый объект Graphics (поверхность рисования) из pictureBox
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем 1 точку фигуры
            g.DrawLine(myPen, fig1[0, 0], fig1[0, 1], fig1[1, 0], fig1[1, 1]);
            // рисуем 2 точку фигуры
            g.DrawLine(myPen, fig1[1, 0], fig1[1, 1], fig1[2, 0], fig1[2, 1]);
            // рисуем 3 точку фигуры
            g.DrawLine(myPen, fig1[2, 0], fig1[2, 1], fig1[3, 0], fig1[3, 1]);
            // рисуем 4 точку фигуры
            g.DrawLine(myPen, fig1[3, 0], fig1[3, 1], fig1[4, 0], fig1[4, 1]);
            // рисуем 5 точку фигуры
            g.DrawLine(myPen, fig1[4, 0], fig1[4, 1], fig1[0, 0], fig1[0, 1]);

            g.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
            myPen.Dispose(); //освобождвем ресурсы, связанные с Pen
        }


        //вывод осей на экран
        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(k_osi, l_osi);
            int[,] osi1 = Multiply_matr(osi, matr_sdv);

            Pen myPen = new Pen(Color.Red, 1);// цвет линии и ширина
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            // рисуем ось ОХ
            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);

            // рисуем ось ОУ
            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);

            g.Dispose();
            myPen.Dispose();
        }

        //нарисовать оси
        private void button1_Click(object sender, EventArgs e)
        {
            k_osi = pictureBox1.Width / 2;
            l_osi = pictureBox1.Height / 2;
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }


        //вывод квадратика в центре pictureBox
        private void button2_Click(object sender, EventArgs e)
        {
            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            //вывод квадратика в середине
            Draw_Kv();

            f = true;
        }

        //очистить
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Color newPixelColor = Color.White;
            g.Clear(newPixelColor);
        }

        //сдвиг вправо
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            k += 5; //изменение соответствующего элемента матрицы сдвига
            Draw_Figure(); //вывод фигуры
        }

        //сдвиг влево
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            k -= 5; //изменение соответствующего элемента матрицы сдвига
            Draw_Figure(); //вывод фигуры
        }

        //сдвиг вниз
        private void button7_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            l += 5; //изменение соответствующего элемента матрицы сдвига
            Draw_Figure(); //вывод фигуры
        }

        //сдвиг вверх
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            l -= 5; //изменение соответствующего элемента матрицы сдвига
            Draw_Figure(); //вывод фигуры
        }

        //непрерывное перемещение вправо
        private void button8_Click(object sender, EventArgs e)
        {
            sdvig_ver = false;
            sdvig = "pravo";

            timer1.Interval = 100;

            button8.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button8.Text = "Старт";
            }
            f = !f;
        }

        //таймер, отвечающий за то, в какую сторону и как будет двигаться фигура
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (sdvig_ver == false)
            {
                if (sdvig == "pravo")
                    k++;

                if (sdvig == "levo")
                    k--;

                if (sdvig == "niz")
                    l++;

                if (sdvig == "verh")
                    l--;

                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                g.Clear(Color.White);
                Draw_osi();

                Draw_Figure();
                Thread.Sleep(100);
            }
            
            if (sdvig_ver == true)
            {
                if (sdvig == "indiv")
                    k += 2;

                Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                g.Clear(Color.Orange);

                init_korma();
                Draw_Figure();

                init_parus();
                Draw_Figure();

                krilya += 1;
                init_chaika();
                if (krilya / 2 < 1)
                {
                    fig[0, 0] = -205; fig[0, 1] = -65; fig[0, 2] = 1;
                    fig[2, 0] = -160; fig[2, 1] = -80; fig[2, 2] = 1;
                }
                else if (krilya / 2 == 1)
                {
                    fig[0, 0] = -205; fig[0, 1] = -110; fig[0, 2] = 1;
                    fig[2, 0] = -160; fig[2, 1] = -125; fig[2, 2] = 1;
                }

                if (krilya == 2)
                {
                    krilya = 0;
                }
                Draw_Figure();

                Thread.Sleep(100);
            }
        }

        //вывод фигуры
        private void button9_Click(object sender, EventArgs e)
        {
            Init_figure(); //инициализация матрицы тела
            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            //вывод фигуры в середине
            Draw_Figure();

            f = true;
        }

        //непрерывное перемещение влево
        private void button10_Click(object sender, EventArgs e)
        {
            sdvig_ver = false;
            sdvig = "levo";

            timer1.Interval = 100;

            button10.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button10.Text = "Старт";
            }
            f = !f;
        }

        //непрерывное перемещение вниз
        private void button11_Click(object sender, EventArgs e)
        {
            sdvig_ver = false;
            sdvig = "niz";

            timer1.Interval = 100;

            button11.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button11.Text = "Старт";
            }
            f = !f;
        }

        //непрерывное перемещение вверх
        private void button12_Click(object sender, EventArgs e)
        {
            sdvig_ver = false;
            sdvig = "verh";

            timer1.Interval = 100;

            button12.Text = "Стоп";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button12.Text = "Старт";
            }
            f = !f;
        }

        //Процедура для отражения фигуры относительно оси X:
        private void Reflect_Figure_X()
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] = -fig[i, 0];
            }
        }




        //Отразить по X
        private void button13_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Reflect_Figure_X();

            Init_matr_preob(k, l); //инициализация матрицы преобразования
            int[,] fig1 = Multiply_matr(fig, matr_sdv); //перемножение матриц

            Pen myPen = new Pen(Color.RebeccaPurple, 2);// цвет линии и ширина

            // рисуем 1 точку фигуры
            g.DrawLine(myPen, fig1[0, 0], fig1[0, 1], fig1[1, 0], fig1[1, 1]);
            // рисуем 2 точку фигуры
            g.DrawLine(myPen, fig1[1, 0], fig1[1, 1], fig1[2, 0], fig1[2, 1]);
            // рисуем 3 точку фигуры
            g.DrawLine(myPen, fig1[2, 0], fig1[2, 1], fig1[3, 0], fig1[3, 1]);
            // рисуем 4 точку фигуры
            g.DrawLine(myPen, fig1[3, 0], fig1[3, 1], fig1[4, 0], fig1[4, 1]);
            // рисуем 5 точку фигуры
            g.DrawLine(myPen, fig1[4, 0], fig1[4, 1], fig1[0, 0], fig1[0, 1]);

            g.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
            myPen.Dispose(); //освобождвем ресурсы, связанные с Pen
        }

        //Процедура для масштабирования (умножение)
        private void Scale_Figure_umn(int sx, int sy)
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] *= sx;
                fig[i, 1] *= sy;
            }
        }

        //Процедура для масштабирования (деление)
        private void Scale_Figure_del(int sx, int sy)
        {
            for (int i = 0; i < 5; i++)
            {
                fig[i, 0] /= sx;
                fig[i, 1] /= sy;
            }
        }


        //Масштабирование (умножить)
        private void button14_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Scale_Figure_umn(2, 2);
            scale *= 2;
            Draw_Figure();
        }

        //Масштабирование (делить)
        private void button15_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Scale_Figure_del(2, 2);
            scale_del *= 2;
            Draw_Figure();
        }


        //Процедура для поворота фигуры на угол angle
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



        //Поворот на 15*
        private void button16_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Rotate_Figure(15);
            Draw_Figure();
        }

        //Поворот на -15*
        private void button17_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            g.Clear(Color.White);
            Draw_osi();

            Rotate_Figure(-15);
            Draw_Figure();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //середина pictureBox
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;

            init_korma();
            Draw_Figure();

            init_parus();
            Draw_Figure();

            init_chaika();
            Draw_Figure();

            f = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
            Color newPixelColor = Color.Orange;
            g.Clear(newPixelColor);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            sdvig_ver = true;
            sdvig = "indiv";

            timer1.Interval = 100;

            button20.Text = "Прекратить движение";
            if (f == true)
                timer1.Start();
            else
            {
                timer1.Stop();
                button20.Text = "Имитировать движение";
            }
            f = !f;
        }
    }
}
