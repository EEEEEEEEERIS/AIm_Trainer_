using Aim_Trainer.GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aim_Trainer.Targets
{
    public class TargetFactory
    {
        private readonly Random _randomNumber = new();
        private readonly GameSettings _settings;
        private const int UPPERLIMITOFTARGETS = 20;
        private readonly Random _random = new();
        public readonly List<AimTarget> targets = [];
        private Size _playingFieldSize => _settings.PlayingFieldSize; 


        public TargetFactory(GameSettings settings)
        {
            _settings = settings;
        }

        public void RenewPositionOfTargets(AimTarget targets)
        {
            targets.X = _randomNumber.Next(Math.Max(1, _playingFieldSize.Width - targets.Size));
            targets.Y = _randomNumber.Next(Math.Max(1, _playingFieldSize.Height - targets.Size));
        }

        private AimTarget NewTarget(bool IsPositive)
        {
            var target = new AimTarget
            {
                Size = _settings.NewSize(_randomNumber),
                TimeOfExistence = (int)_settings.NewExistenceTime(_randomNumber),
                colour = IsPositive ? _settings.ColourforPositiveTargets : _settings.ColourforNegativeTargets,
                colourForTargetsInnerCircle = _settings.ColourForTargetsInnerCircle,
                IsPositive = IsPositive,
            };

            if (_settings.CurrentModi == GameSettings.Modi.Tracking)
            {
                //zufälliger start wert
                target.SpeedX = _random.Next(-2, 3);
                target.SpeedY = _random.Next(-2, 3);

                // falls zufällig ==0 dann automatisch =3 
                if (target.SpeedX == 0) target.SpeedX = 3;
            }

            RenewPositionOfTargets(target);
            return target;
        }

        private void Renew(AimTarget target)
        {
            target.Size = _settings.NewSize(_randomNumber);
            target.TimeOfExistence = (int)_settings.NewExistenceTime(_randomNumber);
            RenewPositionOfTargets(target);
        }

        private void RandomCreate(List<AimTarget> tragets)
        {
            if (_settings.CurrentModi == GameSettings.Modi.Wack_a_Mole)
            {
                return;
            }
            if (_randomNumber.Next(100) < 50 && tragets.Count < UPPERLIMITOFTARGETS)
                tragets.Add(NewTarget(true));

            if (_randomNumber.Next(100) < 50 && tragets.Count < UPPERLIMITOFTARGETS)
                tragets.Add(NewTarget(false));
        }

        public void AddCircles()
        {
            var (positiveTargetsAmount, negativeTargetsAmount) = _settings.CircleDistribution;

            for (int i = 0; i < positiveTargetsAmount; i++)
                targets.Add(NewTarget(true));

            for (int i = 0; i < negativeTargetsAmount; i++)
                targets.Add(NewTarget(false));
        }

        public void LifeTimeManager()
        {
            for (int i = 0; i < targets.Count; i++)
            {
                targets[i].TimeOfExistence--;

                if (targets[i].TimeOfExistence <= 0)
                {
                    Renew(targets[i]);
                    RandomCreate(targets);
                }
            }
        }

        public void DrawTargets(PaintEventArgs e)
        {
            foreach (AimTarget target in targets)
            {
                target.Draw(e.Graphics);
            }
        }
       
        public void TrackingAnimation(Size area)
        {
            foreach (AimTarget target in targets)
            {
                target.Move(area);
            }
        }
    }
}
