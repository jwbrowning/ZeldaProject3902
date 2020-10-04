using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CommandStuff
{
    class CommandReset : ICommand
    {
        private Game1 myGame;
        public CommandReset(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.player.Position = new Vector2(200,360);
            //mygame.itemthing.Position = new Vector2(600, 120);
            //mygame.itemthing.sprite set to first sprite
            //mygame.blockthing.Position = new Vector2(200, 120);
            //mygame.blockthing.sprite set to first sprite
            //mygame.enemything.Position = new Vector2(600, 360);
            //mygame.enemything.sprite set to first sprite

        }
    }
}
