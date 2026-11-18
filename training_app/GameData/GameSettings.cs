using Aim_Trainer.Targets;

namespace Aim_Trainer.GameData
{
    public class GameSettings
    {
        public Difficulty CurrentDifficulty { get; set; } = Difficulty.Medium;
        public int PlayTime { get; set; } = 10;
        private bool _IsColourChanged { get; set; } = false;
        public Brush ColourforPositiveTargets { get; private set; } = Brushes.Red;
        public Brush ColourforNegativeTargets { get; private set; } = Brushes.Green;
        public Brush ColourForTargetsInnerCircle { get; private set; } = Brushes.White;
        public static string PositiveTargetName { get; private set; } = "red";
        public static string NegativeTargetName { get; private set; } = "green";
        public Modi CurrentModi { get; set; } = Modi.Normal;
        private readonly List<AimTarget> _targets = [];
        public Size PlayingFieldSize = new();

        private void ColoursForColourChange()
        {
            _IsColourChanged = !_IsColourChanged;
            if (_IsColourChanged)
            {
                ColourforPositiveTargets = Brushes.Yellow;
                ColourforNegativeTargets = Brushes.DeepSkyBlue;
                ColourForTargetsInnerCircle = Brushes.Black;
                MessageBox.Show("Colours are now Yellow and Blue");

                PositiveTargetName = "yellow";
                NegativeTargetName = "blue";
            }
            else
            {
                ColourforPositiveTargets = Brushes.Red;
                ColourforNegativeTargets = Brushes.Green;
                ColourForTargetsInnerCircle = Brushes.White;
                MessageBox.Show("Colours are now Red and Green");

                PositiveTargetName = "red";
                NegativeTargetName = "green";
            }
        }

        public void ColourChange()
        {
            ColoursForColourChange();

            foreach (AimTarget target in _targets)
            {
                target.colour = target.IsPositive
                    ? ColourforPositiveTargets
                    : ColourforNegativeTargets;

                target.colourForTargetsInnerCircle = ColourForTargetsInnerCircle;
            }
        }

        public (int positiveTargetsAmount, int negativeTargetsAmount) CircleDistribution => (CurrentModi, CurrentDifficulty) switch
        {
            (Modi.Wack_a_Mole, _) => (1, 0),
            (_, Difficulty.Easy) => (20, 5),
            (_, Difficulty.Hard) => (2, 10),
            _ => (7, 7)
        };

        public int NewSize(Random r) => CurrentDifficulty switch
        {
            Difficulty.Easy => r.Next(50, 100),
            Difficulty.Hard => r.Next(15, 20),
            _ => r.Next(20, 60)
        };

        public double NewExistenceTime(Random r) => CurrentModi switch
        {
            Modi.Wack_a_Mole => 0.25,
            _ => CurrentDifficulty switch
            {
                Difficulty.Easy => r.Next(4, 7),
                Difficulty.Hard => r.Next(1, 3),
                _ => r.Next(3, 5)
            }
        };

        public enum Difficulty
        {
            Hard = 1,
            Easy = 2,
            Medium = 3,
        }
        public enum Modi
        {
            Normal = 1,
            Tracking = 2,
            Wack_a_Mole = 3
        }
    }
}
