using Aim_Trainer.RankingList;
using Aim_Trainer.Targets;
using System.Drawing;
using System.Windows.Forms;


namespace TestProject1
{
    public class PunkteBerechnenTests
    {
        private static AimTarget NeuerKreis(bool istPositiv)
        {
            return new AimTarget
            {
                X = 100,
                Y = 100,
                Size = 40,
                IsPositive = istPositiv,
                colour = new SolidBrush(Color.Red),
                colourForTargetsInnerCircle = new SolidBrush(Color.White)
            };
        }

        [Fact]   // <-- sagt xUnit: "das ist ein Test"
        public void KlickDaneben_GibtKeinePunkte()
        {
            var kreis = NeuerKreis(true);
            var klick = new MouseEventArgs(MouseButtons.Left, 1, 500, 500, 0);

            // Action bzw. methode die geprüft wird
            int punkte = ScoreCalculator.CalculatePointsforPositiveTargets(kreis, klick);

            // Erwartung was passieren solllte wenn die methode ausgeführt wird 
            Assert.Equal(0, punkte);
        }

        [Fact]
        public void KlickInDerMitte_GibtPunkte()
        {
            var kreis = NeuerKreis(true);
            var klick = new MouseEventArgs(MouseButtons.Left, 1, 120, 120, 0);

           
            int punkte = ScoreCalculator.CalculatePointsforPositiveTargets(kreis, klick);

            Assert.Equal(13, punkte);
        }


        [Fact]
        public void MitteGibtMehrAlsRand()
        {
            var kreis = NeuerKreis(true);
            var klickMitte = new MouseEventArgs(MouseButtons.Left, 1, 120, 120, 0);
            var klickRand = new MouseEventArgs(MouseButtons.Left, 1, 136, 120, 0);

           
            int mitte = ScoreCalculator.CalculatePointsforPositiveTargets(kreis, klickMitte);
            int rand = ScoreCalculator.CalculatePointsforPositiveTargets(kreis, klickRand);

            
            Assert.True(mitte > rand);
        }

    }
}




