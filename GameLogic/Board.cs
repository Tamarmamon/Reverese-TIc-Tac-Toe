using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Board
    {
        public int m_Size;
        public Cell[,] m_Board;
        public int m_UsedCells;

        public Board(int i_Size)
        {
            m_Size = i_Size;
            m_Board = new Cell[i_Size, i_Size];
            InitializeBoard();
            m_UsedCells = 0;
        }

        public Cell GetCellSign(int i_Row, int i_Col)
        {
            return m_Board[i_Row, i_Col];
        }
        public void InitializeBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j] = new Cell(ePlayersSign.NoSign);
                }
            }
            m_UsedCells = 0;
        }

        //similair to the initailize board, but instead of creating new cell, we change the sign on the cell
        public void ClearBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    m_Board[i, j].GameCellValue = ePlayersSign.NoSign;
                }
            }
            m_UsedCells = 0;
        }

        public bool ValidateBoardSizeInput()
        {
            bool smallerThanThree = m_Size < 4;
            bool biggerThanNine = m_Size > 10;
            return smallerThanThree && biggerThanNine;
        }

        public bool CheckSequence(int i_RowPosition, int i_ColPosition)
        {
            // If we find a sequence for a player with that sign,
            // then the function returns true and the player with the second character wins and gets a point
            return isSerialRow(i_RowPosition,i_ColPosition) || isSerialCol(i_RowPosition, i_ColPosition) || isSerialDiagonal(i_RowPosition, i_ColPosition);

        }

        private bool isSerialRow(int i_RowPosition, int i_ColPosition)
        {
            bool isSerial = true;
            for (int j = 0; j < m_Size && isSerial == true; j++)
            {
                if (m_Board[i_RowPosition, j].GameCellValue != m_Board[i_RowPosition, i_ColPosition].GameCellValue)
                {
                    isSerial = false;
                }
            }

            return isSerial;
        }

        private bool isSerialCol(int i_RowPosition, int i_ColPosition)
        {
            bool isSerial = true;
            for (int i = 0; i < m_Size && isSerial == true; i++)
            {
                if (m_Board[i, i_ColPosition].GameCellValue != m_Board[i_RowPosition, i_ColPosition].GameCellValue)
                {
                    isSerial = false;
                }
            }

            return isSerial;
        }
        
        private bool isSerialDiagonal(int i_RowPosition, int i_ColPosition)
        {
            bool isSerialDiangonal = i_RowPosition == i_ColPosition;
            if (isSerialDiangonal)
            {
                for (int i = 0; i < m_Size && isSerialDiangonal == true; i++)
                {
                    if (m_Board[i, i].GameCellValue != m_Board[i_RowPosition, i_ColPosition].GameCellValue)
                    {
                        isSerialDiangonal = false;
                    }
                }
            }

            bool isSerialDiagonal2 = i_RowPosition + i_ColPosition == m_Size - 1;
            if (isSerialDiagonal2)
            {
                for (int i = 0; i < m_Size && isSerialDiagonal2 == true; i++)
                {
                    if (m_Board[i, m_Size - 1 - i].GameCellValue != m_Board[i_RowPosition, i_ColPosition].GameCellValue)
                    {
                        isSerialDiagonal2 = false;
                    }
                }
            }

            return isSerialDiangonal || isSerialDiagonal2;
        }

        public bool CheckIfCellAvailable(int i_rowPosition, int i_colPosition)
        {
            bool checkCell = m_Board[i_rowPosition, i_colPosition].GameCellValue == ePlayersSign.NoSign;
            return checkCell;
        }
        
    }
}
