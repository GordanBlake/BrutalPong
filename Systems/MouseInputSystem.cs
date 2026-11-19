using BrutalPong.Game;

namespace BrutalPong.Systems;

public sealed class MouseInputSystem
{
    public void Update(Player player, double mouseY, int windowHeight)
    {
        if (windowHeight <= 0)
            return;

        player.Paddle.CenterY = (float)(mouseY * (720d / windowHeight));
        player.Paddle.ClampTo(720);
    }
}
