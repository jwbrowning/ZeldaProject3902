using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandPause : ICommand
    {
        private Game1 myGame;

        public CommandPause(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Pause();
        }
    }
}

