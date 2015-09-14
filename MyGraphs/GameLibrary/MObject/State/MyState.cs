using GameLibrary.MObject;
using GameLibrary.MObject.MyMessageSystem;

namespace GameLibrary
{
    public abstract class MyState
    {
        public abstract void Enter(GameObject gameObject);
        public abstract void Execute(GameObject gameObject);
        public abstract void Exit(GameObject gameObject);
        public abstract bool OnMessage(GameObject gameObject, Telegram message);
    }
}
