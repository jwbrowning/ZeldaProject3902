using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.PlayerStuff.SpriteStuff
{
    class LinkSpriteFactory
    {
        private Texture2D leftMovingSheet, upMovingSheet, rightMovingSheet, downMovingSheet;
        private Texture2D leftSwordSheet, upSwordSheet, rightSwordSheet, downSwordSheet;
        private Texture2D useItemSheet;
        public IPlayer player;
        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            leftMovingSheet = content.Load<Texture2D>("LinkSprites/LeftMoving");
            upMovingSheet = content.Load<Texture2D>("LinkSprites/UpMoving");
            rightMovingSheet = content.Load<Texture2D>("LinkSprites/RightMoving");
            downMovingSheet = content.Load<Texture2D>("LinkSprites/DownMoving");
            leftSwordSheet = content.Load<Texture2D>("LinkSprites/LeftSword");
            upSwordSheet = content.Load<Texture2D>("LinkSprites/UpSword");
            rightSwordSheet = content.Load<Texture2D>("LinkSprites/RightSword");
            downSwordSheet = content.Load<Texture2D>("LinkSprites/DownSword");
            useItemSheet = content.Load<Texture2D>("LinkSprites/UseItemSprites");
        }

        public ISprite CreateLeftMovingLinkSprite()
        {
            return new LinkSprite(leftMovingSheet, 1, 2, 0, 2, true, 1, player);
        }

        public ISprite CreateUpMovingLinkSprite()
        {
            return new LinkSprite(upMovingSheet, 1, 2, 0, 2, true, 1, player);
        }

        public ISprite CreateRightMovingLinkSprite()
        {
            return new LinkSprite(rightMovingSheet, 1, 2, 0, 2, true, 1, player);
        }

        public ISprite CreateDownMovingLinkSprite()
        {
            return new LinkSprite(downMovingSheet, 1, 2, 0, 2, true, 1, player);
        }

        public ISprite CreateLeftStillLinkSprite()
        {
            return new LinkSprite(leftMovingSheet, 1, 2, 1, 1, true, 1, player);
        }

        public ISprite CreateUpStillLinkSprite()
        {
            return new LinkSprite(upMovingSheet, 1, 2, 1, 1, true, 1, player);
        }

        public ISprite CreateRightStillLinkSprite()
        {
            return new LinkSprite(rightMovingSheet, 1, 2, 1, 1, true, 1, player);
        }

        public ISprite CreateDownStillLinkSprite()
        {
            return new LinkSprite(downMovingSheet, 1, 2, 1, 1, true, 1, player);
        }

        public ISprite CreateLeftSwordLinkSprite()
        {
            return new LinkSprite(leftSwordSheet, 4, 1, 0, 4, false, 2, player);
        }

        public ISprite CreateUpSwordLinkSprite()
        {
            return new LinkSprite(upSwordSheet, 1, 4, 0, 4, false, 2, player);
        }

        public ISprite CreateRightSwordLinkSprite()
        {
            return new LinkSprite(rightSwordSheet, 4, 1, 0, 4, false, 2, player);
        }

        public ISprite CreateDownSwordLinkSprite()
        {
            return new LinkSprite(downSwordSheet, 1, 4, 0, 4, false, 2, player);
        }

        public ISprite CreateLeftUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 3, 1, false, 1, player);
        }

        public ISprite CreateUpUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 2, 1, false, 1, player);
        }

        public ISprite CreateRightUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 1, 1, false, 1, player);
        }

        public ISprite CreateDownUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 0, 1, false, 1, player);
        }

    }
}
