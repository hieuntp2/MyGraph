
namespace GameLibrary.MObject.MyMessageSystem
{
    public class Telegram
    {
        public int SenderID;
        public int RecieverID;

        /// <summary>
        /// ???
        /// </summary>
        public int Msg;

        /// <summary>
        /// Time to delay Message
        /// </summary>
        public int DispatchTime;


        public GameObject ExtraInfo;

        public Telegram()
        { }
        
        public Telegram(int delay, int senderid, int receiverid, int messagecode, GameObject ExtraInfo)
        {
            this.DispatchTime = delay;
            this.ExtraInfo = ExtraInfo;
            this.Msg = messagecode;
            this.RecieverID = receiverid;
            this.SenderID = senderid;
        }
    }
}
