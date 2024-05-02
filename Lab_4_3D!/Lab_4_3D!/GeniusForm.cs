using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Lab_4_3D_
{
    public partial class GeniusForm : Form
    {
        private PictureBox pictureBox1;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button resetButton;

        private Point3D currentCenter; // Variable to store the current center of the polyhedron


        private const int polyhedronSize = 100; // Size of the polyhedron
        private const int coordinateSystemSize = 200; // Size of the coordinate system

        private Point3D[] polyhedronVertices; // Vertices of the polyhedron
        private Point3D[] transformedPolyhedronVertices; // Transformed vertices of the polyhedron

        private Matrix4x4 transformationMatrix = Matrix4x4.Identity; // Transformation matrix


        public GeniusForm()
        {
            InitializeComponent();
            InitializeUI();
            InitializePolyhedron();

            // Добавляем обработчик события Paint для pictureBox1
            pictureBox1.Paint += PictureBox1_Paint;
        }

        private void InitializeUI()
        {
            // Initialize UI components
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.BackColor = Color.White;

            moveButton = new System.Windows.Forms.Button();
            moveButton.Text = "Move";
            moveButton.Location = new Point(420, 10);
            moveButton.Click += MoveButton_Click;

            rotateButton = new System.Windows.Forms.Button();
            rotateButton.Text = "Rotate";
            rotateButton.Location = new Point(420, 40);
            rotateButton.Click += RotateButton_Click;

            resizeButton = new System.Windows.Forms.Button();
            resizeButton.Text = "Resize";
            resizeButton.Location = new Point(420, 70);
            resizeButton.Click += ResizeButton_Click;

            resetButton = new System.Windows.Forms.Button();
            resetButton.Text = "Reset";
            resetButton.Location = new Point(420, 100);
            resetButton.Click += ResetButton_Click;

            Controls.Add(pictureBox1);
            Controls.Add(moveButton);
            Controls.Add(rotateButton);
            Controls.Add(resizeButton);
            Controls.Add(resetButton);
        }

        private void InitializePolyhedron()
        {
            // Initialize tetrahedron vertices
            polyhedronVertices = new Point3D[]
            {
                new Point3D(0, 0, 0),
                new Point3D(polyhedronSize, 0, 0),
                new Point3D(polyhedronSize / 2, (float)(polyhedronSize * Math.Sqrt(3) / 2), 0),
                new Point3D(polyhedronSize / 2, (float)(polyhedronSize * Math.Sqrt(3) / 6), (float)(polyhedronSize * Math.Sqrt(6) / 3))
            };

            // Initialize transformed polyhedron vertices
            transformedPolyhedronVertices = new Point3D[polyhedronVertices.Length];
            Array.Copy(polyhedronVertices, transformedPolyhedronVertices, polyhedronVertices.Length);
        }

        private void DrawCoordinateSystem(Graphics g)
        {
            // Draw X-axis
            Pen axisPen = new Pen(Color.Red, 2);
            g.DrawLine(axisPen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);

            // Draw Y-axis
            g.DrawLine(axisPen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            // Draw Z-axis
            g.DrawLine(axisPen, pictureBox1.Width / 2, pictureBox1.Height / 2, 0, pictureBox1.Height); // Lower left corner
            g.DrawLine(axisPen, pictureBox1.Width / 2, pictureBox1.Height / 2, pictureBox1.Width, 0); // Upper right corner
        }

        private void DrawPolyhedron(Graphics g)
        {
            // Определяем индексы вершин для каждой грани тетраэдра
            int[][] faces = new int[][]
            {
                new int[] { 0, 1, 2 }, // Грань 1
                new int[] { 0, 2, 3 }, // Грань 2
                new int[] { 0, 3, 1 }, // Грань 3
                new int[] { 1, 2, 3 }  // Грань 4
            };

            // Рисуем каждую грань тетраэдра
            for (int i = 0; i < faces.Length; i++)
            {
                Point3D v0 = transformedPolyhedronVertices[faces[i][0]];
                Point3D v1 = transformedPolyhedronVertices[faces[i][1]];
                Point3D v2 = transformedPolyhedronVertices[faces[i][2]];

                g.DrawLine(Pens.Red, v0.ToPointF(), v1.ToPointF());
                g.DrawLine(Pens.Red, v1.ToPointF(), v2.ToPointF());
                g.DrawLine(Pens.Red, v2.ToPointF(), v0.ToPointF());
            }
        }

        private void ApplyTransformation()
        {
            // Apply transformation to polyhedron vertices
            for (int i = 0; i < polyhedronVertices.Length; i++)
            {
                transformedPolyhedronVertices[i] = Point3D.Transform(polyhedronVertices[i], transformationMatrix);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Базовый вызов метода OnPaint для отрисовки всей области формы
            base.OnPaint(e);

            // Оставьте отрисовку только в PictureBox1
            if (e.ClipRectangle == pictureBox1.ClientRectangle)
            {
                Graphics g = e.Graphics;
                DrawCoordinateSystem(g);
                DrawPolyhedron(g);
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            // Example: move the polyhedron along the X-axis, Y-axis, and Z-axis simultaneously
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(10, 10, 10); // Change values as needed
            transformationMatrix *= moveMatrix; // Apply the movement to the current transformation matrix
            ApplyTransformation();

            // Update the current center of the polyhedron after movement
            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            // Example: rotate the polyhedron around the X-axis, Y-axis, and Z-axis simultaneously
            transformationMatrix *= Matrix4x4.CreateRotationX((float)Math.PI / 6); // Rotate around X-axis
            transformationMatrix *= Matrix4x4.CreateRotationY((float)Math.PI / 6); // Rotate around Y-axis
            transformationMatrix *= Matrix4x4.CreateRotationZ((float)Math.PI / 6); // Rotate around Z-axis
            ApplyTransformation();
            pictureBox1.Refresh();
        }

        private void ResizeButton_Click(object sender, EventArgs e)
        {
            // Calculate the center of the polyhedron
            Point3D center = currentCenter;

            // Move the center to the origin
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Scale the polyhedron
            Matrix4x4 scaleMatrix = Matrix4x4.CreateScale(1.1f, 1.1f, 1.1f); // Change values as needed

            // Move the center back to its original position
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(center.X, center.Y, center.Z);

            // Combine the transformations
            transformationMatrix *= moveToOrigin;
            transformationMatrix *= scaleMatrix;
            transformationMatrix *= moveBack;

            ApplyTransformation();
            pictureBox1.Refresh();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset transformation matrix
            transformationMatrix = Matrix4x4.Identity;
            Array.Copy(polyhedronVertices, transformedPolyhedronVertices, polyhedronVertices.Length);
            pictureBox1.Refresh();
        }

        private Point3D CalculateCenter()
        {
            // Calculate the center of the polyhedron
            float totalX = 0, totalY = 0, totalZ = 0;
            foreach (Point3D vertex in transformedPolyhedronVertices)
            {
                totalX += vertex.X;
                totalY += vertex.Y;
                totalZ += vertex.Z;
            }
            float centerX = totalX / transformedPolyhedronVertices.Length;
            float centerY = totalY / transformedPolyhedronVertices.Length;
            float centerZ = totalZ / transformedPolyhedronVertices.Length;
            return new Point3D(centerX, centerY, centerZ);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawCoordinateSystem(g);
            DrawPolyhedron(g);
        }
    }



    public struct Point3D
    {
        public float X;
        public float Y;
        public float Z;

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public PointF ToPointF()
        {
            return new PointF(X, Y);
        }

        public static Point3D Transform(Point3D point, Matrix4x4 matrix)
        {
            Vector3 transformedVector = Vector3.Transform(new Vector3(point.X, point.Y, point.Z), matrix);
            return new Point3D(transformedVector.X, transformedVector.Y, transformedVector.Z);
        }
    }

}
