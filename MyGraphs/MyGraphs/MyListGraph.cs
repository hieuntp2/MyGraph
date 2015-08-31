﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    /// <summary>
    /// Đồ thị chỉ chấp nhận 2 đỉnh chỉ có 1 cạnh duy nhất (nếu đồ thị có hướng là 2 cạnh, vô hướng là 1 cạnh).
    /// </summary>
    public class MyListGraph
    {
        protected List<MyGraphNode> m_Nodes;

        private bool m_bDigraph;
        private int m_iNumEdge;

        Dictionary<int, List<MyListGraphEdge>> m_DListNode;

        public MyListGraph(bool isDirectGraph = false)
        {
            m_iNumEdge = 0;
            m_bDigraph = false;
            m_DListNode = new Dictionary<int, List<MyListGraphEdge>>();
            m_Nodes = new List<MyGraphNode>();
            m_bDigraph = isDirectGraph;
        }

        #region Basic Function
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
            // Nếu id < số lượng node có nghĩa là node đó ko tồn tại
            if (!isPresent(from) || !isPresent(to))
            {
                return null;
            }

            for (int i = 0; i < m_DListNode[from].Count; i++)
            {
                if (m_DListNode[from][i].GetTo() == to)
                {
                    MyGraphEdge result = new MyGraphEdge(from, m_DListNode[from][i].GetTo(), m_DListNode[from][i].GetCost());
                    return result;
                }
            }

            return null;
        }

        public int GetNextFreeNodeIndex()
        {
            return m_Nodes.Count;
        }

        /// <summary>
        /// Add Node to Graphs
        /// </summary>
        /// <param name="node"></param>
        /// <returns>Return Index of Node. If fail to add node, return -1</returns>
        public int AddNode(MyGraphNode node)
        {
            node.setIndex(index: GetNextFreeNodeIndex());

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
            if (!isPresent(edge.GetFrom()) || !isPresent(edge.GetTo()))
            {
                return false;
            }

            int from = edge.GetFrom();
            int to = edge.GetTo();
            float cost = edge.GetCost();

            if (m_DListNode.ContainsKey(from))
            {
                m_DListNode[edge.GetFrom()].Add(new MyListGraphEdge(to, cost));
            }
            else
            {
                m_DListNode.Add(from, new List<MyListGraphEdge>());
                m_DListNode[from].Add(new MyListGraphEdge(to, cost));
            }
            m_iNumEdge++;
            return true;
        }

        public bool RemoveEdge(int from, int to)
        {
            if (!isPresent(from) || !isPresent(to))
            {
                return false;
            }
            if (m_DListNode.ContainsKey(from))
            {
                for (int i = 0; i < m_DListNode[from].Count; i++)
                {
                    if (m_DListNode[from][i].GetTo() == to)
                    {
                        m_DListNode[from].RemoveAt(i);
                        return true;
                    }
                }
            }
            m_iNumEdge--;
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
            return m_iNumEdge;
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

        public bool isDiGraph()
        {
            return m_bDigraph;
        }

        public void setDiGraph(bool isDiGraph)
        {
            this.m_bDigraph = isDiGraph;
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
            this.m_Nodes.Clear();
            this.m_DListNode.Clear();
        }

        #endregion


        // Function
        #region Advance Function

        public int SoMienDoThiLienThong()
        {
            if (isEmpty())
            {
                return 0;
            }

            int lable = 0;

            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].GetLable() == 0)
                {
                    lable += 1;
                    Visit(m_Nodes[i],ref lable);
                }
            }

            return lable;
        }

        protected void Visit(MyGraphNode node,ref int lable)
        {
            node.SetLable(lable);
            if (m_DListNode.ContainsKey(node.getIndex()))
            {
                for (int i = 0; i < m_DListNode[node.getIndex()].Count; i++)
                {
                    int from = node.getIndex();
                    int to = m_DListNode[from][i].GetTo();
                    if (m_Nodes[to].GetLable() == 0)
                    {
                        Visit(m_Nodes[to],ref lable);
                    }
                    else
                    {
                      //  UpdateLable(lable, m_Nodes[to].GetLable());
                        lable = m_Nodes[to].GetLable();
                    }
                }
            }
        }

        protected void UpdateLable(int oldLable, int newLable)
        {
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                if (m_Nodes[i].GetLable() == oldLable)
                {
                    m_Nodes[i].SetLable(newLable);
                }
            }
        }
        #endregion

    }
}
