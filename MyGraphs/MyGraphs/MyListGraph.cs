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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isDirectGraph">Mặc định là đồ thị vô hướng, nếu đặt bằng true sẽ là đồ thị có hướng</param>
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
            if (node.getIndex() == 0)
                node.setIndex(index: GetNextFreeNodeIndex());

            if (!isPresent(node.getIndex()))
            {
                m_Nodes.Add(node);
            }
            return node.getIndex();
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

            //// Nếu là đồ thị vô hướng thì thêm 1 cạnh ngược lại
            if (!this.m_bDigraph)
            {
                if (m_DListNode.ContainsKey(to))
                {
                    m_DListNode[to].Add(new MyListGraphEdge(from, cost));
                }
                else
                {
                    m_DListNode.Add(to, new List<MyListGraphEdge>());
                    m_DListNode[to].Add(new MyListGraphEdge(from, cost));
                }
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


        /// <summary>
        ///  Xóa khuyên và cạnh song song. Nếu có cạnh song song thì chọn cạnh có trọng số nhỏ nhất
        /// </summary>
        public void MakeSimpleGraph()
        {
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                int from = m_Nodes[i].getIndex();

                if (m_DListNode.ContainsKey(from))
                {
                    for (int j = 0; j < m_DListNode[from].Count; j++)
                    {
                        // Xóa cạnh khuyên
                        int to = m_DListNode[from][j].GetTo();
                        if (to == from)
                        {
                            m_DListNode[from].RemoveAt(j);
                        }

                        if (this.m_bDigraph)
                        {
                            // Xóa cạnh song song
                            if (m_DListNode.ContainsKey(to))
                            {
                                for (int k = 0; k < m_DListNode[to].Count; k++)
                                {
                                    if (m_DListNode[to][k].GetTo() == from)
                                    {
                                        // Xóa cạnh song song có trọng số lớn hơn
                                        if (m_DListNode[to][k].GetCost() > m_DListNode[from][j].GetCost())
                                        {
                                            m_DListNode[to].RemoveAt(k);
                                        }
                                        else
                                        {
                                            m_DListNode[from].RemoveAt(j);
                                        }
                                        // m_DListNode[to].RemoveAt(k);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PrintGraphInConsole()
        {
            Console.Write("Canh: ");
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                Console.Write(" " + m_Nodes[i].getIndex() + ",");
            }

            Console.WriteLine("\n So Canh:");
            for (int i = 0; i < m_Nodes.Count; i++)
            {
                int from = m_Nodes[i].getIndex();
                if (m_DListNode.ContainsKey(from))
                {
                    Console.Write("(" + from.ToString() + "): ");
                    for (int j = 0; j < m_DListNode[from].Count; j++)
                    {
                        Console.Write(" -" + m_DListNode[from][j].GetTo() + "," + m_DListNode[from][j].GetCost() + "- ");
                    }
                }
                Console.WriteLine();

            }
        }

        private bool CheckEdgeContaint(int from, int to)
        {
            if (m_DListNode.ContainsKey(from))
            {
                for (int i = 0; i < m_DListNode[to].Count; i++)
                {
                    if (m_DListNode[from][i].GetTo() == from)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion


        // Function
        #region Prim Function

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
                    Visit(m_Nodes[i], ref lable);
                }
            }

            return lable;
        }

        protected void Visit(MyGraphNode node, ref int lable)
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
                        Visit(m_Nodes[to], ref lable);
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

        /// <summary>
        /// Tìm cây khung có trọng số nhỏ nhất
        /// </summary>
        /// <returns></returns>
        public MyListGraph PrimAlgo(MyGraphNode startNode)
        {
            MyListGraph result = new MyListGraph(this.m_bDigraph);

            List<int> p_fNodes = new List<int>();
            List<MyGraphEdge> p_fEdges = new List<MyGraphEdge>();


            p_fNodes.Add(startNode.getIndex());

            while (p_fEdges.Count < this.m_Nodes.Count)
            {
                MyGraphEdge edge = PrimFindEdge(p_fNodes, p_fEdges);
                if (edge != null)
                {
                    p_fNodes.Add(edge.GetTo());
                    p_fEdges.Add(edge);
                }
                else
                {
                    // Đồ thị không liên thông
                    break;
                }
            }

            for (int i = 0; i < p_fNodes.Count; i++)
            {
                result.AddNode(new MyGraphNode(p_fNodes[i]));
            }
            for (int i = 0; i < p_fEdges.Count; i++)
            {
                result.AddEdge(p_fEdges[i]);
            }

            return result;
        }

        private MyGraphEdge PrimFindEdge(List<int> p_fNodes, List<MyGraphEdge> p_fEdges)
        {
            MyGraphEdge result = null;
            float m_fmin = float.MaxValue;

            for (int i = 0; i < p_fNodes.Count; i++)
            {

                // Nếu node có chứa cạnh thì tìm ra cạnh có trọng số nhỏ nhất
                if (this.m_DListNode.ContainsKey(p_fNodes[i]))
                {
                    for (int j = 0; j < m_DListNode[p_fNodes[i]].Count; j++)
                    {
                        // Nếu node đến ko chứa trong mảng đã có thì so sánh
                        MyListGraphEdge temp = m_DListNode[p_fNodes[i]][j];

                        if (p_fNodes.Contains(temp.GetTo()))
                        {
                            continue;
                        }

                        //if (!this.m_bDigraph)
                        //{
                        //    if (p_fNodes.Contains(p_fNodes[i]))
                        //        continue;
                        //}
                        if (m_fmin > temp.GetCost())
                        {
                            m_fmin = temp.GetCost();
                            result = new MyGraphEdge(p_fNodes[i], temp.GetTo(), temp.GetCost());
                        }

                    }
                }
            }


            return result;
        }

        #endregion

        #region Dijktra Function

        public List<MyGraphEdge> FindTheShortestPath(int fromNode, int toNode)
        {
            List<Dijktra_node> BeyoundT = new List<Dijktra_node>();
            Dijktra_node f_fromNode = new Dijktra_node(), f_toNode = new Dijktra_node();
            List<MyGraphEdge> result = new List<MyGraphEdge>();

            Dijktra_init(fromNode, toNode, ref f_fromNode, ref f_toNode, BeyoundT);
            int current_sequence = 0;
            int last_node = fromNode;
            // Trong khi chưa đạt đến đích thì tiếp tục
            while (f_toNode.check)
            {
                Dijktra_node node = DijktraFindEdge(BeyoundT);
                if (node == null)
                {
                    break;
                }
                node.sequence = current_sequence;
                current_sequence += 1;
                MyGraphEdge edge = new MyGraphEdge(last_node, node.index, node.lenght);
                result.Add(edge);

                last_node = node.index;
                node.check = false;
                ImprovePaths(node, BeyoundT);
            }

            return result;
        }



        /// <summary>
        /// Tìm cạnh có độ dài nhỏ nhất
        /// </summary>
        /// <param name="listnode"></param>
        /// <returns></returns>
        private Dijktra_node DijktraFindEdge(List<Dijktra_node> listnode)
        {
            float min_path = float.MaxValue;
            int index_node = -1;
            for (int i = 0; i < listnode.Count; i++)
            {
                if(!listnode[i].check)
                {
                    if (listnode[i].lenght < min_path)
                    {
                        min_path = listnode[i].lenght;
                        index_node = i;
                    }
                }                
            }
            
            if(index_node != -1)
            {
                return listnode[index_node];
            }
            return null;
        }

        /// <summary>
        /// Nâng cấp các đỉnh có cạnh nối đến node tìm ra
        /// </summary>
        /// <param name="node"></param>
        /// <param name="listnode"></param>
        private void ImprovePaths(Dijktra_node node, List<Dijktra_node> listnode)
        {
            int index = node.index;
            for(int i =0; i < m_DListNode[index].Count; i++)
            {
                for(int j = 0; j < listnode.Count; j++)
                {
                    if(listnode[j].check)
                    {
                        float dist = listnode[j].lenght += m_DListNode[index][i].GetCost();
                        if (m_DListNode[index][i].GetTo() == listnode[j].index)
                        {
                            if (listnode[j].lenght == -1 && listnode[j].lenght > dist)
                            {
                                listnode[j].lenght = dist;
                            }                            
                        }
                    }                    
                }
            }
        }


        private void Dijktra_init(int fromNode, int toNode, ref Dijktra_node f_fromNode, ref Dijktra_node f_toNode, List<Dijktra_node> BeyoundT)
        {
            for (int i = 0; i < this.m_Nodes.Count; i++)
            {
                Dijktra_node node = new Dijktra_node();
                node.index = this.m_Nodes[i].getIndex();
                node.check = true;
                node.sequence = -1;
                node.lenght = -1;

                if (fromNode == node.index)
                {
                    f_fromNode = node;
                    f_fromNode.check = false;
                }

                if (toNode == node.index)
                {
                    f_toNode = node;
                }

                BeyoundT.Add(node);
            }
        }

        private class Dijktra_node
        {
            public int index;
            public bool check;
            public int sequence;
            public float lenght;
        }

        #endregion

    }
}
