using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class GameRunner
    {
        public enum eActionStatus
        {
            Invalid,
            Valid,
            EndGameDraw,
            EndGameDefeat,
            Exit
        }

        private Board m_Board;
        private Player[] m_Players = new Player[2];
        private Player m_CurrentPlayer;
        private Player m_BenchedPlayer;
        public event EventHandler FinishTurn;
        public event EventHandler FinishGame;

        public Board Board => m_Board;

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }
        public Player BenchedPlayer
        {
            get { return m_BenchedPlayer; }
            set { m_BenchedPlayer = value; }
        }

        public GameRunner(int i_SizeOfBoard, Player[] i_Players)
        {
            m_Board = new Board(i_SizeOfBoard);
            m_Players = i_Players;
            m_CurrentPlayer = m_Players[0];
            m_BenchedPlayer = m_Players[1];
        }

        public void ChangePlayer()
        {
            Player placeHolder = m_CurrentPlayer;
            m_CurrentPlayer = m_BenchedPlayer;
            m_BenchedPlayer = placeHolder;
            placeHolder = null;
        }

        public eActionStatus GameRound(int i_RowPosition, int i_ColPosition)
        {
            eActionStatus playerActionStatus;
            if (!Board.CheckIfCellAvailable(i_RowPosition, i_ColPosition))
            {
                playerActionStatus = eActionStatus.Invalid;
            }
            else
            {
                playerActionStatus = eActionStatus.Valid;
                placeValueOnBoard(i_RowPosition, i_ColPosition);

                if (Board.CheckSequence(i_RowPosition, i_ColPosition))
                {
                    playerActionStatus = eActionStatus.EndGameDefeat;
                }
                else if (Board.m_UsedCells == Board.m_Size * Board.m_Size)
                {
                    playerActionStatus = eActionStatus.EndGameDraw;
                }
            }

            return playerActionStatus;
        }

        private void placeValueOnBoard(int i_RowPosition, int i_ColPostion)
        {
            Board.m_Board[i_RowPosition, i_ColPostion].GameCellValue = m_CurrentPlayer.m_PlayerSign;
            Board.m_Board[i_RowPosition, i_ColPostion].OnCellValue();
            Board.m_UsedCells++;
        }

        public void OnFinishTurn()
        {
            if (FinishTurn != null)
            {
                FinishTurn.Invoke(this, null);
            }
        }

        public void OnFinishGame()
        {
            if (FinishGame != null)
            {
                FinishGame.Invoke(this, null);
            }
        }

        public void RestartGame()
        {
            m_Board.ClearBoard();
        }

        public void AddScoresToPlayer()
        {
            BenchedPlayer.m_Score++;
        }

    }
}
