using System.Collections.Generic;

namespace GameLibrary.MObject
{
    /// <summary>
    /// This is singleton-class. Manage all gameobject
    /// </summary>
    class MyEntityManager
    {
        private Dictionary<int, GameObject> m_cEntityMap;
        private static MyEntityManager m_cInstance;

        private MyEntityManager()
        {
            m_cEntityMap = new Dictionary<int, GameObject>();
        }

                
        public static MyEntityManager Instance()
        {
            if (m_cInstance == null)
            {
                m_cInstance = new MyEntityManager();
            }
            return m_cInstance;
        }

        /// <summary>
        /// Regist a new game object to system manager
        /// </summary>
        /// <param name="entity">return false if already have GameObject ID. Return true if regist success</param>
        public bool RegisterEntity(GameObject entity)
        {
            if(m_cEntityMap.ContainsKey(entity.GetID()))
            {
                return false;
            }

            m_cEntityMap.Add(entity.GetID(), entity);
            return true;
        }

        public bool RemoveEntiy(GameObject entity)
        {
            if (!m_cEntityMap.ContainsKey(entity.GetID()))
            {
                return false;
            }

            m_cEntityMap.Remove(entity.GetID());
            return true;
        }

        public GameObject GetGameObjectFromID(int id)
        {
            if(m_cEntityMap.ContainsKey(id))
            {
                return m_cEntityMap[id];
            }
            return null;
        }
    }
}
