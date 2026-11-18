using Aim_Trainer.GameData;

namespace Aim_Trainer
{
    public partial class StartScreen : UserControl
    {
        public event EventHandler? GameStart;
        public event EventHandler? ShowList;
        public event EventHandler? ShowMenu;

        private readonly List<TitleLetters> _titel_characters = [];
        private readonly System.Windows.Forms.Timer _animationTimer = new();
        private float _progress = 0f;
        private Font _titelFont = new("Segoe UI", 48, FontStyle.Bold);
        private readonly Random _random = new();
        private readonly DVD _dvd= new();

        public StartScreen()
        {
            InitializeComponent();
            Resize += (s, e) => { CenterButtons(); PrepareTitle(); };
            CenterButtons();
            startScreenBackground.SizeMode = PictureBoxSizeMode.StretchImage;

            startScreenBackground.Dock = DockStyle.Fill;
            startScreenBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            startScreenBackground.SendToBack();

            startScreenBackground.Paint += StartScreen_Paint;

            _animationTimer.Interval = 16;
            _animationTimer.Tick += AnimTimer_Tick;

            PrepareTitle();
            _animationTimer.Start();

            Controls.Add(_dvd);
            _dvd.Dock = DockStyle.Fill;   
        }

        private void StartScreen_Paint(object? sender, PaintEventArgs e)
        {
            foreach (var movingCharacter in _titel_characters)
            {
                e.Graphics.DrawString(movingCharacter.Draw.ToString(), _titelFont,
                    Brushes.White, movingCharacter.X, movingCharacter.Y);
            }
        }
        private void AnimTimer_Tick(object? sender, EventArgs e)
        {
            _progress += 0.02f;

            if (_progress >= 1f)
            {
                _progress = 1f;
                _animationTimer.Stop();
            }

            float t = 1 - (1 - _progress) * (1 - _progress);

            foreach (var movingCharacter in _titel_characters)
            {
                movingCharacter.X = movingCharacter.StartX + (movingCharacter.DestinationX - movingCharacter.StartX) * t;
                movingCharacter.Y = movingCharacter.StartY + (movingCharacter.DestinationY - movingCharacter.StartY) * t;
            }

            startScreenBackground.Invalidate();
        }

        private void PrepareTitle()
        {
            const string titel = "AIM TRAINER";
            _titel_characters.Clear();
            _progress = 0f;

            float fontsize = Math.Clamp(Width / 14f, 28f, 90f);
            _titelFont = new Font("Segoe UI", fontsize, FontStyle.Bold);

            // Gesamtbreite messen, um den Text zu zentrieren
            using var g = CreateGraphics();
            float totalWidth = g.MeasureString(titel, _titelFont).Width;

            //ziel x=mitte y=über den buttons mit 30 abstand
            float x = (startScreenBackground.Width - totalWidth) / 2;
            float y = Math.Max(20, CenterButtons() - _titelFont.Height - 30);

            foreach (char movingCharacter in titel)
            {
                float width = g.MeasureString(movingCharacter.ToString(), _titelFont).Width;

                _titel_characters.Add(new TitleLetters
                {
                    Draw = movingCharacter,
                    DestinationX = x,
                    DestinationY = y,

                    StartX = _random.Next(-400, startScreenBackground.Width + 400),
                    StartY = _random.Next(-300, startScreenBackground.Height + 300),
                    X = x,
                    Y = y
                });
                x += width - fontsize / 3.7f;
            }
        }

        public void StartTitleAnimation()
        {
            PrepareTitle();
            _animationTimer.Start();
        }

        private int CenterButtons()
        {
            var buttons = new[] { startButton, showRankinglistButton, SettingsButton, howToPlayButton };
            int distance = 10;

            // Gesamthöhe aller Buttons plus Abstände
            int totalHeight = buttons.Sum(b => b.Height) + distance * (buttons.Length - 1);
            int y = (Height - totalHeight) / 2;
            int centerTitel = (Height - totalHeight) / 2;

            foreach (var button in buttons)
            {
                button.Left = (Width - button.Width) / 2;      // waagerecht mittig
                button.Top = y;
                y += button.Height + distance;             // nächster Button darunter
            }
            return centerTitel;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            GameStart?.Invoke(this, EventArgs.Empty);
        }

        private void ShowRankingListButton_Click(object sender, EventArgs e)
        {
            ShowList?.Invoke(this, EventArgs.Empty);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ShowMenu?.Invoke(this, EventArgs.Empty);
        }

        private void HowToPlayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hit the  {GameSettings.PositiveTargetName} targets as fas as you can. " +
                $"Beware of the  {GameSettings.NegativeTargetName} once which give you minus points." +
                " Choose between three diffrent difficulties and three playtime settings." +
                "If you mess around you might find a thing or two out of the ordinary");
        }

        private async void SecretButton_Click(object sender, EventArgs e)
        {
            startScreenBackground.SendToBack();
            _dvd.Show();
            _dvd.BringToFront();
            await Task.Delay(5000);
            _dvd.Hide();
            secretButton.Hide();
        }
    }
}

