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

            graph.AddEdge(new MyGraphEdge(0, 1, 9));
            graph.AddEdge(new MyGraphEdge(0, 3, 4));
            graph.AddEdge(new MyGraphEdge(0, 6, 6));
            graph.AddEdge(new MyGraphEdge(1, 2, 8));
            graph.AddEdge(new MyGraphEdge(2, 4, 5));
            graph.AddEdge(new MyGraphEdge(3, 1, 3));
            graph.AddEdge(new MyGraphEdge(3, 2, 1));
            graph.AddEdge(new MyGraphEdge(4, 6, 3));
            graph.AddEdge(new MyGraphEdge(5, 4, 17));
            graph.AddEdge(new MyGraphEdge(5, 6, 12));
            graph.AddEdge(new MyGraphEdge(6, 3, 21));

            graph.MakeSimpleGraph();

            MyListGraph prim = graph.PrimAlgo(graph.GetNode(0));

            graph.PrintGraphInConsole();
            prim.PrintGraphInConsole();

            List<MyGraphEdge> path = graph.FindTheShortestPath(0, 4);
        }
    }
}
