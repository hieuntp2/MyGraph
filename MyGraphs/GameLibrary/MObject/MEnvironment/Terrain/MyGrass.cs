using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.MObject.MEnvironment.Terrain
{
    public class MyGrass: MyEnvironment
    {
        public MyGrass()
        {
            Cost = 1;
            ID_CLASS = 1;
        }

        public override bool HandleMessage(MyMessageSystem.Telegram message)
        {
            throw new NotImplementedException();
        }
    }
}
