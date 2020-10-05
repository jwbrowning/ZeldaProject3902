using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandReset : ICommand
    {
        private Game1 myGame;
        public CommandReset(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Reinitialize();

        }
    }
}
