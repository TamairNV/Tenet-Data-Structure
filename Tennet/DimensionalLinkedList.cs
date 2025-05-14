namespace Tennet;

public class DimensionalLinkedList
{
    public DimensionalNode CurrentDimensionalNode;
    public List<LinkedList<DimensionalNode>> TransDimensionalLinkStorage = new List<LinkedList<DimensionalNode>>();
    public int direction = 1;
    public DimensionalNode LastSplitPoint = null;
    public int CurrentTime = 0;
    public int x = 150;
    public int y = 100;

    public void reverseDirection()
    {
        if (direction == 1)
        {
            direction = 0;
        }
        else
        {
            direction = 1;
        }

        y += 50;
        x -= 50;

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
                x += 50;
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
                x -= 50;
                if (CurrentTime < 0)
                {
                    //game over
                }
                TransDimensionalLinkStorage[CurrentTime].AddLast(CurrentDimensionalNode);
                

            }
        }
    }
    
}

