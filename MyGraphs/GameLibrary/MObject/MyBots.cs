using GameLibrary.MObject.State;
using MyPathPlaner;

namespace GameLibrary.MObject
{
    public class MyBots : GameObject
    {
        private MyStateMachine m_cStateMachine;
        private Vector2 m_cCurrentPosition;
        private int m_iCurrentIndexLocation;

        // some propertiese
        private int m_iHealth;
        private int m_iWood;
        private int m_iFood;
        private int m_iCurrentWater;
        private int m_iCurrentThirsty;
        private int m_iCurrentTired;
        private int m_iCurrentHungry;
        private int m_CurrentEnery;
        private float m_fSpeed;

        private Weapon m_iCurrentWeapon;     
  
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
