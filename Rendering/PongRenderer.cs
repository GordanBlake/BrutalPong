using BrutalPong.Game;

namespace BrutalPong.Rendering;

public sealed class PongRenderer
{
    private readonly OpenGl _gl = new();

    public void Draw(PongGame game, int width, int height)
    {
        if (width <= 0 || height <= 0)
            return;

        _gl.BeginFrame(width, height);
        var scaleX = width / 1280f;
        var scaleY = height / 720f;

        for (var y = 0; y < 720; y += 28)
            Rectangle(638 * scaleX, y * scaleY, 4 * scaleX, 14 * scaleY, 0.18f, 0.24f, 0.36f);

        Rectangle(0, 0, 5 * scaleX, height, 0.16f, 0.78f, 0.82f);
        Rectangle(width - 5 * scaleX, 0, 5 * scaleX, height, 0.98f, 0.48f, 0.35f);

        DrawPaddle(game.PlayerOne.Paddle, scaleX, scaleY, 0.22f, 0.94f, 0.88f);
        DrawPaddle(game.PlayerTwo.Paddle, scaleX, scaleY, 1f, 0.48f, 0.36f);
        Rectangle(
            (game.Ball.X - game.Ball.Radius) * scaleX,
            (game.Ball.Y - game.Ball.Radius) * scaleY,
            game.Ball.Radius * 2 * scaleX,
            game.Ball.Radius * 2 * scaleY,
            0.98f, 0.94f, 0.82f);

        PixelFont.Draw(this, game.PlayerOne.Score.ToString(), 550 * scaleX, 60 * scaleY, 8 * scaleY, 0.75f, 0.9f, 0.96f);
        PixelFont.Draw(this, game.PlayerTwo.Score.ToString(), 710 * scaleX, 60 * scaleY, 8 * scaleY, 0.98f, 0.65f, 0.53f);
        PixelFont.Draw(this, "PLAYER 1", 42 * scaleX, 26 * scaleY, 2 * scaleY, 0.38f, 0.77f, 0.82f);
        PixelFont.Draw(this, "PLAYER 2", 1150 * scaleX, 26 * scaleY, 2 * scaleY, 0.98f, 0.53f, 0.39f);

        if (game.IsGameOver)
        {
            var winner = game.PlayerOne.Score >= PongGame.WinningScore ? "PLAYER 1 WINS" : "PLAYER 2 WINS";
            PixelFont.Draw(this, winner, 480 * scaleX, 310 * scaleY, 4 * scaleY, 0.98f, 0.94f, 0.82f);
            PixelFont.Draw(this, "GAME OVER", 520 * scaleX, 350 * scaleY, 3 * scaleY, 0.52f, 0.68f, 0.79f);
            PixelFont.Draw(this, "SPACE TO RESTART", 500 * scaleX, 390 * scaleY, 2 * scaleY, 0.45f, 0.56f, 0.69f);
        }
        else
        {
            PixelFont.Draw(this, "MOVE MOUSE TO PLAY", 500 * scaleX, 660 * scaleY, 2 * scaleY, 0.45f, 0.56f, 0.69f);
        }
    }

    internal void Rectangle(float x, float y, float width, float height, float red, float green, float blue) =>
        _gl.FillRectangle(x, y, width, height, red, green, blue);

    private void DrawPaddle(Paddle paddle, float scaleX, float scaleY, float red, float green, float blue)
    {
        Rectangle(
            (paddle.X - paddle.Width / 2) * scaleX,
            paddle.Top * scaleY,
            paddle.Width * scaleX,
            paddle.Height * scaleY,
            red, green, blue);
    }
}
