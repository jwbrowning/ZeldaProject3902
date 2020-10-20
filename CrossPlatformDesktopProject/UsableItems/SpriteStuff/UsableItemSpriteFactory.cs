using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableItemSpriteFactory
    {
        private Texture2D bomb, explosion;
        private Texture2D leftArrow, upArrow, rightArrow, downArrow;
        private Texture2D boomerang;
        private static UsableItemSpriteFactory instance = new UsableItemSpriteFactory();

        public static UsableItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private UsableItemSpriteFactory() { }

        public void LoadAllTextures(ContentManager content)
        {
            bomb = content.Load<Texture2D>("UsableItems/bomb");
            explosion = content.Load<Texture2D>("UsableItems/bombExplosion");
            leftArrow = content.Load<Texture2D>("UsableItems/arrowleft");
            upArrow = content.Load<Texture2D>("UsableItems/arrowup");
            rightArrow = content.Load<Texture2D>("UsableItems/arrowright");
            downArrow = content.Load<Texture2D>("UsableItems/arrowdown");
            boomerang = content.Load<Texture2D>("UsableItems/boomerang");
        }

        public ISprite CreateBombSprite()
        {
            return new UsableItemSprite(bomb, 1, 1, 0, 1, 1);
        }

        public ISprite CreateExplosionSprite()
        {
            return new UsableItemSprite(explosion, 1, 4, 0, 4, 1);
        }

        public ISprite CreateLeftArrowSprite()
        {
            return new UsableItemSprite(leftArrow, 1, 1, 0, 1, 1);
        }

        public ISprite CreateUpArrowSprite()
        {
            return new UsableItemSprite(upArrow, 1, 1, 0, 1, 1);
        }

        public ISprite CreateRightArrowSprite()
        {
            return new UsableItemSprite(rightArrow, 1, 1, 0, 1, 1);
        }

        public ISprite CreateDownArrowSprite()
        {
            return new UsableItemSprite(downArrow, 1, 1, 0, 1, 1);
        }

        public ISprite CreateBoomerangSprite()
        {
            return new UsableItemSprite(boomerang, 1, 8, 0, 8, 2);
        }

    }
}
