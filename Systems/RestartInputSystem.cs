using Brutal.GlfwApi;
using BrutalPong.Game;

namespace BrutalPong.Systems;

public sealed class RestartInputSystem
{
    private bool _spaceWasPressed;

    public void Update(GlfwWindow window, PongGame game)
    {
        var spaceIsPressed = window.GetKey(GlfwKey.Space) == GlfwKeyAction.Press;
        if (game.IsGameOver && spaceIsPressed && !_spaceWasPressed)
            game.Restart();

        _spaceWasPressed = spaceIsPressed;
    }
}
