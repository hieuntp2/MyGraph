using GameLibrary.MObject.State;
using MyPathPlaner;

namespace GameLibrary.MObject
{
    public class MyBots : GameObject
    {
        private MyStateMachine m_cStateMachine;
        public Vector2 m_cCurrentPosition { get; set; }
        public int m_iCurrentIndexLocation { get; set; }

        // some propertiese
        public int m_iHealth { get; set; }
        public int m_iWood { get; set; }
        public int m_iFood { get; set; }
        public int m_iCurrentWater { get; set; }
        public int m_iCurrentThirsty { get; set; }
        public int m_iCurrentTired { get; set; }
        public int m_iCurrentHungry { get; set; }
        public int m_CurrentEnery { get; set; }
        public float m_fSpeed { get; set; }

        public Weapon m_iCurrentWeapon { get; set; }

        public MyBots()
        {
            m_cStateMachine = new MyStateMachine(this);
        }

        public void Update()
        {
            m_cStateMachine.Update();
        }

        public MyStateMachine GetFSM()
        {
            return m_cStateMachine;
        }

        public override bool HandleMessage(MyMessageSystem.Telegram message)
        {
            return m_cStateMachine.HandleMessage(message);
        }


    }
}
