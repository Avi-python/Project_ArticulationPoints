namespace ArticulationPointsFinder;

public class bt
{
    public int Data { get; set; }
    public bt? Left { get; set; }
    public bt? Right { get; set; }
    public List<bt>? Back { get; set; }
    public int Dfn { get; set; }
    public int Low { get; set; }
    public bt() { Back = new List<bt>(); }
    public bt(bt left, bt right) : this() { Left = left; Right = right; }
    public bt(int data, int dfn, bt left = null, bt right = null) : this (left, right) { Data = data; Dfn = dfn; }
}
