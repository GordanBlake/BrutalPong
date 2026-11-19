namespace BrutalPong.Game;

public sealed class Player
{
    public Player(string name, Paddle paddle)
    {
        Name = name;
        Paddle = paddle;
    }

    public string Name { get; }
    public Paddle Paddle { get; }
    public int Score { get; private set; }

    public void AwardPoint() => Score++;
    public void ResetScore() => Score = 0;
}
