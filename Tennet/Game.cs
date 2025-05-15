namespace Tennet;
using System.Linq;
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
    public DimensionalLinkedList time = new DimensionalLinkedList();
    public Player player;
    public void Run()
    {
        
        player = new Player(time);
        player.isAlive = true;
        time.CurrentDimensionalNode = new DimensionalNode(null, null,null,null,0,10);
        while (!Raylib.WindowShouldClose())
        {
            Update();
            Draw();
        }
        
        Raylib.CloseWindow();
    }
    
  
    private void Update()
    {
        foreach (var p in Player.Players.ToList())
        {
            if (p.isAlive)
            {
                p.MovePlayer();
            }
        }
        
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            time.reverseDirection();
        }
        
    }

    private void Draw()
    {
        
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        foreach (var p in Player.Players)
        {
            
            p.DrawPlayer();
        }
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
