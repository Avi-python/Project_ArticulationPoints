// See https://aka.ms/new-console-template for more information
using ArticulationPointsFinder;
using System;

namespace MainSpace
{
    internal class MainClass
    {
        private static void Main()
        {
            List<int> input = new List<int>(){11, 12, 15, 17, 20, 22, 25, 27, 31, 32, 33,
                                               1, 0, 2, 3, 1, 4, 1, 4, 5, 2, 3, 3, 6, 7, 5, 
                                               7, 5, 6, 8, 9, 7, 7};
            List<int> dfn = new List<int> (){5, 4, 3, 1, 2, 6, 7, 8, 9, 10};
            APF A = new APF(input);
            A.Finding(dfn);
        }
    }
}