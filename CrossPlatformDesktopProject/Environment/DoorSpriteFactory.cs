using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class DoorSpriteFactory
    {

        public Texture2D environment;
        private static DoorSpriteFactory instance = new DoorSpriteFactory();


        public static DoorSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        public DoorSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            environment = content.Load<Texture2D>("environment");
        }
    }
}
