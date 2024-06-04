using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToe
{
    public static class stateConditionsManager
    {
        public static bool hasWinner = false;

        public static int turnCount = 0;

        public static int[] magicSquare = new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6 };
        public static string[] board = new string[9];
        public static int[] winningCells = new int[] { };

        public static string[] SetGameManagerBoard(Button[] btnCells)
        {
            int I = 0;
            foreach (Button btnCell in btnCells)
            {
                board[I] = btnCell.Text;
                I++;
            }

            return board;
        }

        // Check the player whose turn just finished first
        public static bool DetermineWinner(int turnCount, string player, out string header)
        {
            header = "";

            if (turnCount < 5)
                return false;

            if (HasWon(player))
            {
                header = System.String.Format("{0} wins!", player);
                return true;
            }

            return false;
        }

        public static bool CatsGame(int turnCount, out string headerTxtDraw)
        {
            headerTxtDraw = "";

            if (turnCount != 9)
                return false;

            headerTxtDraw = "Cat's Game";
            return true;
        }

        // https://fowlie.github.io/2018/08/24/winning-algorithm-for-tic-tac-toe-using-a-3x3-magic-square/
        public static bool HasWon(string playerSymbol)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    for (int k = 0; k < 9; k++)
                        if (i != j && i != k && j != k)
                            if (board[i] == playerSymbol && board[j] == playerSymbol && board[k] == playerSymbol)
                                if (magicSquare[i] + magicSquare[j] + magicSquare[k] == 15)
                                {
                                    // Store the squares that leads to a win and their associated integers, bring them back to the GUI then color them
                                    winningCells = new int[] { i, j, k };
                                    return true;
                                }
            return false;
        }

        public static void GameReset()
        {

        }
    }
}
