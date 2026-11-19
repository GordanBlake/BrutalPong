# Brutal Pong

A two-player Pong-style desktop game built with C# and .NET. Player 1 is controlled with the mouse, while Player 2 is controlled by a simple opponent system.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A desktop environment with OpenGL support
- On Windows: Windows 10 or later

## Setup

1. Install the .NET 10 SDK.
2. Open a terminal in the project root (the folder containing `BrutalPong.csproj`).
3. Restore the project dependencies:

   ```powershell
   dotnet restore
   ```

## Run the game

Run the project from the terminal:

```powershell
dotnet run
```

The game opens in a 1280 x 720 GLFW window.

To build an executable without starting the game:

```powershell
dotnet build
```

The output is written to `bin\Debug\net10.0\`.

You can also open `BrutalPong.csproj` in Visual Studio or VS Code, restore dependencies if prompted, and start debugging.

## Controls

- **Move the mouse vertically** to control Player 1's paddle.
- Player 2 is controlled automatically.
- **Press Space** after the game is over to restart.
- Press `Alt+F4`, or close the window, to exit.

## Rules

The first player to score 7 points wins. After a point, the ball resets and play continues.
