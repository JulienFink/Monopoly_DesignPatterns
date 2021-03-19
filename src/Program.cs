using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    class Program
    {
        static void exercice3()
        {
            Game monopolyGame = new Game();

            Console.WriteLine(" _____________________________________________________________ ");
            Console.WriteLine("| Five players will confront each other in this Monopoly Game |");

            //Using Factory Design Pattern
            Player a = Observer.getPlayerObject("Horse");
            Player b = Observer.getPlayerObject("Dog");
            Player c = Observer.getPlayerObject("Shoe");
            Player d = Observer.getPlayerObject("Iron");
            Player e = Observer.getPlayerObject("Hat");

            Console.WriteLine("\nThere will be 5 players in this game : Horse, Dog, Shoe, Iron, Hat.");

            Player[] azertyuiop = new Player[] { a, b, c, d, e };

            monopolyGame.setPlayersOnBoard(azertyuiop);

            Console.WriteLine("\nHow many rounds do you want to play ? Enter your choice : ");
            int rounds = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            int i = 0;

            while (count < rounds * 5)
            {
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

                if (i == 5)
                {
                    Console.WriteLine("\n\n -- NEXT ROUND -- \n\n");
                    i = 0;
                }

                monopolyGame.dices.loadingRoll();

                int value1 = (int)monopolyGame.dices.rollFirstDice();
                int value2 = (int)monopolyGame.dices.rollSecondDice();

                int recur = 1;
                monopolyGame.playingGame(i, value1, value2, recur);

                //monopolyGame.playingGame(i, 4, 4, 1);

                i++;
                count++;

                Console.WriteLine();
            }

            Console.WriteLine("Game is over, thanks !");
            Thread.Sleep(3000);
        }

        static void Main(string[] args)
        {
            exercice3();
        }
    }
}
