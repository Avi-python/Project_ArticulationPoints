// See https://aka.ms/new-console-template for more information
using System;

using Extension;
using GraphSpace;
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
            List<int> dfn2 = new List<int> (){1, 2, 3, 4, 5, 6, 9, 7, 8};

            // graph3
            List<int> input3 = new List<int>(){10, 11, 14, 16, 20, 22, 25, 28, 31, 32, 1, 0, 
                                                2, 3, 1, 4, 1, 4, 5, 6, 2, 3, 3, 6, 7, 3, 5, 
                                                7, 5, 6, 8, 7};
            List<int> dfn3 = new List<int>(){1, 2, 9, 3, 8, 4, 7, 5, 6};

            Graph g1 = new Graph(input1);
            Graph g2 = new Graph(input2);
            Graph g3 = new Graph(input3);

            List<int> Low;
            List<int> APs;

            APs = g1.ArticulationPoints(dfn1, out Low);
            
            foreach(int i in APs)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach(int i in dfn1)
            {

                Console.Write($"{i} ");
            }
            Console.WriteLine();

            foreach(int i in Low)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}