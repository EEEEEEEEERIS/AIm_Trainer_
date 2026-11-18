namespace Aim_Trainer.Targets
{
    public interface IAimTarget
    {
        float SpeedX { get; set; }
        float SpeedY { get; set; }

        void Draw(Graphics g);
        void Move(Size feld);
    }
}