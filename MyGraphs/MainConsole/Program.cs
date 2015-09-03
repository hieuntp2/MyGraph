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
            MyListGraph graph = new MyListGraph();
            graph.AddNode(new MyGraphNode(0));
            graph.AddNode(new MyGraphNode(1));
            graph.AddNode(new MyGraphNode(2));
            graph.AddNode(new MyGraphNode(3));
            graph.AddNode(new MyGraphNode(4));

            graph.AddEdge(new MyGraphEdge(0, 2, 3));
            graph.AddEdge(new MyGraphEdge(2, 1, 2));

            graph.AddEdge(new MyGraphEdge(2, 3, 4));
            graph.AddEdge(new MyGraphEdge(4, 3, 5));
            graph.AddEdge(new MyGraphEdge(1, 3, 2));
            graph.AddEdge(new MyGraphEdge(1, 1, 2));
            graph.AddEdge(new MyGraphEdge(3, 3, 6));
            graph.AddEdge(new MyGraphEdge(3, 1, 4));
            graph.AddEdge(new MyGraphEdge(1, 2, 7));

            graph.MakeSimpleGraph();

            MyListGraph prim = graph.PrimAlgo(graph.GetNode(0));

            graph.PrintGraphInConsole();
            prim.PrintGraphInConsole();

            List<MyGraphEdge> path = prim.FindTheShortestPath(1, 3);
        }
    }
}
