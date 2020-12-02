using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;

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
            game.currentRoom.DrawEnemies(spriteBatch);
            game.currentRoom.DrawItems(spriteBatch);
            game.currentRoom.DrawDoors(spriteBatch);
            game.player.Draw(spriteBatch, game.currentRoom.Position);
            game.lightingManager.Draw(spriteBatch);
            game.hud.Draw(spriteBatch);
        }
    }
}
