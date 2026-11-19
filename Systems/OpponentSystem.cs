using BrutalPong.Game;

namespace BrutalPong.Systems;

public sealed class OpponentSystem
{
    public void Update(Player opponent, Ball ball, float deltaTime, int playfieldHeight)
    {
        var paddle = opponent.Paddle;
        var distance = ball.Y - paddle.CenterY;
        var movement = Math.Clamp(distance, -paddle.Speed * deltaTime, paddle.Speed * deltaTime);
        paddle.CenterY += movement;
        paddle.ClampTo(playfieldHeight);
    }
}
