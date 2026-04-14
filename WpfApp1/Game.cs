using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Game
    {
        public char[,] Board = new char[3, 3];
        public char TekushijPlayer = 'X';

        public bool Chod(int row , int column)
        {
            if (Board[row, column] == '\0')
            {
                Board[row, column] = TekushijPlayer;
                return true;
            }
            return false;
        }
        public void SwitchPlayer()
        {
            TekushijPlayer = TekushijPlayer == 'X' ? 'O' : 'X';
        }
        public bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] != '\0' &&
                    Board[i, 0] == Board[i, 1] &&
                    Board[i, 1] == Board[i, 2])
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (Board[0, i] != '\0' &&
                    Board[0, i] == Board[1, i] &&
                    Board[1, i] == Board[2, i])
                    return true;
            }

            if (Board[0, 0] != '\0' &&
                Board[0, 0] == Board[1, 1] &&
                Board[1, 1] == Board[2, 2])
                return true;

            if (Board[0, 2] != '\0' &&
                Board[0, 2] == Board[1, 1] &&
                Board[1, 1] == Board[2, 0])
                return true;

            return false;
        }
    }
}
