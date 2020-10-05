using CrossPlatformDesktopProject.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchBlockForward : ICommand
    {
        private Game1 myGame;

        public CommandSwitchBlockForward(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IBlock block = myGame.blocks[0];
            myGame.blocks.RemoveAt(0);
            myGame.blocks.Add(block);
        }
    }
}
