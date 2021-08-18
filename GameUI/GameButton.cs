using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameUI
{
    public class GameButton: Button
    {
        private int m_ColPosition;
        private int m_RowPosition;

        public GameButton(int i_RowPosition, int i_ColPosition, Size i_Size, int i_Margin, Point i_Location) : base()
        {
            m_ColPosition = i_ColPosition;
            m_RowPosition = i_RowPosition;
            Size = i_Size;
            Margin = new Padding(i_Margin);
            Location = i_Location;
            Visible = true;
            Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        public int ColPosition
        {
            get{ return m_ColPosition;}
            set{ ColPosition = m_ColPosition;}
        }

        public int RowPosition
        {
            get { return m_RowPosition;}
            set { RowPosition = m_RowPosition;}
        }

        public void Board_PlacePlayerSign(object sender, EventArgs e)
        {
            GameLogic.Cell currentGameCell = sender as GameLogic.Cell;
            if (currentGameCell.GameCellValue == GameLogic.ePlayersSign.X)
            {
                this.Text = GameLogic.ePlayersSign.X.ToString();
            }
            else if (currentGameCell.GameCellValue == GameLogic.ePlayersSign.O)
            {
                this.Text = GameLogic.ePlayersSign.O.ToString();
            }
        }
    }
}
