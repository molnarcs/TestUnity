using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityTest
{
    public class Table
    {
        private IGame game;

        public Table(IGame game)
        {
            this.game = game;
        }

        public string GameStatus()
        {
            return game.result();
        }

        public void AddPlayer()
        {
            game.addPlayer();
        }

        public void RemovePlayer()
        {
            game.removePlayer();
        }

        public void Play()
        {
            game.play();
        }
    }
}
