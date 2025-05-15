namespace Tennet;
using System.Numerics;
using Raylib_cs;
public class DimensionalLinkedList
{
    public DimensionalNode CurrentDimensionalNode;
    public List<LinkedList<DimensionalNode>> TransDimensionalLinkStorage = new List<LinkedList<DimensionalNode>>();
    public int direction = 1;
    public DimensionalNode LastSplitPoint = null;
    public int CurrentTime = 0;
    public int x = 10;
    public int y = 10;

    public void reverseDirection()
    {


        if (direction == 1)
        {
            direction = 0;
            x -= 10;
        }
        else
        {
            direction = 1;
            x += 10;
        }

        y += 10;
        
        LastSplitPoint = CurrentDimensionalNode;
        
        CurrentDimensionalNode = new DimensionalNode(null, null, LastSplitPoint,TransDimensionalLinkStorage[CurrentTime-1], x, y);

    }
    

    public void stepNode()
    {
        if (direction == 1)
        {
            
            if (CurrentDimensionalNode.ForwardDimensionalNode != null)
            {
                CurrentDimensionalNode = CurrentDimensionalNode.ForwardDimensionalNode;
            }
            else
            {
                CurrentDimensionalNode = new DimensionalNode(null,CurrentDimensionalNode,LastSplitPoint,null,x,y);
                x += 10;
                if (TransDimensionalLinkStorage.Count > CurrentTime && TransDimensionalLinkStorage[CurrentTime] != null)
                {
                    TransDimensionalLinkStorage[CurrentTime].AddLast(CurrentDimensionalNode);

                }
                else
                {
                    LinkedList<DimensionalNode> newLinkedList = new LinkedList<DimensionalNode>();
                    TransDimensionalLinkStorage.Add(newLinkedList);
   
                    newLinkedList.AddFirst(CurrentDimensionalNode);
                }
        
                CurrentDimensionalNode.SameTimeNodes = TransDimensionalLinkStorage[CurrentTime];
                CurrentTime++;
            }
        }

        if (direction == 0)
        {
            CurrentTime--;
            if (CurrentDimensionalNode.BackwardsDimensionalNode != null)
            {
                CurrentDimensionalNode = CurrentDimensionalNode.BackwardsDimensionalNode;
            }
            else
            {
                CurrentDimensionalNode = new DimensionalNode(CurrentDimensionalNode, null, LastSplitPoint,TransDimensionalLinkStorage[CurrentTime],x,y);
                x -= 10;
                if (CurrentTime < 0)
                {
                    //game over
                }
                TransDimensionalLinkStorage[CurrentTime].AddLast(CurrentDimensionalNode);
                

            }
        }

        StepPlayers();


    }

    public void StepPlayers()
    {
        if (TransDimensionalLinkStorage.Count > CurrentTime && TransDimensionalLinkStorage[CurrentTime] != null)
        {
            foreach (var n in TransDimensionalLinkStorage[CurrentTime])
            {
                Box box = new Box(n.data.X, n.data.Y, 25, 25);
                box.Color = Color.Green;
                box.Draw();
       
            }
        }

    }
    
}

