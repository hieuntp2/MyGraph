using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    // Should all state delivery from MyState is follow Singleton Design Pattern to reduce memory and allocate/delocated
    public class MyDeliveryState
    {
        private static MyDeliveryState m_cInstance;
        private MyDeliveryState()
        {

        }

        public MyDeliveryState GetInstance()
        {
            if (m_cInstance == null)
            {
                m_cInstance = new MyDeliveryState();
            }
            return m_cInstance;
        }
    }
}
