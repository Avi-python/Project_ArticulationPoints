namespace GraphSpace;
public class Graph
{
    public List<int> ArticulationPoint { get; set; }
    public List<Node> NodeArr { get; set; }
    // public List<Node> EdgeArr { get; set; }
    
    public Graph(List<int> data)
    {
        if(data is null) throw new NullReferenceException("data");

        int n = data.Count();
        NodeArr = new List<Node>();
        ArticulationPoint = new List<int>();
        // 先建立基本陣列
        for(int i = 0; i < n; i++)
        {
            if(data[i] == n) break;
            NodeArr.Add(new Node(i));
        }

        // 再將它們連接彼此
        for(int i = 0; i < n; i++)
        {
            if(data[i] == n) break;
            for(int j = 0; j < data[i + 1] - data[i]; j++)
            {
                try
                {   
                    NodeArr[i].Children.Add(NodeArr[data[data[i] + j]]);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
        // CheckConneciton(NodeArr);
    }


    private void CheckConneciton(List<Node> NodeArr)
    {
        // check connection
        for(int i = 0; i < NodeArr.Count(); i++)
        {
            Console.Write($"{NodeArr[i].ID} ");
            if(NodeArr[i].Children.Count() != 0)
            {
                Console.Write("[");
                for(int j = 0; j < NodeArr[i].Children.Count(); j++)
                {
                    Console.Write(NodeArr[i].Children[j].ID);
                }
                Console.WriteLine("]");
            }
            else
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }

    private sealed class NodeComparer : IComparer<Node>
    {
        int IComparer<Node>.Compare(Node? x, Node? y)
        {
            if(x is null || y is null) throw new NullReferenceException("x / y is NULL");
            return x.CompareTo(y);
        }
    }
}