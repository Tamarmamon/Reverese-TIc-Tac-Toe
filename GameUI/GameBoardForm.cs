using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace GameUI
{
    public class GameBoardForm : Form
    {
        private GameRunner m_GameRunner;
        private List<GameButton> m_Buttons = new List<GameButton>();
        private int m_BoardSize;
        private Label Player1Score;
        private Label Player2Score;
        private Panel PanelGameButtons;
        private Player[] m_Players = new Player[2];
        
        public GameBoardForm()
        {
            InitializeComponent();
            InitializeGameSetting();
            m_GameRunner = new GameRunner(m_BoardSize, m_Players);
            InitializeGameBoard();
        }

        public void InitializeGameBoard()
        {
            int marginBetweenButtons = 10;
            int buttonWidth = 60;
            int buttonHeight = 60;
            int boardSize = 0;
            Size buttonSize = new Size(buttonWidth, buttonHeight);
            Point buttonLocation = new Point(marginBetweenButtons, marginBetweenButtons);
            for (int i = 1; i <= m_BoardSize; i++)
            {
                for (int j = 1; j <= m_BoardSize; j++)
                {
                    GameButton gameButton = new GameButton(i, j, buttonSize, marginBetweenButtons, buttonLocation);
                    gameButton.Click += new EventHandler(this.button_Click);
                    m_GameRunner.Board.m_Board[i-1, j-1].CellValue += new EventHandler(gameButton.Board_PlacePlayerSign);
                    buttonLocation.X += buttonWidth + marginBetweenButtons;
                    m_Buttons.Add(gameButton);
                    PanelGameButtons.Controls.Add(gameButton);
                }

                buttonLocation.X = marginBetweenButtons;
                buttonLocation.Y += buttonHeight + marginBetweenButtons;
            }

            boardSize = buttonLocation.Y;
            this.ClientSize = new Size(boardSize, boardSize);

            this.Text = "Reverse Tic Tac Toe";
            Player1Score.Text = string.Format("{0}: {1}", m_Players[0].m_PlayerName, m_Players[0].m_Score);
            Player2Score.Text = string.Format("{0}: {1}", m_Players[1].m_PlayerName, m_Players[1].m_Score);
            int margin = (Player1Score.Width + Player2Score.Width + 10) / 2;
            Player1Score.Left = (this.ClientSize.Width / 2) - margin;
            Player2Score.Left = Player2Score.Right + 10;
            Player1Score.Font = new Font(Player1Score.Font, FontStyle.Bold);
            m_GameRunner.FinishTurn += m_GameRunner_FinishTurn;
            m_GameRunner.FinishGame += m_GameRunner_FinishGame;
        }

        public void InitializeGameSetting()
        {
            int numberOfPlayers = 0;
            GameSettingForm gameSettingForm = new GameSettingForm();
            gameSettingForm.ShowDialog();
            if (gameSettingForm.DialogResult == DialogResult.OK)
            {
                string player1Name = gameSettingForm.player1Name.Text;
                bool player1IsComputer = false;
                m_Players[numberOfPlayers++] = new Player(0, ePlayersSign.X, player1Name, player1IsComputer);

                string player2Name = gameSettingForm.player2Name.Text;
                

                bool isPlayer2Computer = !gameSettingForm.player2Choice.Checked;
                m_Players[numberOfPlayers++] = new Player(0, ePlayersSign.O, player2Name, isPlayer2Computer);

                m_BoardSize = (int)gameSettingForm.numericUpDownRows.Value;
            }
            else if (gameSettingForm.DialogResult == DialogResult.Cancel)
            {
                this.Dispose();
                Environment.Exit(1);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            (sender as GameButton).Enabled = false;
            playRound(sender);
        }

        private void playRound(object sender)
        {
            GameButton button = sender as GameButton;
            GameRunner.eActionStatus roundStatus = m_GameRunner.GameRound(button.RowPosition - 1, button.ColPosition - 1);
            handleRoundResults(roundStatus);
        }

        private void handleRoundResults(GameRunner.eActionStatus i_RoundStatus)
        {
            if (i_RoundStatus == GameRunner.eActionStatus.Valid)
            {
                m_GameRunner.OnFinishTurn();
            }
            else
            {
                string titleMsg;
                string bodyMsg;
                if (i_RoundStatus == GameRunner.eActionStatus.EndGameDraw)
                {
                    titleMsg = string.Format("A Tie!");
                    bodyMsg = string.Format("Tie!{0}Would you like to play another round?", Environment.NewLine);
                }
                else
                {
                    titleMsg = string.Format("A Win!");
                    bodyMsg = string.Format("The winner is {0}!{1}Would you like to play another round?", m_GameRunner.BenchedPlayer.m_PlayerName, Environment.NewLine);
                    m_GameRunner.AddScoresToPlayer();
                    updateScoresLabels();
                }

                DialogResult dialogResult = MessageBox.Show(bodyMsg, titleMsg, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                m_GameRunner.OnFinishGame();
            }
        }
        private void m_GameRunner_FinishTurn(object sender, EventArgs e)
        {
            m_GameRunner.ChangePlayer();
            updateCurrentPlayerLabel();
            if (m_GameRunner.CurrentPlayer.m_IsComputer)
            {
                ComputerPlay();
            }
        }

        private void m_GameRunner_FinishGame(object sender, EventArgs e)
        {
            restartGame();
            m_GameRunner_FinishTurn(sender, e);
        }

        private void ComputerPlay()
        {
           
            System.Threading.Thread.Sleep(800);
            pressButtonAsComputer();
                       
        }
        
        private void pressButtonAsComputer()
        {
            List<GameButton> availableButtons = new List<GameButton>();
            foreach (GameButton button in m_Buttons)
            {
                if (button.Text == string.Empty)
                {
                    availableButtons.Add(button);
                }
            }
            Random selection = new Random();
            int index = selection.Next(0, availableButtons.Count - 1);
            playRound(availableButtons[index]);
        }

        private void updateCurrentPlayerLabel()
        {
            if (m_GameRunner.CurrentPlayer == m_Players[0])
            {
                Player1Score.Font = new Font(Player1Score.Font, FontStyle.Bold);
                Player2Score.Font = new Font(Player2Score.Font, FontStyle.Regular);
            }
            else
            {
                Player2Score.Font = new Font(Player2Score.Font, FontStyle.Bold);
                Player1Score.Font = new Font(Player1Score.Font, FontStyle.Regular);
            }
        }

        private void restartGame()
        {
            foreach (GameButton button in m_Buttons)
            {
                button.Text = null;
                button.Enabled = true;
            }

            m_GameRunner.RestartGame();
        }
        private void updateScoresLabels()
        {
            Player1Score.Text = string.Format("{0}: {1}", m_Players[0].m_PlayerName, m_Players[0].m_Score);
            Player2Score.Text = string.Format("{0}: {1}", m_Players[1].m_PlayerName, m_Players[1].m_Score);
        }

        private void InitializeComponent()
        {
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.PanelGameButtons = new System.Windows.Forms.Panel();
            this.PanelGameButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // Player1Score
            // 
            this.Player1Score.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player1Score.Location = new System.Drawing.Point(100, 496);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(72, 20);
            this.Player1Score.TabIndex = 0;
            this.Player1Score.Text = "Player1";
            // 
            // Player2Score
            // 
            this.Player2Score.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Player2Score.Location = new System.Drawing.Point(220, 496);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(77, 20);
            this.Player2Score.TabIndex = 1;
            this.Player2Score.Text = "Player2";
            // 
            // panelGameButtons
            // 
            this.PanelGameButtons.AutoSize = true;
            this.PanelGameButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PanelGameButtons.Controls.Add(this.Player1Score);
            this.PanelGameButtons.Controls.Add(this.Player2Score);
            this.PanelGameButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelGameButtons.Location = new System.Drawing.Point(0, 0);
            this.PanelGameButtons.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PanelGameButtons.Name = "panelGameButtons";
            this.PanelGameButtons.Padding = new System.Windows.Forms.Padding(0, 8, 0, 50);
            this.PanelGameButtons.Size = new System.Drawing.Size(582, 525);
            this.PanelGameButtons.TabIndex = 2;
            this.PanelGameButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGameButtons_Paint);
            // 
            // GameBoardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(582, 525);
            this.Controls.Add(this.PanelGameButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameBoardForm";
            this.Text = "TicTacToe";
            this.Load += new System.EventHandler(this.GameBoardForm_Load);
            this.PanelGameButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void panelGameButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GameBoardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
