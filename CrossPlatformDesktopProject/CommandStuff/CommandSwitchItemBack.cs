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
            IItem item = myGame.currentRoom.Items[myGame.currentRoom.Items.Count - 1];
            myGame.currentRoom.Items.RemoveAt(myGame.currentRoom.Items.Count - 1);
            myGame.currentRoom.Items.Insert(0, item);
        }
    }
}
