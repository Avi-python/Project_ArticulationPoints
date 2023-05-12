using System;
namespace ArticulationPointsFinder;
public class APF
{
    private GraphReader Input { get; set; }
    private List<int>? DFN { get; set; }
    private List<int>? LOW { get; set; }
    public APF(List<int> input)
    {
        Input = new GraphReader(input);
    }

    ///<summary>return the Articulation Points</summary>///
    public List<int> Finding(List<int> dfn)
    {
        if(dfn is null) throw new NullReferenceException("DFN");

        Input.SupportGraph(dfn);
        
        return null;
    }

    private void CalcuLow()
    {

    }

}
