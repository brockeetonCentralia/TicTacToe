using System.Numerics;

namespace TicTacToe
{
    public partial class frmGameboard : Form
    {
        public Button[] btnCells { get; set; }
        public chrPlayer[] chrPlayers { get; set; }

        private int xWins = 0;
        private int yWins = 0;

        public frmGameboard()
        {
            InitializeComponent();

            SetGameState();
        }

        public Button[] SetButtonCells()
        {
            btnCells = new Button[]
            {
                btnCell1, btnCell2, btnCell3,
                btnCell4, btnCell5, btnCell6,
                btnCell7, btnCell8, btnCell9
            };

            return btnCells;
        }

        private void SetGameState()
        {
            SetButtonCells();

            InitializeFirstTurn();
        }

        private void InitializeFirstTurn()
        {
            // Could eventually make into a new class if needed, something for specifically spawning
            chrPlayers = new chrPlayer[] { new chrPlayer("X", Color.Green), new chrPlayer("O", Color.Red) };

            stateTurnQueue.IntializeTurnQueue(chrPlayers.Length);

            chrPlayer currentPlayer = chrPlayers[stateTurnQueue.AssignFirstTurnPlayerIndex()];

            stateTurnQueue.currentPlayer = currentPlayer;
            txtHeader.Text = ShowCurrentPlayerTurn();
        }

        public string ShowCurrentPlayerTurn()
        {
            return String.Format("{0} turn", stateTurnQueue.currentPlayer.playerSymbol);
        }

        public string ProcessTurn(Button btnCell)
        {
            if (stateConditionsManager.hasWinner)
                return txtHeader.Text;

            if (!String.IsNullOrEmpty(btnCell.Text))
                return txtHeader.Text;

            btnCell.Text = stateTurnQueue.currentPlayer.playerSymbol;

            // stateTurnManager.turnCount++;
            stateTurnManager.IncrementTurn();

            chrPlayer? winner = null;

            string headerTxt = "";

            if (CheckForWinner(stateTurnManager.turnCount, out headerTxt, out winner))
            {
                stateConditionsManager.hasWinner = true;
                return ShowWinner(headerTxt, winner.foreColor);
            }

            // Check to see if the turn count is 9
            if (stateConditionsManager.CatsGame(stateTurnManager.turnCount, out headerTxt))
                return headerTxt;

            if (SetNextPlayer(stateTurnManager.turnCount))
                return ShowCurrentPlayerTurn();

            return txtHeader.Text;
        }

        private bool SetNextPlayer(int currentTurn)
        {
            if (currentTurn == 9)
                return false;

            stateTurnQueue.currentPlayer = chrPlayers[stateTurnQueue.UpdateCurrentPlayerIndex()];

            return true;
        }

        private bool CheckForWinner(int currentTurn, out string headerTxt, out chrPlayer? winner)
        {
            headerTxt = "";
            winner = null;

            if (currentTurn < 5)
                return false;

            stateConditionsManager.SetGameManagerBoard(btnCells);

            // This should be fine because it's turn based, which means that one person can win per turn only
            // Only check whoever just acted because if the person won then that means the game ends right there.
            chrPlayer player = stateTurnQueue.currentPlayer;

            if (stateConditionsManager.DetermineWinner(currentTurn, player.playerSymbol, out headerTxt))
            {
                winner = player;



                return true;
            }
            return false;
        }

        private string ShowWinner(string headerTxt, Color winnerColor)
        {
            // Get the winner, color the winning cells the actual winner's color
            foreach (int winningCell in stateConditionsManager.winningCells)
                btnCells[winningCell].ForeColor = winnerColor;

            if (winnerColor == Color.Green)
            {
                xWins++;
                UpdateWinLabels();
            }
            else
            {
                yWins++;
                UpdateWinLabels();
            }

            return headerTxt;
        }
        private void UpdateWinLabels()
        {
            PlayerOneScore.Text = xWins.ToString();
            PlayerTwoScore.Text = yWins.ToString();
        }

        private void ResetBoard()
        {
            foreach (var btnCell in btnCells)
            {
                btnCell.Text = "";
                btnCell.ForeColor = Color.Black;
                btnCell.Enabled = true;
            }
            stateConditionsManager.hasWinner = false;
            stateTurnManager.ResetTurn();
            stateTurnQueue.ResetTurnQueue();
            InitializeFirstTurn();
        }

        private void btnCell1_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[0]);
        }

        private void btnCell2_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[1]);
        }

        private void btnCell3_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[2]);
        }

        private void btnCell4_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[3]);
        }

        private void btnCell5_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[4]);
        }

        private void btnCell6_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[5]);
        }

        private void btnCell7_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[6]);
        }

        private void btnCell8_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[7]);
        }

        private void btnCell9_Click(object sender, EventArgs e)
        {
            txtHeader.Text = ProcessTurn(btnCells[8]);
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            ResetBoard();
        }
        private void PlayerOneScore_TextChanged(object sender, EventArgs e)
        {
            UpdateWinLabels();
        }
        private void PlayerTwoScore_TextChanged(object sender, EventArgs e)
        {
            UpdateWinLabels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerOneScore.Clear();
            PlayerTwoScore.Clear();
        }

    }
}
