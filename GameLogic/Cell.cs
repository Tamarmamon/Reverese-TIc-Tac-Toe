using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameLogic
{
    public class Cell
    {
        private ePlayersSign m_GameCellValue;

        public event EventHandler CellValue;

        public ePlayersSign GameCellValue
        {
            get { return m_GameCellValue; }
            set { m_GameCellValue = value; }
        }
       
        public Cell(ePlayersSign i_EntrySign)
        {
            m_GameCellValue = i_EntrySign;
        }

        public void OnCellValue()
        {
            if (CellValue != null)
            {
                CellValue.Invoke(this, null);
            }

        }
    }
}
