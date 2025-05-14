namespace Tennet;

using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;

public class Box
{
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public Color Color { get; set; } = new Color(255, 255, 255);
    public List<Box> ConnectedBoxes { get; } = new List<Box>();

    public Box(float x, float y, float width, float height)
    {
        Position = new Vector2(x, y);
        Size = new Vector2(width, height);
    }

    public void AddConnection(Box box)
    {
        if (!ConnectedBoxes.Contains(box))
        {
            ConnectedBoxes.Add(box);
        }
    }

    public void Draw()
    {
        // Draw the box
        Raylib.DrawRectangleV(Position, Size, Color);
        
        // Draw connections to other boxes
        foreach (var connectedBox in ConnectedBoxes)
        {
            Vector2 start = new Vector2(
                Position.X + Size.X / 2,
                Position.Y + Size.Y / 2
            );
            
            Vector2 end = new Vector2(
                connectedBox.Position.X + connectedBox.Size.X / 2,
                connectedBox.Position.Y + connectedBox.Size.Y / 2
            );
            
            Raylib.DrawLineV(start, end, Color.Gray);
        }
    }

    public void DrawConnection(Box otherBox)
    {
        Vector2 start = new Vector2(
            Position.X + Size.X / 2,
            Position.Y + Size.Y / 2
        );
            
        Vector2 end = new Vector2(
            otherBox.Position.X + otherBox.Size.X / 2,
            otherBox.Position.Y + otherBox.Size.Y / 2
        );
            
        Raylib.DrawLineV(start, end, Color.Gray);
    }
}