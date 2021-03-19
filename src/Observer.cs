using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    public abstract class Observer
    {
        public string name;
        public int position;
        public bool inJail;
        public int jailCount;

        public static Player getPlayerObject(string type)
        {
            return new Player(type);
        }

        public abstract void update();
    }
}
