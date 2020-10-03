using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandSword : ICommand
    {
        private Game1 myGame;

        public CommandSword (Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //to be implimented
        }
    }
}
