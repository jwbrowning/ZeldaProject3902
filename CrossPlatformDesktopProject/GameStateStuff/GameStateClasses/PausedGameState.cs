using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.GameStateStuff.GameStateClasses
{
    class PausedGameState : IGameState
    {
        private Game1 game;
        private List<IController> controllers;

        public PausedGameState(Game1 game)
        {
            this.game = game;
            controllers = new List<IController>
            {
                new PausedKeyboardController(game)
            };
        }

        public void Update()
        {
            foreach (IController currentController in controllers)
            {
                currentController.Update();
            }
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
            spriteBatch.Begin();
            spriteBatch.Draw(game.rect, new Rectangle(0, 0, 2000, 2000), new Color(0, 0, 0, .5f));
            spriteBatch.DrawString(game.font, "PAUSED", new Vector2(480, 440), Color.White);
            spriteBatch.End();
        }
    }
}
