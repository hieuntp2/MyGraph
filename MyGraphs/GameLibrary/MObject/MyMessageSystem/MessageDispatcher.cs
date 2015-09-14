using System.Collections.Generic;

namespace GameLibrary.MObject.MyMessageSystem
{
    /// <summary>
    /// This class is singleton design. 
    /// This is the message handler
    /// </summary>
    class MessageDispatcher
    {
        private HashSet<Telegram> m_hMessages;
        private static MessageDispatcher m_cInstance;

        private MessageDispatcher()
        {
            m_cInstance = new MessageDispatcher();
            m_hMessages = new HashSet<Telegram>();
        }

        /// <summary>
        /// Send message to game object
        /// </summary>
        /// <param name="reciever"></param>
        /// <param name="msg"></param>
        private void Discharge(GameObject reciever, Telegram msg)
        {

        }

        public static MessageDispatcher Instance()
        {
            if (m_cInstance == null)
            {
                m_cInstance = new MessageDispatcher();
            }

            return m_cInstance;
        }

        /// <summary>
        /// Send a message to specific object by receiverid
        /// </summary>
        /// <param name="delay">Time delay  (milisecond)</param>
        /// <param name="senderid">Send ID</param>
        /// <param name="receiverid">Receiver ID</param>
        /// <param name="message">Message Code</param>
        /// <param name="ExtraInfo">More Infor</param>
        public void DispatchMessage(int delay, int senderid, int receiverid, int message, GameObject ExtraInfo)
        {
            Telegram _message = new Telegram();
            _message.DispatchTime = delay;
            _message.ExtraInfo = ExtraInfo;
            _message.Msg = message;
            _message.RecieverID = receiverid;
            _message.SenderID = senderid;

            // if delay <= 0 then we send message immediately
            if (delay <= 0)
            {
                GameObject pReceiver = MyEntityManager.Instance().GetGameObjectFromID(receiverid);
                Discharge(pReceiver, _message);
            }
            else
            {
                m_hMessages.Add(_message);
            }
        }

        /// <summary>
        /// Send out any delayed message. This method is called each time through the main game loop
        /// </summary>
        public void DispatchDelayedMessage(int GameTime)
        {
            foreach (Telegram item in m_hMessages)
            {
                if (item.DispatchTime <= 0)
                {
                    GameObject pReceiver = MyEntityManager.Instance().GetGameObjectFromID(item.RecieverID);
                    Discharge(pReceiver, item);

                    // remove item
                    m_hMessages.Remove(item);
                }
                else
                {
                    item.DispatchTime -= GameTime;
                }
            }
        }

    }
}
