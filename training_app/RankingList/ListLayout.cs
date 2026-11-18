using System.Text;

namespace Aim_Trainer.RankingList
{
    public class ListLayout
    {
        private static string FormatRows (string username, string points, string hitScoreInPercentage, string extra, string time)
        {
            return $"{username,-30}{points,-25}{hitScoreInPercentage,-23}{extra,-20}{time}";
        }

        private static string HitScoreInPrecentegeBar(short percentage, int width = 10)
        {
            int solid = Math.Clamp(percentage * width / 100, 0, width);
            return new string('█', solid) + new string('░', width - solid) + $" {percentage}%";
        }

        public static string RankingEntrysToText(List<RankingEntry> rankinglist)
        {
            var text = new StringBuilder();
            string header = FormatRows("Nutzername", "Punkte", "Trefferquote", "Awards", "Zeit");

            text.AppendLine(FormatRows("Nutzername", "Punkte", "Trefferquote", "Awards", "Zeit"));
            text.AppendLine(new string('-', header.Length + 5));

            if (rankinglist.Count == 0)
            {
                text.AppendLine("(noch keine Einträge)");
                return text.ToString();
            }

            foreach (var entry in (rankinglist))
            {
                text.AppendLine(FormatRows(
                    entry.Username,
                    entry.Score.ToString(),
                    HitScoreInPrecentegeBar(entry.HitScoreInPercent),
                    entry.Extra,
                    entry.CreationDate.ToString("yyyy-MM-dd HH:mm")));
            }
            return text.ToString();
        }
    }
}
