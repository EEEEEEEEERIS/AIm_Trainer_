namespace Aim_Trainer.Targets
{
    public class AimTarget
    {
        public int X;
        public int Y;
        public int Size;
        public int TimeOfExistence;
        public required Brush colour;
        public required Brush colourForTargetsInnerCircle;
        public bool IsPositive;

        public void Draw(Graphics g)
        {
            g.FillEllipse(colour!, X, Y, Size, Size);

            g.FillEllipse(colourForTargetsInnerCircle!,
                X + Size * 0.2f,
                Y + Size * 0.2f,
                Size * 0.6f,
                Size * 0.6f);

            g.FillEllipse(colour!,
                X + Size * 0.4f,
                Y + Size * 0.4f,
                Size * 0.2f,
                Size * 0.2f);
        }

        public float SpeedX { get; set; }
        public float SpeedY { get; set; }

        public void Move(Size feld)
        {
            //aktuelle koordinaten des kreis + den GeschwindigkeitsWert sorgen für kontenuirleche bewegung 
            X += (int)SpeedX;
            Y += (int)SpeedY;

            if (X < 0)
            {
                X = 0;
                SpeedX = -SpeedX;
            }
            else if (X + Size > feld.Width)
            {
                X = feld.Width - Size;
                SpeedX = -SpeedX;
            }
            if (Y < 0)
            {
                Y = 0;
                SpeedY = -SpeedY;
            }
            else if (Y + Size > feld.Height)
            {
                Y = feld.Height - Size;
                SpeedY = -SpeedY;
            }
        }
    }
}

