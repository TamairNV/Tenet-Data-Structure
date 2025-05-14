namespace Tennet;

using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Game
{
    private List<Box> boxes = new List<Box>();
    
    public Game(int screenWidth, int screenHeight, string title)
    {
        Raylib.InitWindow(screenWidth, screenHeight, title);
        Raylib.SetTargetFPS(60);
    }

    public void Run()
    {
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }
        
        Raylib.CloseWindow();
    }

    private void Update()
    {
        // Add your update logic here
    }

    private void Draw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        
        foreach (var node in DimensionalNode.Nodes)
        {
            node.box.Draw();
            if (node.ForwardDimensionalNode != null)
            {
                node.box.DrawConnection(node.ForwardDimensionalNode.box);
            }

            if (node.BackwardsDimensionalNode != null)
            {
                node.box.DrawConnection(node.BackwardsDimensionalNode.box);
            }

            if ( node.SameTimeNodes != null && node.SameTimeNodes.Find(node) != null && node.SameTimeNodes.Find(node).Previous != null)
            {
                node.box.DrawConnection(node.SameTimeNodes.Find(node).Previous.Value.box);
            }
            
            
        }
        
        
        Raylib.EndDrawing();
    }

    public void AddBox(Box timeBox) => boxes.Add(timeBox);
}
