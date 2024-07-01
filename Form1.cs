using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KonataDancing
{
    public partial class Form1 : Form
    {

        int lastFrame = 1;
        Bitmap currentFrame;
        DoubleBufferedPictureBox pictureBox;
        System.Windows.Forms.Timer timer;
        private Point lastLocation;

        public Form1()
        {
            InitializeComponent();
            pictureBox = initPictureBox();
            Controls.Add(pictureBox);

            pictureBox.MouseDown += new MouseEventHandler(PictureBox_MouseDown);
            pictureBox.MouseMove += new MouseEventHandler(PictureBox_MouseMove);
            pictureBox.MouseUp += new MouseEventHandler(PictureBox_MouseUp);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 45;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private DoubleBufferedPictureBox initPictureBox() 
        {
            DoubleBufferedPictureBox pictureBox = new DoubleBufferedPictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(500, 500),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            return pictureBox;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentFrame != null)
                currentFrame.Dispose();

            if (lastFrame >= 2853)
                lastFrame = 1;
            lastFrame += 2;

            using (Bitmap bmp = new Bitmap($"frames\\frame_{lastFrame.ToString("D4")}.png"))
            {
                currentFrame = new Bitmap(bmp);
                pictureBox.Image = currentFrame;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastLocation = e.Location;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastLocation.X;
                this.Top += e.Y - lastLocation.Y;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastLocation = Point.Empty;
            }
        }
    }
}

public class DoubleBufferedPictureBox : PictureBox
{
    public DoubleBufferedPictureBox()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
        UpdateStyles();
    }
}