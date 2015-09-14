using GameLibrary.MObject.MyMessageSystem;

namespace GameLibrary.MObject.State
{
    public class MyStateMachine
    {
        private GameObject m_cOwner;
        MyState m_cCurrentState;
        MyState m_cPreState;
        MyState m_cGlobalState;

        public MyStateMachine(GameObject gameObject)
        {
            this.m_cOwner = gameObject;
        }

        public void SetCurrentState(MyState state)
        {
            this.m_cCurrentState = state;
        }
        public void SetGlobalState(MyState state)
        {
            this.m_cGlobalState = state;
        }
        public void SetPreState(MyState state)
        {
            this.m_cPreState = state;
        }

        public void Update()
        {
            if (this.m_cGlobalState != null)
            {
                this.m_cGlobalState.Execute(this.m_cOwner);
            }

            if (this.m_cCurrentState != null)
            {
                this.m_cCurrentState.Execute(this.m_cOwner);
            }
        }

        public void ChangeState(MyState newState)
        {
            if (newState == null)
            {
                return;
            }

            m_cPreState = m_cCurrentState;
            m_cCurrentState.Exit(m_cOwner);
            m_cCurrentState = newState;
            m_cCurrentState.Enter(m_cOwner);
        }

        public void RevertToPreviosState()
        {
            ChangeState(m_cPreState);
        }

        public MyState CurrentState()
        {
            return m_cCurrentState;
        }

        public MyState PreviousState()
        {
            return m_cPreState;
        }

        public MyState GlobleState()
        {
            return m_cGlobalState;
        }

        public bool isInState(MyState state)
        {
            return true;
        }

        public bool HandleMessage(Telegram message)
        {
            if(m_cCurrentState != null)
            {
                if(m_cCurrentState.OnMessage(m_cOwner, message))
                {
                    return true;
                }
            }

            if (m_cGlobalState != null)
            {
                if (m_cGlobalState.OnMessage(m_cOwner, message))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
