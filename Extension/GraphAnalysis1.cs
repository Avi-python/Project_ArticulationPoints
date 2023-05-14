namespace Extension;
using GraphSpace;
public static partial class GraphAnalysis 
{
    public static List<int> ArticulationPoints(this Graph g, List<int> Dfn, out List<int> Low)
    {
        List<int> ans = new List<int>();
        List<int> low = new List<int>();

        if(Dfn is null || g is null) throw new NullReferenceException("g / DFN is null");

        List<root> rootList = new List<root>();


        for(int i = 0; i < g.NodeArr.Count(); i++)
        {
            rootList.Add(new root(g.NodeArr[i].ID, Dfn[i]));
        }
 
        int n = rootList.Count(), index = 0;
        rootList.Sort(new rootComparer());

        // CheckConneciton(g.NodeArr);

        bool[,] visited = new bool[n, n];

        // if(g.NodeArr[0].Children.Contains(g.NodeArr[1])) Console.WriteLine("I am right");

        // if(!visited[0, 1]) Console.WriteLine("WHy");

        Dictionary<int, root> helpDict = new Dictionary<int, root>();
        for(int i = 0; i < n; i++)
        {
            helpDict.Add(rootList[i].ID, rootList[i]);
        }

        for(int i = 1; i < n; i++)
        {
            index = i - 1;
            // Console.Write($"ID:{rootList[i].ID} [");
            while(index >= 0 && ( (!g.NodeArr[rootList[i].ID].Children.Contains(g.NodeArr[rootList[index].ID])) || visited[rootList[i].ID, rootList[index].ID]))
            {
                // if(visited[0, 1])
                // {
                //     Console.WriteLine("why");
                // }
                index--;
            }
            // Console.WriteLine("]");


            if(index < 0) throw new Exception("index is negative");
            // add dfschild
            rootList[index].dfsChild.Add(rootList[i]);
            visited[rootList[i].ID, rootList[index].ID] = true;
            visited[rootList[index].ID, rootList[i].ID] = true;
            // back edge
            for(int j = 0; j < g.NodeArr[rootList[i].ID].Children.Count(); j++)
            {
                if(!visited[ rootList[i].ID , g.NodeArr[rootList[i].ID].Children[j].ID ] && helpDict[ g.NodeArr[rootList[i].ID].Children[j].ID ].Dfn < rootList[i].Dfn)
                {
                    // Console.WriteLine(g.NodeArr[rootList[i].ID].Children[j].ID);
                    visited[ rootList[i].ID, g.NodeArr[rootList[i].ID].Children[j].ID ] = true;
                    visited[ g.NodeArr[rootList[i].ID].Children[j].ID, rootList[i].ID ] = true;
                    rootList[i].Back.Add(helpDict[ g.NodeArr[rootList[i].ID].Children[j].ID ]);
                }
            }
        } 
        rootList[0].isRoot = true;

        for(int i = 0; i < n; i++)
        {
            low.Add(0);
        }

        LowCounterHelper(rootList[0], rootList, ans);

        for(int i = 0; i < n; i++)
        {
            low[rootList[i].ID] = rootList[i].Low;
        }

        Low = low;

        return ans;
    }

    private static int LowCounterHelper(root r, List<root> rootList, List<int> ArticulationPoint)
    {
        int n = r.dfsChild.Count(); 
        // Console.Write($"{r.ID} "); 
        int backMin = Int32.MaxValue;
        for(int i = 0; i < r.Back.Count(); i++)
        {
            backMin = Math.Min(backMin, r.Back[i].Dfn);
        }

        if(n == 0)
        {
            r.Low = Math.Min(r.Dfn, backMin);
            return r.Low;
        }
        // else
        int lowMin = Int32.MaxValue;
        for(int i = 0; i < n; i++)
        {
            lowMin = Math.Min(lowMin, LowCounterHelper(r.dfsChild[i], rootList, ArticulationPoint));
        }
        int semiMin = Math.Min(lowMin, r.Dfn);

        // Console.WriteLine($"ID:{r.ID}, Low:{semiMin}");
        r.Low = Math.Min(semiMin, backMin);

        // 判斷是不是 AP

        if(r.isRoot) 
        {
            if(r.dfsChild.Count() >= 2)
            {
                ArticulationPoint.Add(r.ID);
            }
        }
        else
        {
            bool isAp = false;
            for(int i = 0; i < n; i++)
            {
                if(r.dfsChild[i].Low >= r.Dfn)
                {
                    isAp = true;
                    break;
                }       
            }
            if(isAp)
            {
                ArticulationPoint.Add(r.ID);
            }
        }    

        return r.Low;
    }


    private static void CheckConneciton(List<Node> NodeArr)
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

}
