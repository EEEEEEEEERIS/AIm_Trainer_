using Aim_Trainer.GameData;
using Aim_Trainer.RankingList;
using Aim_Trainer.Targets;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Aim_Trainer
{
    public class GameState
    {
        private readonly GameSettings _settings;
        private readonly StartScreen _startScreen;
        public PointsAnimation PointsAnimation { get; } = new();
        private PlayingField _playingField;
        public readonly TargetFactory targetFactory;
        private readonly RankingRepository _repository;
        public System.Windows.Forms.Timer AnimationTimer { get; private set; }
        public Round Round { get; private set; }
        public int points;

        public GameState(GameSettings settings, StartScreen startScreen, PlayingField playingField, RankingRepository repository)
        {
            this._settings = settings;
            this._startScreen = startScreen;
            this._playingField = playingField;
            this._repository = repository;

            AnimationTimer = new System.Windows.Forms.Timer();
            AnimationTimer.Interval = 16;
            Round = new Round();
            targetFactory = new TargetFactory(settings);

            _repository.LoadOrCreateWholeList();
            _repository.lastEnteredName = _repository.LastEnteredName;
        }

        private bool _gameIsStarting;
        public async Task GameStart()
        {
            if (_gameIsStarting)
                return;
            _gameIsStarting = true;

            _playingField.playtimeTimer.Stop();
            Round.Reset();
            Round.RemainingPlaytime = _settings.PlayTime;
            _playingField.PointsCounter.Text = $"Punkte: {Round.Points}";
            _startScreen.Hide();
            _playingField.laughingGIF.Visible = false;
            _playingField.crownGIF.Visible = false;
            _playingField.contextMenuSettings.Enabled = false;
            PointsAnimation.Clear();
            AnimationTimer.Stop();
            targetFactory.targets.Clear();
            await ShowCountdown();

            if (_settings.CurrentModi == GameSettings.Modi.Tracking)
                AnimationTimer.Start();

            targetFactory.AddCircles();
            _playingField.playtimeTimer.Start();
            _gameIsStarting = false;
        }

        private string _countdownText = "";
        public async Task ShowCountdown()
        {
            _playingField.backToStartButton.Enabled = false;
            for (int i = 3; i > 0; i--)
            {
                _countdownText = i.ToString();
                _playingField.backgroundImagePlayingField.Invalidate();
                await Task.Delay(700);
            }
            _countdownText = "LOS!";
            _playingField.backgroundImagePlayingField.Invalidate();
            await Task.Delay(300);

            _countdownText = "";
            _playingField.backgroundImagePlayingField.Invalidate();

            _playingField.backToStartButton.Enabled = true;
        }

        private readonly Font _countdownFont = new("Segoe UI", 72, FontStyle.Bold);
        public void DrawCountdown(Graphics g)
        {
            if (_countdownText == "") return;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            SizeF size = g.MeasureString(_countdownText, _countdownFont);

            float x = (_playingField.backgroundImagePlayingField.ClientSize.Width - size.Width) / 2;
            float y = (_playingField.backgroundImagePlayingField.ClientSize.Height - size.Height) / 2;

            using var backgroundShade = new SolidBrush(Color.FromArgb(160, Color.Black));
            g.DrawString(_countdownText, _countdownFont, backgroundShade, x + 4, y + 4);

            g.DrawString(_countdownText, _countdownFont, Brushes.White, x, y);
        }


        public async void PlayTimeTimer_Event()
        {
            Round.RemainingPlaytime = Round.RemainingPlaytime - 1;
            _playingField.showsTimeAslabel.Text = "Zeit:" + Round.RemainingPlaytime;

            if (Round.RemainingPlaytime <= 0)
            {
                if (_settings.PlayTime == 30 && Round.Hits <= 0 && _settings.CurrentDifficulty != GameSettings.Difficulty.Easy)
                {
                    _playingField.heartAnimation.ResetEnding();

                    _playingField.heartAnimation.Show();

                    _playingField.playtimeTimer.Stop();
                    return;
                }
                await GameOver();
                return;
            }
            if (_settings.CurrentModi == GameSettings.Modi.Tracking)
            {
                return;
            }
            targetFactory.LifeTimeManager();
        }

        public void PlayingField_MouseClick_Event(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            Round.Clicks++;

            foreach (AimTarget target in targetFactory.targets)
            {
                 points = ScoreCalculator.CheckingForPoints(e, target);
                if (points == 0) continue;

                Round.Points += points;
                Round.Hits++;

                PointsAnimation.Add(points, e.X, e.Y);

                _playingField.PointsCounter.Text = "Punkte: " + Round.Points;
                targetFactory.RenewPositionOfTargets(target);
            }
        }

        public void AnimationTimer_Event()
        {
            PointsAnimation.Renew(AnimationTimer.Interval);

            if (_playingField.playtimeTimer.Enabled)
            {
                targetFactory.TrackingAnimation(_playingField.backgroundImagePlayingField.ClientSize);
            }

            _playingField.backgroundImagePlayingField.Invalidate();
        }

        public async Task GameOver()
        {
            string noHitEmoticon = "(꒪▿꒪)";
            string award = "♛";
            _playingField.contextMenuSettings.Enabled = true;
            _playingField.playtimeTimer.Stop();
            AnimationTimer.Stop();
            var difficultyLevel = _settings.CurrentDifficulty;

            await _playingField.NoHitEvent();
            await _playingField.CrownEvent();

            if (Round.NoHitEvent)
            {
                Round.NoHitEmoticon = " " + noHitEmoticon;
            }
            if (Round.CrownEvent)
            {
                Round.Award = " " + award;
            }
            _repository.GameEvaluation(Round);
            _repository.ShowRankingAccordingToDifficulty(difficultyLevel);
        }

        public void Return_to_Startscreen()
        {
            AnimationTimer.Stop();
            _startScreen.Show();
            _playingField.playtimeTimer.Stop();
        }
    }
}


