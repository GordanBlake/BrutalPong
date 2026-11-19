using Brutal.GlfwApi;
using Brutal.Numerics;
using BrutalPong.Game;
using BrutalPong.Rendering;
using BrutalPong.Systems;

if (!Glfw.Init())
    throw new InvalidOperationException("Failed to initialize GLFW.");

GlfwWindow? window = null;
try
{
    Glfw.WindowHint(GlfwWindowHint.ContextVersionMajor, 2);
    Glfw.WindowHint(GlfwWindowHint.ContextVersionMinor, 1);
    window = Glfw.CreateWindow(new GlfwWindow.CreateInfo
    {
        Title = "BRUTAL PONG",
        Size = new int2(1280, 720),
    });
    window.MakeContextCurrent();

    var game = new PongGame();
    var mouseInput = new MouseInputSystem();
    var restartInput = new RestartInputSystem();
    var opponent = new OpponentSystem();
    var physics = new PongPhysicsSystem();
    var renderer = new PongRenderer();
    var previousTime = Glfw.Time;

    while (!window.ShouldClose)
    {
        Glfw.PollEvents();

        var currentTime = Glfw.Time;
        var deltaTime = (float)Math.Clamp(currentTime - previousTime, 0, 0.05);
        previousTime = currentTime;

        var windowSize = window.Size;
        mouseInput.Update(game.PlayerOne, window.CursorPos.Y, windowSize.Y);
        restartInput.Update(window, game);
        opponent.Update(game.PlayerTwo, game.Ball, deltaTime, 720);
        physics.Update(game, deltaTime, 1280, 720);
        var framebufferSize = window.FramebufferSize;
        renderer.Draw(game, framebufferSize.X, framebufferSize.Y);
        window.SwapBuffers();
    }
}
finally
{
    window?.Dispose();
    Glfw.Terminate();
}
