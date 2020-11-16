using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class HUDSpriteFactory
    {
        private Texture2D headerBackground, inventoryBackground;
        private Texture2D heart, lostHeart, selector, compassMarker;
        private static HUDSpriteFactory instance = new HUDSpriteFactory();

        public static HUDSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            headerBackground = content.Load<Texture2D>("HUD/HUDHeaderInfo");
            inventoryBackground = content.Load<Texture2D>("HUD/HUDInventoryInfo");
            heart = content.Load<Texture2D>("HUD/HUDHeart");
            lostHeart = content.Load<Texture2D>("HUD/HUDLostHeart");
            selector = content.Load<Texture2D>("HUD/HUDSelector");
            compassMarker = content.Load<Texture2D>("HUD/CompassMarker");
        }

        public ISprite CreateHeaderBackground()
        {
            return new HUDSprite(headerBackground);
        }

        public ISprite CreateInventoryBackground()
        {
            return new HUDSprite(inventoryBackground);
        }

        public ISprite CreateHeart()
        {
            return new HUDSprite(heart);
        }

        public ISprite CreateLostHeart()
        {
            return new HUDSprite(lostHeart);
        }

        public ISprite CreateSelector()
        {
            return new HUDSprite(selector);
        }

        public ISprite CreateCompassMarker()
        {
            return new HUDSprite(compassMarker);
        }

    }
}
