using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchItemBack : ICommand
    {
        private Game1 myGame;

        public CommandSwitchItemBack(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IItem item = myGame.items[myGame.items.Count - 1];
            myGame.items.RemoveAt(myGame.items.Count - 1);
            myGame.items.Insert(0, item);
        }
    }
}
