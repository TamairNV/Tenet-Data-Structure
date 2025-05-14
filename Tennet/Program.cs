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

        DimensionalLinkedList time = new DimensionalLinkedList();
        time.CurrentDimensionalNode = new DimensionalNode(null, null,null,null,100,100);
        for (int i = 0; i < 10; i++)
        {
            time.stepNode();
        }
        time.reverseDirection();
        Console.WriteLine(time.direction);
        for (int i = 0; i < 5; i++)
        {
            time.stepNode();
        }

        time.reverseDirection();
        Console.WriteLine(time.direction);
        for (int i = 0; i < 15; i++)
        {
            time.stepNode();
        }       
        time.reverseDirection();
        Console.WriteLine(time.direction);
        for (int i = 0; i < 20; i++)
        {
            time.stepNode();
        }      
        game.Run();
    }
}