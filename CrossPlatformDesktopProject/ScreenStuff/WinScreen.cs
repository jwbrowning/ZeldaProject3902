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
    class WinScreen : IScreen
    {
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private Game1 game;

        public WinScreen(Game1 game, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.DarkGoldenrod);
            spriteBatch.Begin();
            spriteBatch.DrawString(game.font, "YOU WIN", new Vector2(graphics.PreferredBackBufferWidth / 3f, graphics.PreferredBackBufferHeight / 3f), Color.White);
            spriteBatch.End();
        }
    }
}
