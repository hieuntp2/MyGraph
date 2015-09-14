using GameLibrary.MObject.MyMessageSystem;

namespace GameLibrary.MObject
{
    public abstract class GameObject
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

        public abstract bool HandleMessage(Telegram message);
    }
}
