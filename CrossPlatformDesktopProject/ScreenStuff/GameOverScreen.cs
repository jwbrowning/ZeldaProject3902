using CrossPlatformDesktopProject.ScreenStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class GameOverScreen : IScreen
    {
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private Game1 game;

        public GameOverScreen(Game1 game, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(game.font, "GAME OVER", new Vector2(graphics.PreferredBackBufferWidth/3f,graphics.PreferredBackBufferHeight/3f), Color.White);
            spriteBatch.End();
        }
    }
}
