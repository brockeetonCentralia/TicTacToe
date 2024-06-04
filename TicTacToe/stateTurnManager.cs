using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class stateTurnManager
    {
        public static int turnCount = 0;

        public static int IncrementTurn()
        {
            return turnCount = Math.Clamp(turnCount + 1, 1, 9);
        }

        public static int ResetTurn()
        {
            return turnCount = 0;
        }
    }
}
