using MyGraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPathPlaner
{
    public class MyPathPlanner
    {
        private GameObject m_cOwnerObject;
        private MyListGraph m_cMap;
        private Vector2 m_cDestinationPosition;

        public MyPathPlanner(GameObject ownerObject, MyListGraph map)
        {
            m_cOwnerObject = ownerObject;
            this.m_cMap = map;
        }
        
        private MyGraphNode GetClosestNodeToPosition(Vector2 position)
        {
            return null;
        }

        public List<Vector2> CreatePathToPosition(Vector2 TargetPos)
        {
            return null;
        }

        public List<Vector2> CreatePathToItem(int typeofItem)
        {
            return null;
        }
    }

    public class GameObject
    {

    }

    public class Vector2
    {
        public float x, y;
    }
}
