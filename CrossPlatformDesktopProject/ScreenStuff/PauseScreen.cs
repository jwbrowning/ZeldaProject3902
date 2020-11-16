﻿using CrossPlatformDesktopProject.ScreenStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class PauseScreen : IScreen
    {
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private Game1 game;

        public PauseScreen(Game1 game, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.DarkMagenta);
            spriteBatch.Begin();
            spriteBatch.DrawString(game.font, "PAUSED", new Vector2(graphics.PreferredBackBufferWidth / 3f, graphics.PreferredBackBufferHeight / 3f), Color.White);
            spriteBatch.End();
        }
    }
}
