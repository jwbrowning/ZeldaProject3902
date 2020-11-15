﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class BlockSpriteFactory
    {

        public Texture2D environment;
        public Texture2D water;
        private static BlockSpriteFactory instance = new BlockSpriteFactory();


        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        public BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            environment = content.Load<Texture2D>("environment");
            water = content.Load<Texture2D>("water");
        }
    }
}
