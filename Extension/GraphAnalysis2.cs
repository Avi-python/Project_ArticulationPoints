namespace Extension;
using GraphSpace;
public static partial class GraphAnalysis 
{ 
    public class root : IComparable
    {
        public int ID { get; set; }
        public int Dfn { get; set; }
        public int Low { get; set; }
        public bool isRoot { get; set; }
        public List<root> dfsChild { get; set; }
        public List<root> Back { get; set; }

        public int CompareTo(object? obj)
        {
            if(!(obj is root)) throw new ArgumentException("The argument value must be of type 'Student'.");

            return CompareTo((root)obj);
        }

        public int CompareTo(root other)
        {
            return Dfn > other.Dfn ? 1 : ( Dfn < other.Dfn ? -1 : 0 );
        }
        public root() { Back = new List<root>(); dfsChild = new List<root>(); }
        public root(int id) : this() { ID = id; } 
        public root(int id, int dfn) : this(id) { Dfn = dfn; }
    }

    private sealed class rootComparer : IComparer<root>
    {
        int IComparer<root>.Compare(root? x, root? y)
        {
            if(x is null || y is null) throw new NullReferenceException("x / y is NULL");
            return x.CompareTo(y);
        }
    }
    
}
