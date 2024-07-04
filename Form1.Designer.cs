namespace KonataDancing
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                pictureBox?.Dispose();
                currentFrame?.Dispose();
                timer?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Green;
            TransparencyKey = Color.Green;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 360);
            this.Text = "Form1";
            this.Load += new EventHandler(MainForm_Load);
            this.TopMost = true;
        }
    }
}