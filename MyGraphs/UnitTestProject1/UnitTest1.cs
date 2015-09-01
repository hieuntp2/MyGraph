using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyGraphs;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyListGraph graph = new MyListGraph();
            graph.AddNode(new MyGraphNode(0));
            graph.AddNode(new MyGraphNode(1));
            graph.AddNode(new MyGraphNode(2));
            graph.AddNode(new MyGraphNode(3));
            graph.AddNode(new MyGraphNode(4));

            graph.AddEdge(new MyGraphEdge(0, 2));
            graph.AddEdge(new MyGraphEdge(2, 1));
            
            graph.AddEdge(new MyGraphEdge(2, 3));
            graph.AddEdge(new MyGraphEdge(4, 3));
           
            Assert.AreEqual(1,graph.SoMienDoThiLienThong());
        }


    }
}
