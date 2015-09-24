using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace GameLibrary.MObject.MyData
{
    public class MyData
    {
        private static MyData m_data;
        private MyData()
        {

        }

        public static MyData Instance()
        {
            if(m_data == null)
            {
                m_data = new MyData();
            }
            return m_data;
        }

        public MyBots LoadPlayer()
        {
            MyBots fbot = new MyBots();
            using (StreamReader r = new StreamReader("E:/playerinfo.txt"))
            {
                string json = r.ReadToEnd();
                // List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                fbot = JsonConvert.DeserializeObject<MyBots>(json);

            }
            return fbot;
        }

        public void SavePlayer(MyBots bot)
        {
            string json = JsonConvert.SerializeObject(bot);
            System.IO.File.WriteAllText("E:/playerinfo.txt", json);
        }


    }
}
