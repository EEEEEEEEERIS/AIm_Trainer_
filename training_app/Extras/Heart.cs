using System.Drawing.Drawing2D;
using static System.Net.Mime.MediaTypeNames;

namespace Aim_Trainer
{
    public partial class Heart : UserControl
    {
        public event EventHandler? SecretEndingHeart;
        private int _bonusClicks = 0;
        private readonly System.Windows.Forms.Timer _timer;
        private int _time = 0;

        private readonly System.Windows.Forms.Timer _animationTimer = new();
        private double _progress = 0f;
        private PointF[] _heartPoints = [];

        public Heart()
        {
            InitializeComponent();

            _animationTimer.Interval = 16;
            _animationTimer.Start();
            _animationTimer.Tick += AnimationTimerTick;

            Resize += (s, e) => CalculateHeart();

            //hintergrund 
            DoubleBuffered = true;
            Dock = DockStyle.Fill;
            BackColor = Color.Black;

            _timer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

            _timer.Tick += (sender, e) =>
            {
                _time++;
                Invalidate();
            };

            _timer.Start();
        }

        private void AnimationTimerTick(object? sender, EventArgs e)
        {
            _progress += 0.02f;

            if (_progress >= 1f)
            {
                _progress = 0f;
            }

            Invalidate();
        }

        public void ResetEnding()
        {
            _time = 30;
            _bonusClicks = 0;
            CalculateHeart();
            _animationTimer.Start();
            _progress = 0f;
            Invalidate();
        }


        //eescape von control1 in form 1 durch mausklicks 
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            _bonusClicks++;

            if (_bonusClicks >= 10)
            {
                _animationTimer.Stop();
                SecretEndingHeart?.Invoke(this, EventArgs.Empty);
            }
        }


        private void CalculateHeart()
        {
            var points = new PointF[101];

            //damit das herz in der mitte bleitbt 
            float centerX = ClientSize.Width / 2f;
            float centerY = ClientSize.Height / 2f;

            float scale = Math.Min(ClientSize.Width, ClientSize.Height) / 40f;

            for (int i = 0; i <= 100; i++)
            {
                double t = i * 2 * Math.PI / 100;

                double x = 16 * Math.Pow(Math.Sin(t), 3);

                double y =
                    13 * Math.Cos(t)
                    - 5 * Math.Cos(2 * t)
                    - 2 * Math.Cos(3 * t)
                    - Math.Cos(4 * t);

                points[i] = new PointF(
                centerX + (float)(x * scale),
                centerY - (float)(y * scale));
            }

            _heartPoints = points;
            Invalidate();

        }

        private void DrawTextForHeart(Graphics g, float x, float y)
        {
            using GraphicsPath path = new();

            path.AddString(
                "✧",
                Font.FontFamily,
                (int)Font.Style,
                g.DpiY * Font.Size / 72f,
                new PointF(x, y),
                StringFormat.GenericDefault);

            //äußerer glow
            for (int glow = 12; glow >= 2; glow -= 2)
            {
                using Pen glowPen = new(Color.FromArgb(15, 255, 20, 150), glow);
                glowPen.LineJoin = LineJoin.Round;
                g.DrawPath(glowPen, path);
            }

            //innerer glow
            using Pen innerGlow = new(Color.FromArgb(100, 255, 50, 180), 3);
            g.DrawPath(innerGlow, path);

            //eigentliches "Hello"
            using SolidBrush textBrush = new(Color.HotPink);
            g.FillPath(textBrush, path);
        }


        //graphik von control 1
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float t = 1 - (1 - (float)_progress) * (1 - (float)_progress);
            int visibility = (int)(_heartPoints.Length * t);

            //kakuliert in welchen abtand der string geschrieben wird  
            float distance = 0;

            for (int i = 1; i < visibility; i++)
            {
                //abstand von punkt 1 und 2 wird berechnet 
                float dx = _heartPoints[i].X - _heartPoints[i - 1].X;
                float dy = _heartPoints[i].Y - _heartPoints[i - 1].Y;

                //wie weit sind sie von einander entfernt? 
                float segmentLength = (float)Math.Sqrt(dx * dx + dy * dy);

                distance += segmentLength;

                //falls distance größer 60 Pixel wird hello geschrieben verhindert das mehrere hellos in einander gehen 
                if (distance >= 65)
                {
                    DrawTextForHeart(e.Graphics, _heartPoints[i].X - 20, _heartPoints[i].Y - 10);
                    distance = 0;
                }
            }

            string text = "You just wasted " + _time + " seconds of your life. Yipiee!";

            SizeF textSize = e.Graphics.MeasureString(text, Font);

            float centerX = ClientSize.Width / 2f;
            float centerY = ClientSize.Height / 2f;

            float centerTextX = centerX - textSize.Width / 2f;
            float centerTextY = centerY - textSize.Height / 2f;

            e.Graphics.DrawString(
                text,
                Font,
                Brushes.HotPink,
                centerTextX,
                centerTextY
            );

        }
    }
}
