using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class stateTurnQueue
    {
        public static int amtPlayers = 0;
        public static int currentPlayerIndex;
        public static chrPlayer currentPlayer;

        public static int AssignFirstTurnPlayerIndex()
        {
            Random random = new Random(DateTime.Now.Second);
            int randomisedValue = random.Next(2);

            return currentPlayerIndex = (randomisedValue == 0) ? 0 : 1;
        }

        public static void IntializeTurnQueue(int newAmtPlayers)
        {
            amtPlayers = newAmtPlayers;
            currentPlayerIndex = 0;
        }

        // 1 % 2 = 1 and 0 % 2 = 0
        public static int UpdateCurrentPlayerIndex()
        {
            return currentPlayerIndex = (currentPlayerIndex + 1) % amtPlayers;
        }

        public static void ResetTurnQueue()
        {
            AssignFirstTurnPlayerIndex();
            IntializeTurnQueue(amtPlayers);
        }
    }
}
