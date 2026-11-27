using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Aim_Trainer
{
    public partial class Moorhuhn : UserControl
    {
        public Moorhuhn()
        {
            InitializeComponent();
            _moorhuhnAnimationTimer.Tick += MoorhuhnAnimationTimer_Tick;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        private float _GeschwindigkeitX { get; set; } = 15;
        public readonly System.Windows.Forms.Timer _moorhuhnAnimationTimer = new() { Interval = 16 };

        private readonly Image _moorhuhnImage = Properties.Resources.moorhunh;
        public int chickenSize = 80;
        private const int SmallChicken = 50;
        private const int BigChicken = 120;
        private int _xLocation;
        public event EventHandler? MoorhuhnHit;
        private Rectangle ChickenArea => new(_xLocation, 50, chickenSize, chickenSize );
        private readonly Random _random = new();

        public void AnimateMoorhuhn()
        {

            if (_moorhuhnAnimationTimer.Enabled)
                return;
            _xLocation = -chickenSize;

            if (_random.Next(2) == 0)
            {
                chickenSize = SmallChicken;
            }
            else
            {
                chickenSize = BigChicken;
            }
            _moorhuhnAnimationTimer.Start();
            Show();
            BringToFront();
        }

        public void MoorHuhnBewegen(Size feld)
        {
            int neuX = _xLocation + (int)_GeschwindigkeitX;

            if (neuX > feld.Width)
            {
               _moorhuhnAnimationTimer.Stop();
                Hide();
                return;
            }
            _xLocation = neuX;
        }

        private void MoorhuhnAnimationTimer_Tick(object? sender, EventArgs e)
        {
            MoorHuhnBewegen(ClientSize);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(_moorhuhnImage, _xLocation, 50, chickenSize, chickenSize);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!ChickenArea.Contains(e.Location))
                return;

            _moorhuhnAnimationTimer.Stop();
            Hide();
            MoorhuhnHit?.Invoke(this, EventArgs.Empty);
        }
    }
}

