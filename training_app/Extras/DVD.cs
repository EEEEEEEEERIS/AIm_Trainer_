namespace Aim_Trainer
{
    public partial class DVD : UserControl
    {
        public DVD()
        {
            InitializeComponent();
            DVDAnimationTimer.Tick += DVDTimer_Tick;
            DVDAnimationTimer.Start();
            DoubleBuffered = true;
            BackColor = Color.FromArgb(17, 17, 17);

            pictureBox2.Location = pictureBox1.Location= pictureBox3.Location= pictureBox4.Location;
            pictureBox2.Size = pictureBox1.Size = pictureBox3.Size = pictureBox4.Size;
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
      
            pictureBox1.Click += (s, e) => OnClick(EventArgs.Empty);
            pictureBox2.Click += (s, e) => OnClick(EventArgs.Empty);
            pictureBox3.Click += (s, e) => OnClick(EventArgs.Empty);
            pictureBox4.Click += (s, e) => OnClick(EventArgs.Empty);
        }

       // public int X2 = 50;
       // public int Y2 = 180;
       // public int blob = 40;
        private float _GeschwindigkeitX2 { get; set; } = 4;
        private float _GeschwindigkeitY2 { get; set; } = 3;
        public readonly System.Windows.Forms.Timer DVDAnimationTimer = new() { Interval = 16 };


        /*public void Zeichnen(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                g.FillRectangle(brush, X2, Y2, blob, blob);
            }
        }*/

        public void Bewegen(Size feld)
        {
            int neuX = pictureBox1.Left + (int)_GeschwindigkeitX2;
            int neuY = pictureBox1.Top + (int)_GeschwindigkeitY2;
            bool abgeprallt = false;

            if (neuX < 0)
            {
                neuX= 0;
                _GeschwindigkeitX2 = -_GeschwindigkeitX2;
                abgeprallt = true;
            }
            else if (neuX + pictureBox1.Width > feld.Width)
            {
                neuX = feld.Width - pictureBox1.Width;
                _GeschwindigkeitX2 = -_GeschwindigkeitX2;
                abgeprallt = true;
            }

            if (neuY < 0)
            {
                neuY = 0;
                _GeschwindigkeitY2 = -_GeschwindigkeitY2;
                abgeprallt = true;
            }
            else if (neuY + pictureBox1.Height > feld.Height)
            {
                neuY = feld.Height - pictureBox1.Height;
                _GeschwindigkeitY2 = -_GeschwindigkeitY2;
                abgeprallt = true;
            }

            pictureBox1.Location = new Point(neuX, neuY);
            pictureBox2.Location = new Point(neuX, neuY);
            pictureBox3.Location = new Point(neuX, neuY);  
            pictureBox4.Location = new Point(neuX, neuY);

            if (abgeprallt)
            {
                bool tausch = pictureBox4.Visible;
                pictureBox4.Visible = pictureBox3.Visible;
                pictureBox3.Visible = pictureBox2.Visible;
                pictureBox2.Visible = pictureBox1.Visible;
                pictureBox1.Visible = tausch;
            }
        }

        private void DVDTimer_Tick(object? sender, EventArgs e)
        {
            Bewegen(ClientSize);
            Invalidate();                      
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

    }
}
