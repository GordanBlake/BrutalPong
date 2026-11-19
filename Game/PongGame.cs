namespace BrutalPong.Game;

public sealed class PongGame
{
    public const int WinningScore = 7;

    public PongGame()
    {
        PlayerOne = new Player("PLAYER 1", new Paddle(54, 360, 16, 112, 760));
        PlayerTwo = new Player("PLAYER 2", new Paddle(1226, 360, 16, 112, 520));
        Ball = new Ball(10);
        ResetBall(1);
    }

    public Player PlayerOne { get; }
    public Player PlayerTwo { get; }
    public Ball Ball { get; }
    public bool IsGameOver => PlayerOne.Score >= WinningScore || PlayerTwo.Score >= WinningScore;

    public void AwardPoint(Player player)
    {
        player.AwardPoint();
        if (!IsGameOver)
            ResetBall(player == PlayerOne ? -1 : 1);
    }

    public void Restart()
    {
        PlayerOne.ResetScore();
        PlayerTwo.ResetScore();
        ResetBall(1);
    }

    private void ResetBall(float horizontalDirection)
    {
        Ball.X = 640;
        Ball.Y = 360;
        Ball.VelocityX = horizontalDirection * 440;
        Ball.VelocityY = 180;
    }
}
