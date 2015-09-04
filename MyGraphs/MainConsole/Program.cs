using MyGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyListGraph graph = new MyListGraph(true);
            //graph.AddNode(new MyGraphNode(0));
            //graph.AddNode(new MyGraphNode(1));
            //graph.AddNode(new MyGraphNode(2));
            //graph.AddNode(new MyGraphNode(3));
            //graph.AddNode(new MyGraphNode(4));

            //graph.AddEdge(new MyGraphEdge(0, 2, 3));
            //graph.AddEdge(new MyGraphEdge(2, 1, 2));

            //graph.AddEdge(new MyGraphEdge(2, 3, 4));
            //graph.AddEdge(new MyGraphEdge(4, 3, 5));
            //graph.AddEdge(new MyGraphEdge(1, 3, 2));
            //graph.AddEdge(new MyGraphEdge(1, 1, 2));
            //graph.AddEdge(new MyGraphEdge(3, 3, 6));
            //graph.AddEdge(new MyGraphEdge(3, 1, 4));
            //graph.AddEdge(new MyGraphEdge(1, 2, 7));

            MyListGraph graph = new MyListGraph(true);
            graph.AddNode(new MyGraphNode(0));
            graph.AddNode(new MyGraphNode(1));
            graph.AddNode(new MyGraphNode(2));
            graph.AddNode(new MyGraphNode(3));
            graph.AddNode(new MyGraphNode(4));
            graph.AddNode(new MyGraphNode(5));
            graph.AddNode(new MyGraphNode(6));
            graph.AddNode(new MyGraphNode(7));
            graph.AddNode(new MyGraphNode(8));
            graph.AddNode(new MyGraphNode(9));
            graph.AddNode(new MyGraphNode(10));

            graph.AddEdge(new MyGraphEdge(0, 1, 1));
            graph.AddEdge(new MyGraphEdge(0, 2, 3));
            graph.AddEdge(new MyGraphEdge(0, 3, 2));
            graph.AddEdge(new MyGraphEdge(1, 7, 3));
            graph.AddEdge(new MyGraphEdge(1, 6, 7));
            graph.AddEdge(new MyGraphEdge(1, 2, 2));
            graph.AddEdge(new MyGraphEdge(2, 6, 2));
            graph.AddEdge(new MyGraphEdge(3, 2, 1));
            graph.AddEdge(new MyGraphEdge(3, 4, 6));
            graph.AddEdge(new MyGraphEdge(4, 2, 4));
            graph.AddEdge(new MyGraphEdge(4, 5, 2));
            graph.AddEdge(new MyGraphEdge(5, 6, 1));
            graph.AddEdge(new MyGraphEdge(5, 8, 2));
            graph.AddEdge(new MyGraphEdge(5, 10, 4));
            graph.AddEdge(new MyGraphEdge(6, 7, 3));
            graph.AddEdge(new MyGraphEdge(6, 8, 6));
            graph.AddEdge(new MyGraphEdge(7, 9, 5));
            graph.AddEdge(new MyGraphEdge(7, 8, 4));
            graph.AddEdge(new MyGraphEdge(8, 9, 2));
            graph.AddEdge(new MyGraphEdge(8, 10, 1));
            graph.AddEdge(new MyGraphEdge(9, 10, 6));
            graph.MakeSimpleGraph();

            //MyListGraph prim = graph.PrimAlgo(graph.GetNode(0));

            graph.PrintGraphInConsole();
            //prim.PrintGraphInConsole();

            List<MyGraphEdge> path = graph.FindTheShortestPath(0, 10);
        }
    }
}
