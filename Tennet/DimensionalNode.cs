namespace Tennet;

using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
public class DimensionalNode
{
    public DimensionalNode ForwardDimensionalNode;
    public DimensionalNode BackwardsDimensionalNode;
    public DimensionalNode SplitPoint;
    public LinkedList<DimensionalNode> SameTimeNodes;
    public Vector2 data;
    public Box box;
    public static List<DimensionalNode> Nodes = new List<DimensionalNode>();

    public DimensionalNode(DimensionalNode forwardDimensionalNode, DimensionalNode backwardsDimensionalNode , DimensionalNode splitPoint,LinkedList<DimensionalNode> sameTimeNodes ,int x, int y)
    {
        
        ForwardDimensionalNode = forwardDimensionalNode;
        BackwardsDimensionalNode = backwardsDimensionalNode;
        SplitPoint = splitPoint;
        SameTimeNodes = sameTimeNodes;
        box = new Box(x, y, 5, 5) { Color = Color.Red };
        Nodes.Add(this);
    }
    
}