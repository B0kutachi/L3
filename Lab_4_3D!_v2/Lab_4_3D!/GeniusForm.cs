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
        private System.Windows.Forms.Timer rotationTimer;

        private System.Windows.Forms.Button moveXButton;
        private System.Windows.Forms.Button moveYButton;
        private System.Windows.Forms.Button moveZButton;
        private System.Windows.Forms.Button moveXYButton;
        private System.Windows.Forms.Button moveXZButton;
        private System.Windows.Forms.Button moveYZButton;
        private System.Windows.Forms.Button moveXYZButton;

        private System.Windows.Forms.Button displayXAxisButton;
        private System.Windows.Forms.Button displayYAxisButton;
        private System.Windows.Forms.Button displayZAxisButton;

        private System.Windows.Forms.Button resizeXButton;
        private System.Windows.Forms.Button resizeYButton;
        private System.Windows.Forms.Button resizeZButton;
        private System.Windows.Forms.Button resizeXYButton;
        private System.Windows.Forms.Button resizeXZButton;
        private System.Windows.Forms.Button resizeYZButton;
        private System.Windows.Forms.Button resizeXYZButton;

        private System.Windows.Forms.Button rotateXButton;
        private System.Windows.Forms.Button rotateYButton;
        private System.Windows.Forms.Button rotateZButton;

        private System.Windows.Forms.Button resizeButton;
        private System.Windows.Forms.Button resetButton;

        private System.Windows.Forms.Button increaseSpeedButton;
        private System.Windows.Forms.Button decreaseSpeedButton;
        private System.Windows.Forms.Button changeDirectionButton;

        private System.Windows.Forms.Button startMoveButton;
        private System.Windows.Forms.Button stopMoveButton;
        private System.Windows.Forms.Button startRotateButton;
        private System.Windows.Forms.Button stopRotateButton;

        private System.Windows.Forms.Button doPositive;
        private System.Windows.Forms.Button doNegative;

        private System.Windows.Forms.Button increaseMoveX;
        private System.Windows.Forms.Button increaseMoveY;
        private System.Windows.Forms.Button increaseMoveZ;
        private System.Windows.Forms.Button decreaseMoveX;
        private System.Windows.Forms.Button decreaseMoveY;
        private System.Windows.Forms.Button decreaseMoveZ;


        private float rotationSpeedX = 0.1f; // Speed of rotation around the X-axis
        private bool rotateXEnabled = false; // Flag to control rotation

        // Flags for movement and rotation
        private bool isMoving = false;
        private bool isRotating = false;

        // Directions and speed for movement
        private float moveSpeedX = 1.0f;
        private float moveSpeedY = 1.0f;
        private float moveSpeedZ = 1.0f;

        // Angles for rotation
        private float rotationAngleX = 0.1f;
        private float rotationAngleY = 0.1f;
        private float rotationAngleZ = 0.1f;

        private int movex = 10;
        private int movey = 10;
        private int movez = 10;
        private bool isPositive = true;


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
            InitializeTimer();

            pictureBox1.Paint += PictureBox1_Paint;

            rotationTimer = new System.Windows.Forms.Timer();
            rotationTimer.Interval = 100; // Speed of rotation, lower value for faster rotation
            rotationTimer.Tick += RotationTimer_Tick;
        }

        private void InitializeUI()
        {
            pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(400, 400);
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.BackColor = Color.White;
            Controls.Add(pictureBox1);

            resizeButton = new System.Windows.Forms.Button();
            resizeButton.Text = "Resize";
            resizeButton.Location = new Point(420, 70);
            resizeButton.Click += ResizeButton_Click;
            Controls.Add(resizeButton);

            resetButton = new System.Windows.Forms.Button();
            resetButton.Text = "Reset";
            resetButton.Location = new Point(420, 100);
            resetButton.Click += ResetButton_Click;
            Controls.Add(resetButton);

            moveXButton = new System.Windows.Forms.Button();
            moveXButton.Text = "Move X";
            moveXButton.Location = new Point(420, 130);
            moveXButton.Click += MoveXButton_Click;
            Controls.Add(moveXButton);

            moveYButton = new System.Windows.Forms.Button();
            moveYButton.Text = "Move Y";
            moveYButton.Location = new Point(420, 160);
            moveYButton.Click += MoveYButton_Click;
            Controls.Add(moveYButton);

            moveZButton = new System.Windows.Forms.Button();
            moveZButton.Text = "Move Z";
            moveZButton.Location = new Point(420, 190);
            moveZButton.Click += MoveZButton_Click;
            Controls.Add(moveZButton);

            moveXYButton = new System.Windows.Forms.Button();
            moveXYButton.Text = "Move XY";
            moveXYButton.Location = new Point(420, 220);
            moveXYButton.Click += MoveXYButton_Click;
            Controls.Add(moveXYButton);

            moveXZButton = new System.Windows.Forms.Button();
            moveXZButton.Text = "Move XZ";
            moveXZButton.Location = new Point(420, 250);
            moveXZButton.Click += MoveXZButton_Click;
            Controls.Add(moveXZButton);

            moveYZButton = new System.Windows.Forms.Button();
            moveYZButton.Text = "Move YZ";
            moveYZButton.Location = new Point(420, 280);
            moveYZButton.Click += MoveYZButton_Click;
            Controls.Add(moveYZButton);

            moveXYZButton = new System.Windows.Forms.Button();
            moveXYZButton.Text = "Move XYZ";
            moveXYZButton.Location = new Point(420, 310);
            moveXYZButton.Click += MoveXYZButton_Click;
            Controls.Add(moveXYZButton);

            displayXAxisButton = new System.Windows.Forms.Button();
            displayXAxisButton.Text = "Display X Axis";
            displayXAxisButton.Location = new Point(420, 340);
            displayXAxisButton.Click += (sender, e) => DisplayAlongXAxis();
            Controls.Add(displayXAxisButton);

            displayYAxisButton = new System.Windows.Forms.Button();
            displayYAxisButton.Text = "Display Y Axis";
            displayYAxisButton.Location = new Point(420, 370);
            displayYAxisButton.Click += (sender, e) => DisplayAlongYAxis();
            Controls.Add(displayYAxisButton);

            displayZAxisButton = new System.Windows.Forms.Button();
            displayZAxisButton.Text = "Display Z Axis";
            displayZAxisButton.Location = new Point(420, 400);
            displayZAxisButton.Click += (sender, e) => DisplayAlongZAxis();
            Controls.Add(displayZAxisButton);

            // Кнопка для изменения размера по оси X
            resizeXButton = new System.Windows.Forms.Button();
            resizeXButton.Text = "Resize X";
            resizeXButton.Location = new Point(420, 430);
            resizeXButton.Click += ResizeXButton_Click;
            Controls.Add(resizeXButton);

            // Кнопка для изменения размера по оси Y
            resizeYButton = new System.Windows.Forms.Button();
            resizeYButton.Text = "Resize Y";
            resizeYButton.Location = new Point(420, 460);
            resizeYButton.Click += ResizeYButton_Click;
            Controls.Add(resizeYButton);

            // Кнопка для изменения размера по оси Z
            resizeZButton = new System.Windows.Forms.Button();
            resizeZButton.Text = "Resize Z";
            resizeZButton.Location = new Point(420, 490);
            resizeZButton.Click += ResizeZButton_Click;
            Controls.Add(resizeZButton);

            // Кнопка для изменения размера по осям X и Y
            resizeXYButton = new System.Windows.Forms.Button();
            resizeXYButton.Text = "Resize XY";
            resizeXYButton.Location = new Point(420, 520);
            resizeXYButton.Click += ResizeXYButton_Click;
            Controls.Add(resizeXYButton);

            // Кнопка для изменения размера по осям X и Z
            resizeXZButton = new System.Windows.Forms.Button();
            resizeXZButton.Text = "Resize XZ";
            resizeXZButton.Location = new Point(420, 550);
            resizeXZButton.Click += ResizeXZButton_Click;
            Controls.Add(resizeXZButton);

            // Кнопка для изменения размера по осям Y и Z
            resizeYZButton = new System.Windows.Forms.Button();
            resizeYZButton.Text = "Resize YZ";
            resizeYZButton.Location = new Point(420, 580);
            resizeYZButton.Click += ResizeYZButton_Click;
            Controls.Add(resizeYZButton);

            // Кнопка для изменения размера по всем трем осям
            resizeXYZButton = new System.Windows.Forms.Button();
            resizeXYZButton.Text = "Resize XYZ";
            resizeXYZButton.Location = new Point(420, 610);
            resizeXYZButton.Click += ResizeXYZButton_Click;
            Controls.Add(resizeXYZButton);

            // Кнопка для вращения вокруг оси X
            rotateXButton = new System.Windows.Forms.Button();
            rotateXButton.Text = "Rotate X";
            rotateXButton.Location = new Point(420, 640); // Пример расположения
            rotateXButton.Click += (sender, e) => RotateX(10); // Вращение на 10 градусов
            Controls.Add(rotateXButton);

            // Кнопка для вращения вокруг оси Y
            rotateYButton = new System.Windows.Forms.Button();
            rotateYButton.Text = "Rotate Y";
            rotateYButton.Location = new Point(420, 670); // Пример расположения
            rotateYButton.Click += (sender, e) => RotateY(10); // Вращение на 10 градусов
            Controls.Add(rotateYButton);

            // Кнопка для вращения вокруг оси Z
            rotateZButton = new System.Windows.Forms.Button();
            rotateZButton.Text = "Rotate Z";
            rotateZButton.Location = new Point(420, 700); // Пример расположения
            rotateZButton.Click += (sender, e) => RotateZ(10); // Вращение на 10 градусов
            Controls.Add(rotateZButton);

            // Создаем кнопку для увеличения скорости вращения
            increaseSpeedButton = new System.Windows.Forms.Button();
            increaseSpeedButton.Text = "Increase Speed";
            increaseSpeedButton.Location = new Point(420, 730); // Пример расположения
            increaseSpeedButton.Click += IncreaseSpeedButton_Click;
            Controls.Add(increaseSpeedButton);

            // Создаем кнопку для уменьшения скорости вращения
            decreaseSpeedButton = new System.Windows.Forms.Button();
            decreaseSpeedButton.Text = "Decrease Speed";
            decreaseSpeedButton.Location = new Point(420, 760); // Пример расположения
            decreaseSpeedButton.Click += DecreaseSpeedButton_Click;
            Controls.Add(decreaseSpeedButton);

            // Создаем кнопку для изменения направления вращения
            changeDirectionButton = new System.Windows.Forms.Button();
            changeDirectionButton.Text = "Change Direction";
            changeDirectionButton.Location = new Point(420, 790); // Пример расположения
            changeDirectionButton.Click += ChangeDirectionButton_Click;
            Controls.Add(changeDirectionButton);

            // Создаем кнопку для начала движения
            startMoveButton = new System.Windows.Forms.Button();
            startMoveButton.Text = "Start Move";
            startMoveButton.Location = new Point(420, 820); // Пример расположения
            startMoveButton.Click += StartMoveButton_Click;
            Controls.Add(startMoveButton);

            // Создаем кнопку для остановки движения
            stopMoveButton = new System.Windows.Forms.Button();
            stopMoveButton.Text = "Stop Move";
            stopMoveButton.Location = new Point(520, 820); // Пример расположения
            stopMoveButton.Click += StopMoveButton_Click;
            Controls.Add(stopMoveButton);

            // Создаем кнопку для начала вращения
            startRotateButton = new System.Windows.Forms.Button();
            startRotateButton.Text = "Start Rotate";
            startRotateButton.Location = new Point(420, 850); // Пример расположения
            startRotateButton.Click += StartRotateButton_Click;
            Controls.Add(startRotateButton);

            // Создаем кнопку для остановки вращения
            stopRotateButton = new System.Windows.Forms.Button();
            stopRotateButton.Text = "Stop Rotate";
            stopRotateButton.Location = new Point(520, 850); // Пример расположения
            stopRotateButton.Click += StopRotateButton_Click;
            Controls.Add(stopRotateButton);

            doPositive = new System.Windows.Forms.Button();
            doPositive.Text = "Do posi";
            doPositive.Location = new Point(520, 10); // Пример расположения
            doPositive.Click += doPositive_Click;
            Controls.Add(doPositive);

            doNegative = new System.Windows.Forms.Button();
            doNegative.Text = "Do nega";
            doNegative.Location = new Point(620, 10); // Пример расположения
            doNegative.Click += doNegative_Click;
            Controls.Add(doNegative);

            increaseMoveX = new System.Windows.Forms.Button();
            increaseMoveX.Text = "Inc mov X";
            increaseMoveX.Location = new Point(520, 40); // Пример расположения
            increaseMoveX.Click += increaseMoveX_Click;
            Controls.Add(increaseMoveX);

            decreaseMoveX = new System.Windows.Forms.Button();
            decreaseMoveX.Text = "Dec mov X";
            decreaseMoveX.Location = new Point(620, 40); // Пример расположения
            decreaseMoveX.Click += decreaseMoveX_Click;
            Controls.Add(decreaseMoveX);

            increaseMoveY = new System.Windows.Forms.Button();
            increaseMoveY.Text = "Inc mov Y";
            increaseMoveY.Location = new Point(520, 70); // Пример расположения
            increaseMoveY.Click += increaseMoveY_Click;
            Controls.Add(increaseMoveY);

            decreaseMoveY = new System.Windows.Forms.Button();
            decreaseMoveY.Text = "Dec mov Y";
            decreaseMoveY.Location = new Point(620, 70); // Пример расположения
            decreaseMoveY.Click += decreaseMoveY_Click;
            Controls.Add(decreaseMoveY);

            increaseMoveZ = new System.Windows.Forms.Button();
            increaseMoveZ.Text = "Inc mov Z";
            increaseMoveZ.Location = new Point(520, 100); // Пример расположения
            increaseMoveZ.Click += increaseMoveZ_Click;
            Controls.Add(increaseMoveZ);

            decreaseMoveZ = new System.Windows.Forms.Button();
            decreaseMoveZ.Text = "Dec mov Z";
            decreaseMoveZ.Location = new Point(720, 100); // Пример расположения
            decreaseMoveZ.Click += decreaseMoveZ_Click;
            Controls.Add(decreaseMoveY);

        }

        private void InitializePolyhedron()
        {
            // Initialize tetrahedron vertices
            polyhedronVertices = new Point3D[]
            {
                new Point3D(-polyhedronSize / 2, -polyhedronSize / 2, -polyhedronSize / 2),
                new Point3D(polyhedronSize / 2, -polyhedronSize / 2, -polyhedronSize / 2),
                new Point3D(0, -polyhedronSize / 2, polyhedronSize * (float)Math.Sqrt(2) / 2),
                new Point3D(0, polyhedronSize / (2 * (float)Math.Sqrt(2)), 0)
            };

            // Apply the initial rotation here if needed

            // Translate the polyhedron to the center of the PictureBox
            Matrix4x4 translationMatrix = Matrix4x4.CreateTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);
            for (int i = 0; i < polyhedronVertices.Length; i++)
            {
                polyhedronVertices[i] = Point3D.Transform(polyhedronVertices[i], translationMatrix);
            }

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

        private void MoveXButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(movex, 0, 0);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveYButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(0, movey, 0);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveZButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(0, 0, movez);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveXYButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(movex, movey, 0);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveXZButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(movex, 0, movez);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveYZButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(0, movey, movez);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void MoveXYZButton_Click(object sender, EventArgs e)
        {
            Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(movex, movey, movez);
            transformationMatrix *= moveMatrix;
            ApplyTransformation();

            currentCenter = CalculateCenter();

            pictureBox1.Refresh();
        }

        private void DisplayAlongXAxis()
        {
            // Reset the transformation matrix
            transformationMatrix = Matrix4x4.Identity;

            // Rotate the polyhedron to align with the X-axis
            transformationMatrix *= Matrix4x4.CreateRotationY((float)Math.PI / 5);

            // Apply the transformation and refresh
            ApplyTransformation();
            pictureBox1.Refresh();
        }

        private void DisplayAlongYAxis()
        {
            // Reset the transformation matrix
            transformationMatrix = Matrix4x4.Identity;

            // Rotate the polyhedron to align with the Y-axis
            transformationMatrix *= Matrix4x4.CreateRotationX((float)Math.PI / 5);

            // Apply the transformation and refresh
            ApplyTransformation();
            pictureBox1.Refresh();
        }

        private void DisplayAlongZAxis()
        {
            // Reset the transformation matrix
            transformationMatrix = Matrix4x4.Identity;

            // No rotation needed to align with the Z-axis

            // Apply the transformation and refresh
            ApplyTransformation();
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
            Point3D center = CalculateCenter();

            // Move the center to the origin
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Scale the polyhedron
            Matrix4x4 scaleMatrix = Matrix4x4.CreateScale(1.1f, 1.1f, 1.1f); // Change values as needed

            // Move the center back to its original position
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(center.X, center.Y, center.Z);

            // Combine the transformations in the correct order
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

        private void ScalePolyhedron(float scaleX, float scaleY, float scaleZ)
        {
            // Вычисляем центр полиэдра
            Point3D center = CalculateCenter();

            // Перемещаем центр в начало координат
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Масштабируем полиэдр
            Matrix4x4 scaleMatrix = Matrix4x4.CreateScale(scaleX, scaleY, scaleZ);

            // Возвращаем центр на исходное место
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(center.X, center.Y, center.Z);

            // Комбинируем трансформации в правильном порядке
            transformationMatrix *= moveToOrigin;
            transformationMatrix *= scaleMatrix;
            transformationMatrix *= moveBack;

            ApplyTransformation();
            pictureBox1.Refresh();
        }

        // Метод для изменения размера по оси X
        private void ResizeXButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.1f, 1.0f, 1.0f); // Увеличение размера по оси X на 10%
        }

        // Метод для изменения размера по оси Y
        private void ResizeYButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.0f, 1.1f, 1.0f); // Увеличение размера по оси Y на 10%
        }

        // Метод для изменения размера по оси Z
        private void ResizeZButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.0f, 1.0f, 1.1f); // Увеличение размера по оси Z на 10%
        }

        // Метод для изменения размера по осям X и Y одновременно
        private void ResizeXYButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.1f, 1.1f, 1.0f); // Увеличение размера по осям X и Y на 10%
        }

        // Метод для изменения размера по осям X и Z одновременно
        private void ResizeXZButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.1f, 1.0f, 1.1f); // Увеличение размера по осям X и Z на 10%
        }

        // Метод для изменения размера по осям Y и Z одновременно
        private void ResizeYZButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.0f, 1.1f, 1.1f); // Увеличение размера по осям Y и Z на 10%
        }

        // Метод для изменения размера по всем трем осям одновременно
        private void ResizeXYZButton_Click(object sender, EventArgs e)
        {
            ScalePolyhedron(1.1f, 1.1f, 1.1f); // Увеличение размера по всем трем осям на 10%
        }

        private void RotateX(float angle)
        {
            // Получаем центр фигуры
            Point3D center = CalculateCenter();

            // Перемещаем центр фигуры в начало координат
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Конвертируем угол из градусов в радианы
            float radians = angle * (float)Math.PI / 180;

            // Создаем матрицу вращения вокруг оси X
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationX(radians);

            // Возвращаем фигуру обратно в центр PictureBox
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);

            // Применяем трансформации в правильном порядке
            transformationMatrix *= moveToOrigin;
            transformationMatrix *= rotationMatrix;
            transformationMatrix *= moveBack;

            ApplyTransformation();
            pictureBox1.Refresh();
        }

        private void RotateY(float angle)
        {
            // Получаем центр фигуры
            Point3D center = CalculateCenter();

            // Перемещаем центр фигуры в начало координат
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Конвертируем угол из градусов в радианы
            float radians = angle * (float)Math.PI / 180;

            // Создаем матрицу вращения вокруг оси Y
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationY(radians);

            // Возвращаем фигуру обратно в центр PictureBox
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);

            // Применяем трансформации в правильном порядке
            transformationMatrix *= moveToOrigin;
            transformationMatrix *= rotationMatrix;
            transformationMatrix *= moveBack;

            ApplyTransformation();
            pictureBox1.Refresh();
        }


        private void RotateZ(float angle)
        {
            // Получаем центр фигуры
            Point3D center = CalculateCenter();

            // Перемещаем центр фигуры в начало координат
            Matrix4x4 moveToOrigin = Matrix4x4.CreateTranslation(-center.X, -center.Y, -center.Z);

            // Конвертируем угол из градусов в радианы
            float radians = angle * (float)Math.PI / 180;

            // Создаем матрицу вращения вокруг оси Z
            Matrix4x4 rotationMatrix = Matrix4x4.CreateRotationZ(radians);

            // Возвращаем фигуру обратно в центр PictureBox
            Matrix4x4 moveBack = Matrix4x4.CreateTranslation(pictureBox1.Width / 2, pictureBox1.Height / 2, 0);

            // Применяем трансформации в правильном порядке
            transformationMatrix *= moveToOrigin;
            transformationMatrix *= rotationMatrix;
            transformationMatrix *= moveBack;

            ApplyTransformation();
            pictureBox1.Refresh();
        }

        // Timer Tick Event
        private void RotationTimer_Tick(object sender, EventArgs e)
        {
            if (isMoving)
            {
                // Apply movement
                Matrix4x4 moveMatrix = Matrix4x4.CreateTranslation(moveSpeedX, moveSpeedY, moveSpeedZ);
                transformationMatrix *= moveMatrix;
                ApplyTransformation();
            }

            if (isRotating)
            {
                // Apply rotation
                Matrix4x4 rotationMatrixX = Matrix4x4.CreateRotationX(rotationAngleX);
                Matrix4x4 rotationMatrixY = Matrix4x4.CreateRotationY(rotationAngleY);
                Matrix4x4 rotationMatrixZ = Matrix4x4.CreateRotationZ(rotationAngleZ);
                transformationMatrix *= rotationMatrixX * rotationMatrixY * rotationMatrixZ;
                ApplyTransformation();
            }

            pictureBox1.Refresh();
        }

        private void RotateXButton_Click(object sender, EventArgs e)
        {
            rotateXEnabled = !rotateXEnabled; // Toggle rotation on/off
            rotationTimer.Enabled = rotateXEnabled; // Start or stop the timer based on the flag
        }

        private void IncreaseSpeedButton_Click(object sender, EventArgs e)
        {
            rotationSpeedX += 0.01f; // Increase speed
        }

        private void DecreaseSpeedButton_Click(object sender, EventArgs e)
        {
            rotationSpeedX -= 0.01f; // Decrease speed
        }

        private void ChangeDirectionButton_Click(object sender, EventArgs e)
        {
            rotationSpeedX = -rotationSpeedX; // Change direction
        }

        public void StartMovement()
        {
            isMoving = true;
        }

        public void StopMovement()
        {
            isMoving = false;
        }

        public void StartRotation()
        {
            isRotating = true;
        }

        public void StopRotation()
        {
            isRotating = false;
        }

        private void StartMoveButton_Click(object sender, EventArgs e)
        {
            StartMovement();
        }

        private void StopMoveButton_Click(object sender, EventArgs e)
        {
            StopMovement();
        }

        private void StartRotateButton_Click(object sender, EventArgs e)
        {
            StartRotation();
        }

        private void StopRotateButton_Click(object sender, EventArgs e)
        {
            StopRotation();
        }

        private void InitializeTimer()
        {
            rotationTimer = new System.Windows.Forms.Timer();
            rotationTimer.Interval = 100; // Установите интервал в миллисекундах
            rotationTimer.Tick += RotationTimer_Tick;
            rotationTimer.Start(); // Запуск таймера
        }

        private void doPositive_Click(object sender, EventArgs e)
        {
            isPositive = true;
            if (movex < 0)
            {
                movex = -movex;
            }
            if (movey < 0)
            {
                movey = -movey;
            }
            if (movez < 0)
            {
                movez = -movez;
            }
        }

        private void doNegative_Click(object sender, EventArgs e)
        {
            isPositive = false;
            if (movex > 0)
            {
                movex = -movex;
            }
            if (movey > 0)
            {
                movey = -movey;
            }
            if (movez > 0)
            {
                movez = -movez;
            }
        }

        private void increaseMoveX_Click(object sender, EventArgs e)
        {
            movex += 5;
        }

        private void decreaseMoveX_Click(object sender, EventArgs e)
        {
            movex -= 5;
        }

        private void increaseMoveY_Click(object sender, EventArgs e)
        {
            movey += 5;
        }

        private void decreaseMoveY_Click(object sender, EventArgs e)
        {
            movey -= 5;
        }

        private void increaseMoveZ_Click(object sender, EventArgs e)
        {
            movez += 5;
        }

        private void decreaseMoveZ_Click(object sender, EventArgs e)
        {
            movez -= 5;
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
