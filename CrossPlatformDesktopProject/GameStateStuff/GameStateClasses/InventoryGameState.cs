using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class InventoryGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public InventoryGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new InventoryKeyboardController(game)
            };
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
            game.hud.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            game.currentRoom.DrawBackground(spriteBatch);
            game.currentRoom.DrawBlocks(spriteBatch);
            game.currentRoom.DrawNPCS(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.player.Draw(spriteBatch);
            game.hud.Draw(spriteBatch);
        }
    }
}
