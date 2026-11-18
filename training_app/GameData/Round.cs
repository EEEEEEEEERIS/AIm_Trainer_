namespace Aim_Trainer.GameData
{
    public class Round
    {
        public int Points { get; set; }
        public int Clicks { get; set; }
        public int Hits { get; set; }
        public string Award { get; set; } = "";
        public string NoHitEmoticon { get; set; } = "";
        public bool NoHitEvent { get; set; }
        public bool CrownEvent { get; set; }
        public int RemainingPlaytime { get; set; }
        public int Hitquote
        {
            get
            {
                if (Clicks <= 0)
                {
                    return 0;
                }

                return Hits * 100 / Clicks;
            }
        }
        public string Extra => (Award + NoHitEmoticon).Trim();

        public void Reset()
        {
            Points = 0;
            Clicks = 0;
            Hits = 0;
            Award = "";
            NoHitEmoticon = "";
            NoHitEvent = false;
            CrownEvent = false;
        }
    }
}
