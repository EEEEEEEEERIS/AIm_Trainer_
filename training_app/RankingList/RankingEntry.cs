using Aim_Trainer.GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aim_Trainer.RankingList
{
    public class RankingEntry
    {
        public string Username {  get; set; } = string.Empty;
        public int Score { get; set; }
        public short HitScoreInPercent { get; set; }
        public DateTime CreationDate { get; set; }
        public string Extra { get; set; } = "";

        public GameSettings.Difficulty Difficulty { get; set; }
    }
}
