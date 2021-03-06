﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableItemSpriteFactory
    {
        private Texture2D bomb, explosion;
        private Texture2D leftArrow, upArrow, rightArrow, downArrow;
        private Texture2D boomerang;
        private Texture2D leftBeam, upBeam, rightBeam, downBeam;
        private Texture2D topLeft, topRight, bottomLeft, bottomRight;
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
            leftBeam = content.Load<Texture2D>("UsableItems/SwordBeamLeft");
            upBeam = content.Load<Texture2D>("UsableItems/SwordBeamUp");
            rightBeam = content.Load<Texture2D>("UsableItems/SwordBeamRight");
            downBeam = content.Load<Texture2D>("UsableItems/SwordBeamDown");
            topLeft = content.Load<Texture2D>("UsableItems/TopLeftEffect");
            topRight = content.Load<Texture2D>("UsableItems/TopRightEffect");
            bottomLeft = content.Load<Texture2D>("UsableItems/BottomLeftEffect");
            bottomRight = content.Load<Texture2D>("UsableItems/BottomRightEffect");
        }

        public ISprite CreateTopLeftEffectSprite(Color overlay)
        {
            return new UsableItemSprite(topLeft, 1, 1, 0, 1, 2, overlay);
        }

        public ISprite CreateTopRightEffectSprite(Color overlay)
        {
            return new UsableItemSprite(topRight, 1, 1, 0, 1, 2, overlay);
        }

        public ISprite CreateBottomLeftEffectSprite(Color overlay)
        {
            return new UsableItemSprite(bottomLeft, 1, 1, 0, 1, 2, overlay);
        }

        public ISprite CreateBottomRightEffectSprite(Color overlay)
        {
            return new UsableItemSprite(bottomRight, 1, 1, 0, 1, 2, overlay);
        }

        public ISprite CreateSwordSprite()
        {
            return new UsableItemSprite(upBeam, 1, 4, 0, 1, 2);
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

        public ISprite CreateLeftSwordBeamSprite()
        {
            return new UsableItemSprite(leftBeam, 4, 1, 0, 4, 2);
        }

        public ISprite CreateUpSwordBeamSprite()
        {
            return new UsableItemSprite(upBeam, 1, 4, 0, 4, 2);
        }

        public ISprite CreateRightSwordBeamSprite()
        {
            return new UsableItemSprite(rightBeam, 4, 1, 0, 4, 2);
        }

        public ISprite CreateDownSwordBeamSprite()
        {
            return new UsableItemSprite(downBeam, 1, 4, 0, 4, 2);
        }

    }
}
