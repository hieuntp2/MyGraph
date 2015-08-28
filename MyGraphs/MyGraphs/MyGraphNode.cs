using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    class MyGraphNode
    {
        protected int m_iIndex;

        public MyGraphNode(int index) {
            this.m_iIndex = index;
        }

        public void SetIndex(int new_index) {
            this.m_iIndex = new_index;
        }

        public int getIndex()
        {
            return m_iIndex;
        }

        public bool setIndex(int index)
        {
            this.m_iIndex = index;
            return ValidateIndex();
        }

        private bool ValidateIndex() {
            if (m_iIndex < 0)
            {
                return false;
            }

            return true;
        }

        public bool isValid()
        {
            if (m_iIndex >= 0)
            {
                return true;
            }
            else { return false; }
        }

        public void setInvalid() 
        {
            this.m_iIndex = -1;
        }
    }
}
