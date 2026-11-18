using Aim_Trainer.GameData;
using Aim_Trainer.RankingList;
using Aim_Trainer.Targets;

namespace Aim_Trainer
{
    public partial class PlayingField : Form
    {
        public readonly Heart heartAnimation = new();
        private readonly StartScreen _startScreen = new();
        private readonly GameState _gameState;
        private readonly RankingRepository _repository = new();
        private readonly GameSettings _settings = new();

        public PlayingField()
        {
            InitializeComponent();
            SetupBackgroundImagePlayingField();
            InitializeCustomControls();

            playtimeTimer.Interval = 1000;
            playtimeTimer.Tick += PlayTimeTimer_Tick;

            _gameState = new GameState(_settings, _startScreen, this, _repository);
            _gameState.AnimationTimer.Tick += AnimationTimer_Tick;
        }

        private void SetupBackgroundImagePlayingField()
        {
            backgroundImagePlayingField.Dock = DockStyle.Fill;
            backgroundImagePlayingField.SizeMode = PictureBoxSizeMode.StretchImage;
            backgroundImagePlayingField.ContextMenuStrip = contextMenuSettings;
            backgroundImagePlayingField.Cursor = Cursors.Cross;
            _settings.PlayingFieldSize = backgroundImagePlayingField.ClientSize;
            backgroundImagePlayingField.Resize += (s, e) => _settings.PlayingFieldSize = backgroundImagePlayingField.ClientSize;
            backgroundImagePlayingField.Paint += PlayingField_Paint;
            backgroundImagePlayingField.MouseDown += PlayingField_MouseClick;
        }

        private void InitializeCustomControls()
        {
            laughingGIF.Visible = false;
            laughingGIF.SizeMode = PictureBoxSizeMode.StretchImage;
            crownGIF.SizeMode = PictureBoxSizeMode.StretchImage;

            Controls.Add(heartAnimation);
            heartAnimation.Dock = DockStyle.Fill;
            heartAnimation.BringToFront();
            heartAnimation.Hide();
            heartAnimation.SecretEndingHeart += SecretEndingHeart;

            Controls.Add(_startScreen);
            _startScreen.Dock = DockStyle.Fill;
            _startScreen.BringToFront();
            _startScreen.Show();
            _startScreen.StartTitleAnimation();

            _startScreen.GameStart += async (s, e) => await _gameState.GameStart();
            _startScreen.ShowList += (s, e) => _repository.ShowList(_repository.BestUsers(), "Rangliste", true);
            _startScreen.ShowMenu += (s, e) => ShowMenu();
        }

        private async void Start_Button_Click(object sender, EventArgs e)
        {
            _startScreen.Hide();
            await _gameState.GameStart();
        }

        private void Return_to_Startscreen_Click(object sender, EventArgs e)
        {
            _gameState.Return_to_Startscreen();
        }

        private async void PlayTimeTimer_Tick(object? sender, EventArgs e)
        {
            _gameState.PlayTimeTimer_Event();
        }
      
        private void PlayingField_Paint(object? sender, PaintEventArgs e)
        {
            _gameState.targetFactory.DrawTargets(e);
            _gameState.AnimationTimer.Start();
            _gameState.PointsAnimation.Draw(e.Graphics);
            _gameState.DrawCountdown(e.Graphics);
        }

        public void PlayingField_MouseClick(object? sender, MouseEventArgs e)
        {
             _gameState.PlayingField_MouseClick_Event(e);
        }

       private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            _gameState.AnimationTimer_Event();
        }

        public void ShowMenu()
        {
            contextMenuSettings.Enabled = true;
            contextMenuSettings.Show(_startScreen, new Point(50, 50));
        }

        private async void SecretEndingHeart(object? sender, EventArgs e)
        {
            heartAnimation.Hide();
            await _gameState.GameOver();
        }

        public async Task NoHitEvent()
        {
            if (_gameState.Round.Hits <= 0 && _settings.CurrentDifficulty == GameSettings.Difficulty.Easy)
            {
                heartAnimation.Hide();
                _gameState.Round.NoHitEvent = true;
                MessageBox.Show(".");
                MessageBox.Show("..");
                MessageBox.Show("...");
                MessageBox.Show("....");
                MessageBox.Show("....Really?...Not even one?");

                laughingGIF.Visible = true;

                laughingGIF.Dock = DockStyle.Fill;
                laughingGIF.BringToFront();

                await Task.Delay(5000);

                laughingGIF.Visible = false;
            }
        }

        public async Task CrownEvent()
        {
            if (_settings.CurrentDifficulty == GameSettings.Difficulty.Hard)
            {
                if (_settings.PlayTime == 10 && _gameState.Round.Hits >= 60
                 || _settings.PlayTime == 20 && _gameState.Round.Hits >= 80
                 || _settings.PlayTime == 30 && _gameState.Round.Hits >= 100)

                {
                    _gameState.Round.CrownEvent = true;
                    heartAnimation.Hide();
                    MessageBox.Show("WoW");
                    crownGIF.Visible = true;
                    crownGIF.Dock = DockStyle.Fill;
                    crownGIF.BringToFront();

                    await Task.Delay(5000);

                    crownGIF.Visible = false;
                }
            }
        }
       
        private async void GameMenuOpen(object sender, EventArgs e)
        {
            playtimeTimer.Stop();

            if (contextMenuSettings.Enabled)
            {
                contextMenuSettings.Show(this, new Point(100, 100));
            }

            else
            {
                noGIF.Visible = true;
                noGIF.Dock = DockStyle.Fill;
                noGIF.BringToFront();
                await Task.Delay(3000);
                noGIF.Visible = false;
                playtimeTimer.Start();
            }
        }

        private void WholeRankingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.ShowList(_repository.BestUsers(), "Gesamte Rangliste- Alle Spieler von alle Schwierigkeitsstufen", true);
        }

        private void RankingMediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _repository.ShowRankingAccordingToDifficulty(GameSettings.Difficulty.Medium);
        }

        private void RankingEasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.ShowRankingAccordingToDifficulty(GameSettings.Difficulty.Easy);
        }

        private void RankingHardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _repository.ShowRankingAccordingToDifficulty(GameSettings.Difficulty.Hard);
        }

        private void UserHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.PrepareUserHistoryEntry();
        }

        private void ColorChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.ColourChange();
        }

        private void PlayersTodayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.ShowList(_repository.PlayersToday(), "Heutige Spieler", true);
        }

        private void PlayersThisWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.ShowList(_repository.PlayersThisWeek(), "Spieler diese Woche", true);
        }

        private void RankingAccordingToHitScoreInPercentegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.ShowList(_repository.SortedAfterHitScoreInPercentage(), "Trefferquote Sortiert", true);
        }

        private void PlayTime10SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseTime(10);
        }

        private void PlayTime20SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseTime(20);
        }

        private void PlayTime30SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseTime(30);
        }

        private void ChooseTime(int seconds)
        {
            _settings.PlayTime = seconds;
        }

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e) => _settings.CurrentDifficulty = GameSettings.Difficulty.Easy;
        private void MediumToolStripMenuItem_Click(object sender, EventArgs e) => _settings.CurrentDifficulty = GameSettings.Difficulty.Medium;
        private void HardToolStripMenuItem_Click(object sender, EventArgs e) => _settings.CurrentDifficulty = GameSettings.Difficulty.Hard;

        private void TrackingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.CurrentModi = GameSettings.Modi.Tracking;
        }
        private void NormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.CurrentModi = GameSettings.Modi.Normal;
        }

        private void WackaMoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings.CurrentModi = GameSettings.Modi.Wack_a_Mole;
        }
    }
}
