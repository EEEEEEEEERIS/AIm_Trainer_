using Aim_Trainer.Targets;
using System;

namespace Aim_Trainer.RankingList
{
    public static class ScoreCalculator
    {
        private static double CalculateTarget(AimTarget target, MouseEventArgs e)
        {
            //berechenet den mittelpunkt des kreises 
            int middleX = target.X + target.Size / 2;
            int middleY = target.Y + target.Size / 2;

            //abstand des clicks zum mitte des kreises
            double distance =
                Math.Sqrt(
                Math.Pow(e.X - middleX, 2) +
                Math.Pow(e.Y - middleY, 2));

            return distance;
        }

        private static int CalculatePointsforPositiveTargets(AimTarget target, MouseEventArgs e)
        {
            double distance = CalculateTarget(target, e);

            //radius des kreises wird gegengeprüft mit dem abstand den click zum mittelpunkt des kreises hatte. Wenn weniger wie der radius wurde der kreis logischerweise getroffen
            //punktzahl regelungen weniger abstand zur mitte=mehr punkte kleineres ziel =mehr punkte 
            if (distance == 0)
            {
                if (target.Size <= 40)
                {
                    return 13;
                }

                return 10;

            }
            else if (distance <= 10)
            {
                if (target.Size <= 40)
                {
                    return 8;
                }

                return 5;

            }
            else if (distance <= target.Size / 2)
            {
                if (target.Size <= 40)
                {
                    return 3;
                }
                return 1;
            }

            return 0;
        }

        private static int CalculatePointsforNegativeTargets(AimTarget target, MouseEventArgs e)
        {
            double dsitance = CalculateTarget(target, e);
            //mehr minus punktze desto großer die Zielscheibe war
            if (dsitance <= target.Size / 2)
            {
                if (target.Size >= 40)
                {
                    return -3;
                }
                return -1;
            }
            return 0;
        }

        public static int CheckingForPoints(MouseEventArgs e, AimTarget target)
        {
            if (target.IsPositive)
            {
                return CalculatePointsforPositiveTargets(target, e);
            }

            return CalculatePointsforNegativeTargets(target, e);
        }
    }
}

