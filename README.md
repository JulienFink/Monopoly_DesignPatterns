# Monopoly_DesignPatterns
A very simple version of the Monopoly Game implementing Design Patterns

The game is played on a circular game board, composed of 40 positions, indexed from 0 to 39.

• A set of players is given, each with a name and an initial position. Dices are rolled and
players’ positions on the game board will change

• If a player reaches position 39 and still needs to move forward, he'll continue
from position 0. In other words, positions 38, 39, 0, 1, 2 are contiguous

• Each player rolls two dices and moves forward by a number of position equal
to the numbers' sum of the two dices

• A player’s turn ends after having moved to its new position

• The same position can be occupied by more than one player

• If a player gets both dices with the same value, then he rolls the dice and moves
again. If this happens three times in a row, the player goes to jail and ends his
turn

• Jail can be a situation the player is in, or a place he pays visit to. The board
therefore has a Visit Only / In Jail cell at position 10. A Go To Jail cell is also
present, at position 30

• If at the end of a basic move, the player lands on Go To Jail, then he immediately
moves to the position Visit Only / In Jail and is in jail. His turn ends

• If after moving, the player lands on Visit Only / In Jail, he is visiting only and is
not in jail

• While the player is in jail, he still rolls the dice on his turn as usual, but does not
move until either:

(a) he gets both dices with the same value, or
(b) he fails to roll both dices with the same value for three times in a row
(i.e., his previous two turns after moving to jail and his current turn)

If either (a) or (b) happens in the player's turn, then he moves forward by the
sum of the dice rolled positions and his turn ends. He does not roll the dice
again even if he has rolled both dices with the same value.
