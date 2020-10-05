using CrossPlatformDesktopProject.EnemySpriteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchNPCForward : ICommand
    {
        private Game1 myGame;

        public CommandSwitchNPCForward(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            INPC npc = myGame.npcs[0];
            myGame.npcs.RemoveAt(0);
            myGame.npcs.Add(npc);
        }
    }
}
