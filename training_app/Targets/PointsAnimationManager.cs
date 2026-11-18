namespace Aim_Trainer.Targets
{
    public class PointsAnimationManager
    {
        public string Text { get; init; } = "";//text ist am anfang leer bzw. wenn keine Punkte erzielt werden--> fehl klick
        public float X { get; set; }
        public float Y { get; set; }
        public Color Colour { get; init; } = Color.White;
        public int ExistenceTimeTotal { get; init; }
        public int ExistenceTimeLeftOver { get; set; } 
        // 1.0 = gerade erschienen, 0.0 = gleich weg
        public float Visibility => Math.Clamp(ExistenceTimeLeftOver / (float)ExistenceTimeTotal, 0f, 1f);//gibt werte von 1.00-0.00 welcher den grad der sichbarkeit des Textes darstellt 
    }
}
