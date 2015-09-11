using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGraphs;
using System.IO;
using MyPathPlaner;

namespace GameLibrary
{
    public class MyMap
    {
        private MyListGraph m_cGraph;
        Dictionary<int, MyMapNode> m_cNodeMap;

        public MyMap()
        {
            m_cGraph = new MyListGraph();
            m_cNodeMap = new Dictionary<int, MyMapNode>();
        }

        public bool ReadMap(string fileaddress)
        {
            string line;
            string[] words;

            // Read the file and display it line by line.
            StreamReader file = new System.IO.StreamReader(fileaddress);

            // read width and height
            words = file.ReadLine().Split(' ');

            // if file doesnt containt width and height value, return false;
            if (words.Count() != 2)
            {
                return false;
            }

            short f_MapWidth, f_MapHeight;
            if (!Int16.TryParse(words[0], out f_MapWidth) ||
                !Int16.TryParse(words[1], out f_MapHeight))
            {
                return false;
            }

            MyMapNode[,] temp_map = new MyMapNode[f_MapWidth, f_MapHeight];
            // read map infor
            for (int i = 0; i < f_MapHeight; i++)
            {
                words = file.ReadLine().Split(' ');
                for (int j = 0; j < f_MapWidth; j++)
                {
                    MyMapNode node = new MyMapNode();
                    node.x = i;
                    node.y = j;

                    // Add Node
                    node.index = m_cGraph.AddNode(new MyGraphNode());
                    temp_map[i, j] = new MyMapNode();
                    temp_map[i, j].index = node.index;
                    node.cost = float.Parse(words[j]);
                    temp_map[i, j].cost = node.cost;

                    // Add Edge
                    if (node.cost > 0)
                    {
                        CheckToAddEdge(f_MapWidth, temp_map, i, j);
                    }

                    if(i == 0)
                    {
                        Console.Write(node.index.ToString() + "  ");
                    }
                    else
                    {
                        Console.Write(node.index.ToString() + ' ');
                    }
                    
                }
                Console.WriteLine();
            }

            file.Close();

            return true;
        }

        private void CheckToAddEdge(short f_MapWidth, MyMapNode[,] temp_map, int i, int j)
        {
            int x, y;
            // point 1
            x = i - 1; y = j-1;
            if (x >= 0 && y >= 0)
            {
                AddEdge(i, j, x, y, temp_map);
            }
            // point 2
            x = i-1; y = j;
            if (x >= 0)
            {
                AddEdge(i, j, x, y, temp_map);
            }
            // point 3
            x = i -1; y = j+1;
            if (y < f_MapWidth && x >= 0)
            {
                AddEdge(i, j, x, y, temp_map);
            }
            // point 4
            x = i; y = j - 1;
            if (y >= 0)
            {
                AddEdge(i, j, x, y, temp_map);
            }
        }

        private void AddEdge(int i, int j, int x, int y, MyMapNode[,] temp_map)
        {
            if (temp_map[x, y].cost > 0)
            {
                MyGraphEdge edge = new MyGraphEdge(temp_map[i, j].index, temp_map[x, y].index, temp_map[i, j].cost);
                m_cGraph.AddEdge(edge);
            }
        }

        public List<MyGraphEdge> FindPath(int indexFrom, int indexTo)
        {
            return m_cGraph.FindTheShortestPath(indexFrom, indexTo);
        }        
    }

    public class MyMapNode
    {
        public float x, y;
        public int index;
        public float cost;
        public GameObject Addition_information;
        public MyMapNode()
        {
            x = y = 0;
        }
    }

    public class GameObject
    {
        private int m_iID;
        private static int m_iNextValidID;

        public void SetID(int id)
        {
            this.m_iID = id;
            m_iNextValidID += 1;
        }

        public GameObject(int? id = null)
        {
            if(id==null)
            {
                this.SetID(m_iNextValidID);
            }
        }

        public int GetID()
        {
            return m_iID;
        }

        public static int GetNextValidID()
        {
            return m_iNextValidID;
        }
    }

    public class MyBots : GameObject
    {
        private MyState m_cCurrentState;
        private Vector2 m_cCurrentPosition;
        private int m_iCurrentIndexLocation;
        
        // some propertiese
        private int m_iHealth;
        private int m_iWood;
        private int m_iFood;       
        private int m_iCurrentWater;
        private int m_iCurrentThirsty;
        private int m_iCurrentTired;
        private int m_iCurrentHungry;
        private int m_CurrentEnery;
        private float m_fSpeed;

        private Weapon m_iCurrentWeapon;

        public void ChangeState(MyState newState)
        {
            m_cCurrentState.Exit(this);
            m_cCurrentState = newState;
            m_cCurrentState.Enter(this);
        }

        public void Update()
        {
            if(m_cCurrentState != null)
            {
                m_cCurrentState.Execute(this);
            }
        }
    }    
    
}
