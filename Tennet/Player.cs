using System.Numerics;
using Raylib_cs;

namespace Tennet;

public class Player
{
    public static List<Player> Players = new List<Player>();
    public Vector2 Position;
    public bool isAlive = false;

    public DimensionalLinkedList Time;
    public DimensionalNode CurrentPlayerNode;
    public int Direction;
    public Player(DimensionalLinkedList time )
    {
        Time = time;
  
        Players.Add(this);
    }
    public void MovePlayer()
    {
        Vector2 moveVector = new Vector2(0, 0);
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            moveVector.X -= 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            moveVector.X += 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
        {
            moveVector.Y -= 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            moveVector.Y += 1;
        }

        moveVector = Normalize(moveVector);

        Position += moveVector * Raylib.GetFrameTime() * 250;
        
        Time.stepNode();
        Time.CurrentDimensionalNode.data = new Vector2(Position.X, Position.Y);


    }

    public void DrawPlayer()
    {
        Box box = new Box(Position.X, Position.Y, 25, 25);
        box.Color = Color.Green;
        box.Draw();
    }
    
    public static Vector2 Normalize(Vector2 input)
    {
        float magnitude = (float)Math.Sqrt(input.X * input.X + input.Y * input.Y);
        
        if (magnitude > 0)
        {
            return new Vector2(input.X / magnitude, input.Y / magnitude);
        }
        
        return new Vector2(0, 0);
    }
}