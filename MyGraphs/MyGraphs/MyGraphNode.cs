using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraphs
{
    public class MyGraphNode
    {
        protected int m_iIndex;
        protected int m_iLable;

        public MyGraphNode(int index = 0)
        {
            this.m_iIndex = index;
            this.m_iLable = 0;
        }

        public void SetIndex(int new_index)
        {
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

        private bool ValidateIndex()
        {
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

        public void SetLable(int lable)
        {
            this.m_iLable = lable;
        }

        public int GetLable()
        {
            return this.m_iLable;
        }
    }
}
