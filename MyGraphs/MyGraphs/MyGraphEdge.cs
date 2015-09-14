
namespace MyGraphs
{
    public class MyGraphEdge
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

        public float GetCost() {
            return m_dCost;        
        }
    }
}
