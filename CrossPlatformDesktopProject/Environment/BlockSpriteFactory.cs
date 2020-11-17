using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class BlockSpriteFactory
    {

        public Texture2D environment;
        public Texture2D water;
        public Texture2D RoomBowBackground;
        public Texture2D NormalBackground;
        public Texture2D BlackWithWallBackground;
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
            RoomBowBackground = content.Load<Texture2D>("RoomBowBackground");
            BlackWithWallBackground = content.Load<Texture2D>("BlackWithWallBackground");
        }
    }
}
