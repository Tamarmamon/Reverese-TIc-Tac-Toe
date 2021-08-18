using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Player
    {
        public int m_Score = 0;
        public ePlayersSign m_PlayerSign;
        public Random m_RandomMove = new Random();
        public string m_PlayerName;
        public bool m_IsComputer;

        public Player(int i_Score, ePlayersSign i_playerSign, string i_PlayerName, bool i_IsComputer)
        {
            m_Score = i_Score;
            m_PlayerSign = i_playerSign;
            m_PlayerName = i_PlayerName;
            m_IsComputer = i_IsComputer;
        }

    }
}
