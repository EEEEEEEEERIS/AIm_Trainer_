namespace Aim_Trainer.Targets
{
    public class PointsAnimation
    {
        private const int EXISTENCETIME = 300; // wie lange der text sichtbar bleibt
        private const float TEMPO = 4.0f;//wie viel pixel der text pro tick nach oben steigt
        private readonly List<PointsAnimationManager> _animationData = [];//speichert die Punktzahlen als text um sie später auszugeben, gut für wenn mehrere klicks hintereinader damit keine verloren gehen
        private readonly Font _font = new("Segoe UI", 16, FontStyle.Bold);

        public void Add(int points, float x, float y)//übergabe werte von der Punktzahl welche gerade erreicht wurde, sowie x und y koordinate des klicks der es ausgelöst hat (Form1 MausClick)
        {
            string text;
            Color colour;

            if (points > 0)
            {
                text = "+" + points.ToString();//int punkte müssen in string convertiert werden um nacher von der Draw methode ausgeführt werden zu können
                colour = Color.Lime;
            }
            else
            {
                text = points.ToString();
                colour = Color.OrangeRed;
            }//methode wird bei keinem treffer gar nicht aufgerufen da die schleife früher verlassen wird dadurch

            _animationData.Add(new PointsAnimationManager
            {
                Text = text,
                X = x,
                Y = y,
                Colour = colour,
                ExistenceTimeTotal = EXISTENCETIME,
                ExistenceTimeLeftOver = EXISTENCETIME
            });
        }

        public void Renew(int pastTick) //16 ticks
        {
            foreach (PointsAnimationManager text in _animationData)
            {
                text.ExistenceTimeLeftOver = text.ExistenceTimeLeftOver - pastTick;
                text.Y = text.Y - TEMPO;// sorgt dafür das der text nach oben floatet nimmt y koordinate -2.00 (y läuft anderum als mormal -=oben)
            }

            // von hinten nach vorne entfernen
            for (int i = _animationData.Count - 1; i >= 0; i--)
            {
                if (_animationData[i].ExistenceTimeLeftOver <= 0)
                {
                    _animationData.RemoveAt(i);
                }
            }
        }

        public void Draw(Graphics g)
        {
            foreach (PointsAnimationManager text in _animationData)
            {
                int colorIntensity = (int)(255 * text.Visibility);

                using var backgroundShadow = new SolidBrush(Color.FromArgb(colorIntensity / 2, Color.Black));
                g.DrawString(text.Text, _font, backgroundShadow, text.X + 2, text.Y + 2);

                using var paintBrush = new SolidBrush(Color.FromArgb(colorIntensity, text.Colour));
                g.DrawString(text.Text, _font, paintBrush, text.X, text.Y);
            }
        }

        public void Clear()
        {
            _animationData.Clear();
        }
    }
}

