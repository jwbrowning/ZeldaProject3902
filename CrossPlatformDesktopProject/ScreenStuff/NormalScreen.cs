﻿using CrossPlatformDesktopProject.ScreenStuff;
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
    class NormalScreen : IScreen
    {
        private GraphicsDevice graphicsDevice;
        private GraphicsDeviceManager graphics;
        private Game1 game;

        public NormalScreen(Game1 game, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.graphics = graphics;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            graphicsDevice.Clear(Color.Black);
        }
    }
}
