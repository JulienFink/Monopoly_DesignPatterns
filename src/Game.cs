using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDesignPattern
{
    public class Game
    {
        public GameBoard board;
        public List<Observer> players;
        public PairOfDice dices;

        //Ctor
        public Game()
        {
            this.players = new List<Observer>();
            this.board = GameBoard.getInstance();
            this.dices = new PairOfDice();
        }

        //Notifies the player class through Observer Pattern
        public void notifyPlayers(Player k)
        {
            k.update();
        }

        //Sets a player in jail
        public void goesToJail(Player k)
        {
            k.inJail = true;
            notifyPlayers(k);
            k.position = 10;
        }

        //Used at the creation of the GameBoard : each player in position 0.
        public void setPlayersOnBoard(Player[] list_of_players)
        {
            for (int i = 0; i < list_of_players.Length; i++)
            {
                board.Bplayers[i] = list_of_players[i];
            }
        }

        //Sets the position of a specific player
        public void setPosition(Player k, int value)
        {
            //If player's position exceeds 39, we start again from 0
            if (k.position + value > 39)
            {
                int more = k.position + value - 40;
                k.position = more;
            }
            else
            {
                k.position += value;
            }
            getPositionPlayer(k);
        }

        //Get the position of a specific player on the GameBoard
        public void getPositionPlayer(Player k)
        {
            Console.WriteLine("Player {0} moves to position {1} !", k.name, k.position);
        }

        //Get the position of each player on the GameBoard
        public void getPositionPlayers()
        {
            Console.WriteLine();

            foreach (Player k in this.board.Bplayers)
            {
                Console.WriteLine("{0} is in position {1}.", k.name, k.position);
            }

            Console.WriteLine();
        }

        //If 3 rounds have passed and the player is still in jail - poor guy :(
        public bool shouldWeReleasePlayer(int i)
        {
            this.board.Bplayers[i].jailCount++;

            //We finally release him...
            if (this.board.Bplayers[i].jailCount == 3)
            {
                this.board.Bplayers[i].jailCount = 0;
                return true;
            }
            return false;
        }

        //Main function that launches the game
        public void playingGame(int index, int a, int b, int recur)
        {
            //If the player is in jail
            if (this.board.Bplayers[index].inJail)
            {
                //We check if he should be freed or not.
                if (this.shouldWeReleasePlayer(index) || a == b)
                {
                    this.board.Bplayers[index].inJail = false;
                    Console.WriteLine("Player {0} is no more in jail", this.board.Bplayers[index].name);
                }
            }
            //If the player is not already in jail, we can set him new position
            else
            {
                //Moving a player on the board, depending of the value of the two dices.
                this.setPosition(this.board.Bplayers[index], a + b);

                //if player's new position is 30, he goes to jail (Again ?!)
                if (this.board.Bplayers[index].position == 30)
                {
                    //The player goes to jail in position 10
                    this.goesToJail(this.board.Bplayers[index]);
                }
                //If dices' values are the same, player x plays again
                if (a == b)
                {
                    //3 times in a row = jail
                    if (recur == 3)
                    {
                        this.goesToJail(this.board.Bplayers[index]);
                    }
                    else
                    {
                        Console.WriteLine("-- The two dices have the same value, {0} plays again !", this.board.Bplayers[index].name);
                        dices.loadingRoll();

                        a = (int)dices.rollFirstDice();
                        b = (int)dices.rollSecondDice();
                        recur++;
                        playingGame(index, a, b, recur);
                    }

                }
            }
        }
    }
}
