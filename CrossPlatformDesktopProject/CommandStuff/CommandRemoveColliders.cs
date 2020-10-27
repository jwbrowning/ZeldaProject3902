using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandRemoveColliders : ICommand
    {
        private Game1 myGame;

        public CommandRemoveColliders(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.showCollisions = false;
        }
    }
}
