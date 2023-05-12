namespace ArticulationPointsFinder;
public class Node : IComparable
{
    public int Data { get; set; }
    public int Dfn { get; set; }
    public int Low { get; set; }
    public List<Node>? Children { get; set; }
    // public List<Node>? Back { get; set; }

    public int CompareTo(object? obj)
    {
        if(!(obj is Node)) throw new ArgumentException("The argument value must be of type 'Student'.");

        return CompareTo((Node)obj);
    }

    public int CompareTo(Node other)
    {
        return Dfn > other.Dfn ? 1 : ( Dfn < other.Dfn ? -1 : 0 );
    }
    public Node() { Children = new List<Node>(); }
    public Node(int data) : this() { Data = data; } 
    public Node(int data, int dfn) : this(data) { Dfn = dfn; }
}
