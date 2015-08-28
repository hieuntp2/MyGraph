using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    class MyGraphEdge
    {
        protected int m_iFrom;
        protected int m_iTo;
        protected float m_dCost;

        public MyGraphEdge(int from, int to, float cost = 1) {
            this.m_iFrom = from;
            this.m_iTo = to;
            this.m_dCost = cost;
        }

        public int GetFrom() {
            return m_iFrom;
        }

        public int GetTo() {
            return m_iTo;
        }
    }
}
