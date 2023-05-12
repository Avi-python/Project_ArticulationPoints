namespace ArticulationPointsFinder;
public class GraphReader
{
    private readonly List<int> _graph;
    public List<int> Graph { get { return _graph; } }
    public bt root;
    public List<Node> NodeArr { get; set; }
    
    public GraphReader(List<int> graph)
    {
        if(graph is null) throw new NullReferenceException("graph");
        _graph = graph;
        int n = graph.Count();
        NodeArr = new List<Node>();
        // 先建立基本陣列
        for(int i = 0; i < n; i++)
        {
            if(graph[i] == n) break;
            NodeArr.Add(new Node(i));
        }

        // 再將它們連接彼此
        for(int i = 0; i < n; i++)
        {
            if(graph[i] == n) break;
            for(int j = 0; j < graph[i + 1] - graph[i]; j++)
            {
                try
                {   
                    NodeArr[i].Children.Add(NodeArr[graph[graph[i] + j]]);
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
    }


    public void SupportGraph(List<int> DFN)
    {
        for(int i = 0; i < NodeArr.Count(); i++)
        {
            NodeArr[i].Dfn = DFN[i];
        }
        NodeArr.Sort(new NodeComparer());

        // foreach(Node i in NodeArr)
        // {
        //     Console.Write($"(data:{i.Data}, dfn:{i.Dfn})-");
        // }
        // Console.WriteLine();

        root = new bt(NodeArr[0].Data, NodeArr[0].Dfn);
        int index = 0, process = 0;
        bool[,] goThrough = new bool[NodeArr.Count(),NodeArr.Count()];
        Helper(ref index, root, ref process, goThrough);
    }

    private void Helper(ref int cur, bt now, ref int process, bool[,] goThrough)
    {
        if(cur < NodeArr.Count());
        bool trig = false;
        for(int i = 0; i < NodeArr[cur].Children.Count(); i++)
        {
            if(ReferenceEquals(NodeArr[cur].Children[i], NodeArr[cur + 1]) && !goThrough[cur, cur + 1])
            {
                trig = true;
                goThrough[cur, cur + 1] = true;
                goThrough[cur + 1, cur] = true;
                now.Left = new bt(NodeArr[cur + 1].Data, NodeArr[cur + 1].Dfn);
            }
        }

        if(trig)
        {
            cur++;
            process++;
            Helper(ref cur, now.Left, ref process , goThrough);
            for(int i = 0; i < NodeArr[cur].Children.Count(); i++)
            {
                if(ReferenceEquals(NodeArr[cur].Children[i], NodeArr[process]) && !goThrough[cur, process])
                {
                    goThrough[cur, process] = true;
                    goThrough[process, cur] = true;
                    now.Right = new bt(NodeArr[process].Data, NodeArr[process].Dfn);
                }
            }
        }
        else // 代表走到鏡頭了，要做的事情就是掃一圈看有沒有 go back
        {
            cur--;
            for(int i = 0; i < NodeArr[cur].Children.Count(); i++)
            {
                if(!goThrough[cur, i])
                {
                    goThrough[cur, i] = true;
                    goThrough[i, cur] = true;
                    now.Back.Add(
                }
            }
        }
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
