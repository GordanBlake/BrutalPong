namespace BrutalPong.Game;

public sealed class Ball
{
    public Ball(float radius)
    {
        Radius = radius;
    }

    public float X { get; set; }
    public float Y { get; set; }
    public float VelocityX { get; set; }
    public float VelocityY { get; set; }
    public float Radius { get; }
}
