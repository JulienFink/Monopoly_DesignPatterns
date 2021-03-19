using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    public class GameBoard
    {
        private static GameBoard instance;
        public Player[] Bplayers;

        //Ctor is defined as private.
        private GameBoard() { }

        //Using the Singleton Patter, we ensure that one and only one instance of GameBoard will be created and used along the game.
        public static GameBoard getInstance()
        {
            if (instance == null)
            {
                instance = new GameBoard();

                //We define 5 players.
                instance.Bplayers = new Player[5];
            }

            return instance;
        }
    }
}
