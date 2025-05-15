// Usage example:

namespace Tennet;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public static class Program
{
    public static void Main()
    {
        Game game = new Game(1100, 750, "Box Connection Demo");
        
        game.Run();
    }
}