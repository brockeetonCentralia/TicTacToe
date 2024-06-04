using System.Windows.Forms;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class frmGameboardTest
    {
        [TestMethod]
        public void ProcessTurn_HasWinner_CurrentPlayerTurn()
        {
            frmGameboard frmGameboard = new frmGameboard();
            stateConditionsManager.hasWinner = true;

            Assert.AreEqual(frmGameboard.ProcessTurn(frmGameboard.SetButtonCells()[0]), frmGameboard.ShowCurrentPlayerTurn());
        }

        [TestMethod]
        public void ProcessTurn_IsBtnCellNullOrEmpty_CurrentPlayerTurn()
        {
            frmGameboard frmGameboard = new frmGameboard();

            Assert.AreEqual(frmGameboard.ProcessTurn(frmGameboard.SetButtonCells()[0]), frmGameboard.ShowCurrentPlayerTurn());
        }

        [TestMethod]
        public void ProcessTurn_CheckForWinner_CurrentPlayerWins()
        {
            frmGameboard frmGameboard = new frmGameboard();
            stateTurnManager.turnCount = 5;

            frmGameboard.btnCells[0].Text = stateTurnQueue.currentPlayer.playerSymbol;
            frmGameboard.btnCells[3].Text = stateTurnQueue.currentPlayer.playerSymbol;

            Assert.AreEqual(frmGameboard.ProcessTurn(frmGameboard.SetButtonCells()[6]), String.Format("{0} wins!", stateTurnQueue.currentPlayer.playerSymbol));
        }

        [TestMethod]
        public void ProcessTurn_CatsGame_Draw()
        {
            frmGameboard frmGameboard = new frmGameboard();
            stateTurnManager.turnCount = 9;

            int opponentIndex = (stateTurnQueue.currentPlayerIndex == 0) ? 1 : 0;
            string opp = frmGameboard.chrPlayers[opponentIndex].playerSymbol;
            string player = stateTurnQueue.currentPlayer.playerSymbol;

            frmGameboard.btnCells[0].Text = player;
            frmGameboard.btnCells[1].Text = player;
            frmGameboard.btnCells[2].Text = opp;

            frmGameboard.btnCells[3].Text = opp;
            frmGameboard.btnCells[4].Text = opp;
            frmGameboard.btnCells[5].Text = player;

            frmGameboard.btnCells[6].Text = player;
            frmGameboard.btnCells[7].Text = opp;

            Assert.AreEqual(frmGameboard.ProcessTurn(frmGameboard.SetButtonCells()[8]), "Cat's Game");
        }
    }
}