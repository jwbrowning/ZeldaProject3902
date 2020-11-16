using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class WallSpriteFactory
    {

        public Texture2D environment;
        private static WallSpriteFactory instance = new WallSpriteFactory();


        public static WallSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        public WallSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            environment = content.Load<Texture2D>("environment");
        }
    }
}
