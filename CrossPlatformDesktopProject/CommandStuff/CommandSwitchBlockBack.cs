using CrossPlatformDesktopProject.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchBlockBack : ICommand
    {
        private Game1 myGame;

        public CommandSwitchBlockBack(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IBlock block = myGame.blocks[myGame.blocks.Count - 1];
            myGame.blocks.RemoveAt(myGame.blocks.Count - 1);
            myGame.blocks.Insert(0, block);
        }
    }
}
