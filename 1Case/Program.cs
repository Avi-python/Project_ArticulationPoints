// See https://aka.ms/new-console-template for more information
using ArticulationPointsFinder;
using System;

namespace MainSpace
{
    internal class MainClass
    {
        private static void Main()
        {
            // graph1
            List<int> input1 = new List<int>(){11, 12, 15, 17, 20, 22, 25, 27, 31, 32, 33,
                                               1, 0, 2, 3, 1, 4, 1, 4, 5, 2, 3, 3, 6, 7, 5, 
                                               7, 5, 6, 8, 9, 7, 7};
            List<int> dfn1 = new List<int> (){5, 4, 3, 1, 2, 6, 7, 8, 9, 10};

            // graph2
            List<int> input2 = new List<int>(){10, 12, 16, 18, 21, 23, 26, 28, 31, 33, 1, 2, 
                                                0, 2, 3, 4, 0, 1, 1, 4, 5, 1, 3, 3, 6, 8, 5,
                                                7, 5, 6, 8, 5, 7};
            List<int> dfn2 = new List<int> (){1, 2, 3, 4, 5, 6, 7, 9, 7, 8};

            // graph3
            List<int> input3 = new List<int>(){10, 11, 14, 16, 20, 22, 25, 28, 31, 32, 1, 0, 
                                                2, 3, 1, 4, 1, 4, 5, 6, 2, 3, 3, 6, 7, 3, 5, 
                                                7, 5, 6, 8, 7};
            List<int> dfn3 = new List<int>(){1, 2, 9, 3, 8, 4, 7, 5, 6};

            APF A = new APF(input2);
            A.Finding(dfn2);
        }
    }
}