using CrossPlatformDesktopProject.EnemySpriteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchNPCBack : ICommand
    {
        private Game1 myGame;

        public CommandSwitchNPCBack(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            INPC npc = myGame.npcs[myGame.npcs.Count-1];
            myGame.npcs.RemoveAt(myGame.npcs.Count - 1);
            myGame.npcs.Insert(0,npc);
        }
    }
}
