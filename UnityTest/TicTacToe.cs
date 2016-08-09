using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest
{
    public class TicTacToe : IGame
    {
        private string _status;

        public TicTacToe()
        {
            Name = "Tic Tac Toe";
            CurrentPlayers = 0;
            MinPlayers = 2;
            MaxPlayers = 2;
            _status = "No active games";
        }

        #region IGame Members

        public string Name { get; set; }

        public int CurrentPlayers { get; set; }

        public int MinPlayers { get; set; }

        public int MaxPlayers { get; set; }

        public void addPlayer()
        {
            CurrentPlayers++;
        }

        public void removePlayer()
        {
            CurrentPlayers--;
        }

        public void play()
        {
            if ((CurrentPlayers > MaxPlayers) || (CurrentPlayers < MinPlayers))
                _status = string.Format("{0}: It's not possible to play with {1} players.", Name, CurrentPlayers);
            else
                _status = string.Format("{0}: Playing with {1} players.", Name, CurrentPlayers);
        }

        public string result()
        {
            return _status;
        }

        #endregion
    }
}
