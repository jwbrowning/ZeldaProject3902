
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandLoadGame : ICommand
    {
        private Game1 myGame;

        public CommandLoadGame(Game1 game)
        {
            myGame = game;
        }
        void ICommand.Execute()
        {
            myGame.LoadGame();
        }
    }
}
