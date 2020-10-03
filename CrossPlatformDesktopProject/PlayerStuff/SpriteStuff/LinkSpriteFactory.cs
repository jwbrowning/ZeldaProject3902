using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.SpriteStuff
{
    class LinkSpriteFactory
    {
        private Texture2D leftMovingSheet, upMovingSheet, rightMovingSheet, downMovingSheet;
        private Texture2D leftSwordSheet, upSwordSheet, rightSwordSheet, downSwordSheet;
        private Texture2D useItemSheet;
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
            leftMovingSheet = content.Load<Texture2D>("LeftMovingLink");
            upMovingSheet = content.Load<Texture2D>("UpMovingLink");
            rightMovingSheet = content.Load<Texture2D>("RightMovingLink");
            downMovingSheet = content.Load<Texture2D>("DownMovingLink");
            leftSwordSheet = content.Load<Texture2D>("LeftSwordLink");
            upSwordSheet = content.Load<Texture2D>("UpSwordLink");
            rightSwordSheet = content.Load<Texture2D>("RightSwordLink");
            downSwordSheet = content.Load<Texture2D>("DownSwordLink");
            useItemSheet = content.Load<Texture2D>("UseItemLink");
        }

        public ISprite CreateLeftMovingLinkSprite()
        {
            return new LinkSprite(leftMovingSheet, 1, 2, 0, 2);
        }

        public ISprite CreateUpMovingLinkSprite()
        {
            return new LinkSprite(upMovingSheet, 1, 2, 0, 2);
        }

        public ISprite CreateRightMovingLinkSprite()
        {
            return new LinkSprite(rightMovingSheet, 1, 2, 0, 2);
        }

        public ISprite CreateDownMovingLinkSprite()
        {
            return new LinkSprite(downMovingSheet, 1, 2, 0, 2);
        }

        public ISprite CreateLeftStillLinkSprite()
        {
            return new LinkSprite(leftMovingSheet, 1, 2, 1, 1);
        }

        public ISprite CreateUpStillLinkSprite()
        {
            return new LinkSprite(upMovingSheet, 1, 2, 0, 1);
        }

        public ISprite CreateRightStillLinkSprite()
        {
            return new LinkSprite(rightMovingSheet, 1, 2, 0, 1);
        }

        public ISprite CreateDownStillLinkSprite()
        {
            return new LinkSprite(downMovingSheet, 1, 2, 0, 1);
        }

        public ISprite CreateLeftSwordLinkSprite()
        {
            return new LinkSprite(leftSwordSheet, 1, 4, 0, 4);
        }

        public ISprite CreateUpSwordLinkSprite()
        {
            return new LinkSprite(upSwordSheet, 1, 4, 0, 4);
        }

        public ISprite CreateRightSwordLinkSprite()
        {
            return new LinkSprite(rightSwordSheet, 1, 4, 0, 4);
        }

        public ISprite CreateDownSwordLinkSprite()
        {
            return new LinkSprite(downSwordSheet, 1, 4, 0, 4);
        }

        public ISprite CreateLeftUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 3, 1);
        }

        public ISprite CreateUpUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 2, 1);
        }

        public ISprite CreateRightUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 1, 1);
        }

        public ISprite CreateDownUseItemLinkSprite()
        {
            return new LinkSprite(useItemSheet, 1, 4, 0, 1);
        }

    }
}
