using BrutalPong.Game;

namespace BrutalPong.Systems;

public sealed class PongPhysicsSystem
{
    public void Update(PongGame game, float deltaTime, int width, int height)
    {
        if (width <= 0 || height <= 0)
            return;

        if (game.IsGameOver)
        {
            game.Ball.VelocityX = 0;
            game.Ball.VelocityY = 0;
            return;
        }

        var ball = game.Ball;
        ball.X += ball.VelocityX * deltaTime;
        ball.Y += ball.VelocityY * deltaTime;

        if (ball.Y - ball.Radius < 0)
        {
            ball.Y = ball.Radius;
            ball.VelocityY = Math.Abs(ball.VelocityY);
        }
        else if (ball.Y + ball.Radius > height)
        {
            ball.Y = height - ball.Radius;
            ball.VelocityY = -Math.Abs(ball.VelocityY);
        }

        if (ball.VelocityX < 0 && HitsPaddle(ball, game.PlayerOne.Paddle))
            BounceFromPaddle(ball, game.PlayerOne.Paddle, 1);
        else if (ball.VelocityX > 0 && HitsPaddle(ball, game.PlayerTwo.Paddle))
            BounceFromPaddle(ball, game.PlayerTwo.Paddle, -1);

        if (ball.X + ball.Radius < 0)
            game.AwardPoint(game.PlayerTwo);
        else if (ball.X - ball.Radius > width)
            game.AwardPoint(game.PlayerOne);
    }

    private static bool HitsPaddle(Ball ball, Paddle paddle) =>
        ball.X - ball.Radius <= paddle.X + paddle.Width / 2 &&
        ball.X + ball.Radius >= paddle.X - paddle.Width / 2 &&
        ball.Y + ball.Radius >= paddle.Top &&
        ball.Y - ball.Radius <= paddle.Bottom;

    private static void BounceFromPaddle(Ball ball, Paddle paddle, float direction)
    {
        var impact = Math.Clamp((ball.Y - paddle.CenterY) / (paddle.Height / 2), -1, 1);
        var speed = Math.Min(MathF.Sqrt(ball.VelocityX * ball.VelocityX + ball.VelocityY * ball.VelocityY) * 1.06f, 900);
        ball.VelocityX = direction * speed * MathF.Cos(impact * 0.95f);
        ball.VelocityY = speed * MathF.Sin(impact * 0.95f);
        ball.X = paddle.X - direction * (paddle.Width / 2 + ball.Radius);
    }
}
