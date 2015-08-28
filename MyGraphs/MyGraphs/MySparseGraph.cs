using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    /// <summary>
    /// Đồ thị chỉ chấp nhận 2 đỉnh chỉ có 1 cạnh duy nhất (nếu đồ thị có hướng là 2 cạnh, vô hướng là 1 cạnh).
    /// </summary>
    class MySparseGraph
    {
        protected List<MyGraphNode> m_Nodes;
        protected List<MyGraphEdge> m_Edges;

        private bool m_bDigraph;
        private int m_iNextNodeIndex;

        public MySparseGraph()
        {
            m_iNextNodeIndex = 0;
            m_bDigraph = false;
        }

        public MyGraphNode GetNode(int index)
        {
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].getIndex() == index)
                {
                    return m_Nodes[i];
                }
            }
            return null;
        }

        public MyGraphEdge GetEdge(int from, int to)
        {
            for (int i = 0; i < m_Edges.Count; i++)
            {
                if (m_Edges[i].GetFrom() == from && m_Edges[i].GetTo() == to)
                {
                    return m_Edges[i];
                }
            }

            return null;
        }

        public int GetNextFreeNodeIndex()
        {
            return m_iNextNodeIndex;
        }

        /// <summary>
        /// Add Node to Graphs
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Return Index of Node. If fail to add node, return -1</returns>
        public int AddNode(MyGraphNode node)
        {
            node.setIndex(index: GetNextFreeNodeIndex());
            m_iNextNodeIndex += 1;

            if (true)
            {
                m_Nodes.Add(node);
                return node.getIndex();
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// removes a node by setting its index to invalid_node_index
        /// </summary>
        /// <param name="node">Return true if can find and change node to Invalid, another return false</param>
        public bool RemoveNode(int indexNode)
        {
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].getIndex() == indexNode)
                {
                    m_Nodes[i].setInvalid();
                    return true;
                }
            }
            return false;
        }

        public bool AddEdge(MyGraphEdge edge)
        {
            m_Edges.Add(edge);
            return true;
        }

        public bool RemoveEdge(int from, int to)
        {
            for (int i = 0; i < m_Edges.Count; i++)
            {
                if (m_Edges[i].GetFrom() == from && m_Edges[i].GetTo() == to)
                {
                    m_Edges.Remove(m_Edges[i]);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Return the number of active + inactive nodes present in the graph
        /// </summary>
        /// <returns></returns>
        public int NumNodes()
        {
            return m_Nodes.Count;
        }

        /// <summary>
        /// returns the number of active nodes present in the graph
        /// </summary>
        /// <returns></returns>
        public int NumActiveNodes()
        {
            int count = 0;

            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].isValid())
                {
                    count += 1;
                }
            }

            return count;
        }

        /// <summary>
        /// returns the number of edges present in the graph
        /// </summary>
        /// <returns></returns>
        public int NumEdges()
        {
            return m_Edges.Count;
        }

        /// <summary>
        /// returns true if the graph is directed
        /// </summary>
        /// <returns></returns>
        public bool isDigraph()
        {
            return this.m_bDigraph;
        }

        /// <summary>
        /// returns true if the graph contains no nodes
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            if (m_Nodes.Count == 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// returns true if a node with the given index is present in the graph
        /// </summary>
        /// <param name="indexNode"></param>
        /// <returns></returns>
        public bool isPresent(int indexNode)
        {
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].getIndex() == indexNode)
                {
                    return true;
                }
            }
            return false;
        }

        //methods for loading and saving graphs from an open file 
        public bool Save(string FileName)
        {
            return false;
        }

        public bool Load(string FileName)
        {
            return false;
        }

        /// <summary>
        /// clears the graph ready for new node insertions
        /// </summary>
        public void Clear()
        {
            this.m_Edges.Clear();
            this.m_Nodes.Clear();
        }

    }
}
