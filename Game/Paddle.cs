namespace BrutalPong.Game;

public sealed class Paddle
{
    public Paddle(float x, float centerY, float width, float height, float speed)
    {
        X = x;
        CenterY = centerY;
        Width = width;
        Height = height;
        Speed = speed;
    }

    public float X { get; }
    public float CenterY { get; set; }
    public float Width { get; }
    public float Height { get; }
    public float Speed { get; }
    public float Top => CenterY - Height / 2;
    public float Bottom => CenterY + Height / 2;

    public void ClampTo(float playfieldHeight) =>
        CenterY = Math.Clamp(CenterY, Height / 2, playfieldHeight - Height / 2);
}
