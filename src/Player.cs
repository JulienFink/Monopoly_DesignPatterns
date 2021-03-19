using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    public class Player : Observer
    {
        //Ctor
        public Player(string str)
        {
            this.name = str;
            this.position = 0;
            this.inJail = false;
            this.jailCount = 0;
        }

        //Implementing the update method from the abstract class Observer
        public override void update()
        {
            if (inJail == true)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("- My buddy {0} is in jail ! -", this.name);
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
