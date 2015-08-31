using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    public class MyListGraphEdge
    {
        protected int m_iTo;
        protected float m_fCost;

        public MyListGraphEdge(int to, float cost = 1)
        {
            this.m_iTo = to;
            this.m_fCost = cost;
        }
        public int GetTo() {
            return m_iTo;
        }

        public float GetCost()
        {
            return m_fCost;
        }
    }
}
