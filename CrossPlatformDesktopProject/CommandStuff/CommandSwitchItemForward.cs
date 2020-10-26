﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchItemForward : ICommand
    {
        private Game1 myGame;

        public CommandSwitchItemForward(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            IItem item = myGame.currentRoom.Items[0];
            myGame.currentRoom.Items.RemoveAt(0);
            myGame.currentRoom.Items.Add(item);
        }
    }
}
