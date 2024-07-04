using System;
using System.Drawing;
using System.Windows.Forms;

namespace KonataDancing
{
    public partial class Form1 : Form
    {
        int lastFrame = 1;
        Bitmap currentFrame;
        DoubleBufferedPictureBox pictureBox;
        System.Windows.Forms.Timer timer;
        Point lastLocation;

        public Form1()
        {
            InitializeComponent();
            pictureBox = InitPictureBox();
            Controls.Add(pictureBox);

            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseMove += PictureBox_MouseMove;
            pictureBox.MouseUp += PictureBox_MouseUp;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000 / 45;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private DoubleBufferedPictureBox InitPictureBox()
        {
            return new DoubleBufferedPictureBox
            {
                Location = new Point(0, 0),
                Size = new Size(494, 360),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadNextFrame();

            if (currentFrame != null)
            {
                pictureBox.Image = currentFrame;
            }
        }

        private void LoadNextFrame()
        {
            if (currentFrame != null)
                currentFrame.Dispose();

            if (lastFrame >= 2853)
                lastFrame = 1;
            lastFrame += 2;

            string framePath = $"frames\\frame_{lastFrame.ToString("D4")}.png";
            if (System.IO.File.Exists(framePath))
            {
                currentFrame = new Bitmap(framePath);
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

    public class DoubleBufferedPictureBox : PictureBox
    {
        public DoubleBufferedPictureBox()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
}