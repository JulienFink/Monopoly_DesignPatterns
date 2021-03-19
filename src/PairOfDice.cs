using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    public class PairOfDice
    {
        public Random rand = new Random();

        //Ctor
        public PairOfDice() { }

        //Animation of dices rolling
        public void loadingRoll()
        {
            Console.Write("Rolling Dices");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Thread.Sleep(500);
            Console.WriteLine();
        }

        //Value of the first dice
        public int rollFirstDice()
        {
            int value = this.rand.Next(1, 7);
            return value;
        }

        //Value of the second dice
        public int rollSecondDice()
        {
            int value = this.rand.Next(1, 7);
            return value;
        }
    }
}
