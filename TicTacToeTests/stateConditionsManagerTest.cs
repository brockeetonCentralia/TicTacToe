using System.Windows.Forms;
using TicTacToe;

namespace TicTacToeTests
{
    [TestClass]
    public class stateConditionsManagerTest
    {
        [TestMethod]
        public void HasWon_VerticalWin_True()
        {
            stateConditionsManager.board = ["X", "", "", "X", "", "", "X", "", ""];

            Assert.IsTrue(stateConditionsManager.HasWon("X"));
        }

        [TestMethod]
        public void HasWon_HorizontalWin_True()
        {
            stateConditionsManager.board = ["X", "X", "X", "", "", "", "", "", ""];

            Assert.IsTrue(stateConditionsManager.HasWon("X"));
        }

        [TestMethod]
        public void HasWon_DiagonalWin_True()
        {
            stateConditionsManager.board = ["X", "", "", "", "X", "", "", "", "X"];

            Assert.IsTrue(stateConditionsManager.HasWon("X"));
        }

        [TestMethod]
        public void HasWon_NoWinnerBeforeFinalTurn_False()
        {
            stateConditionsManager.board = ["X", "O", "X", "O", "O", "X", "", "", ""];

            Assert.IsFalse(stateConditionsManager.HasWon("X"));
        }
    }
}