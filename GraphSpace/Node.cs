namespace GraphSpace;
public class Node : IComparable
{
    public int ID { get; set; }
    public int Low { get; set; }
    public List<Node> Children { get; set; }
    public List<Edge> Conn { get ; set; }

    public int CompareTo(object? obj)
    {
        if(!(obj is Node)) throw new ArgumentException("The argument value must be of type 'Student'.");

        return CompareTo((Node)obj);
    }

    // public int CompareTo(Node other)
    // {
    //     return Dfn > other.Dfn ? 1 : ( Dfn < other.Dfn ? -1 : 0 );
    // }
    public Node() { Children = new List<Node>(); Conn = new List<Edge>(); }
    public Node(int id) : this() { ID = id; } 
    // public Node(int id, int dfn) : this(id) { Dfn = dfn; }
}
