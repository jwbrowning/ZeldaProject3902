﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSwitchNPC : ICommand
    {
        private Game1 myGame;

        public CommandSwitchNPC(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //to be implimented
        }
    }
}