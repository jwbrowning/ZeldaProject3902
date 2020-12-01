
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandSaveGame : ICommand
    {
        private Game1 myGame;

        public CommandSaveGame(Game1 game)
        {
            myGame = game;
        }
        void ICommand.Execute()
        {
            myGame.SaveGame();
        }
    }
}
