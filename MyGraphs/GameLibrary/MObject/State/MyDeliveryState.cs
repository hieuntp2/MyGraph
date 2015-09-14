
namespace GameLibrary
{
    // Should all state delivery from MyState is follow Singleton Design Pattern to reduce memory and allocate/delocated
    public class MyDeliveryState: MyState
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

        public override void Enter(MObject.GameObject gameObject)
        {
        }

        public override void Execute(MObject.GameObject gameObject)
        {
        }

        public override void Exit(MObject.GameObject gameObject)
        {
        }

        public override bool OnMessage(MObject.GameObject gameObject, MObject.MyMessageSystem.Telegram message)
        {
            return false;
        }
    }
}
