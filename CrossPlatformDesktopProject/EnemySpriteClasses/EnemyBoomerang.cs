﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.PlayerStuff;

namespace Sprint0
{
    class EnemyBoomerang : IEnemy
    {
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private Boolean drawBoomerang = true;

        private int spritePositionX = 500;
        private int spritePositionY = 300;
        int directionCode = 0; //determines which direction sprite should move. Ranges from 0-3.
        private IPlayer player;

        private Vector2 size = new Vector2(30, 60);
        public Vector2 Position
        {
            get
            {
                return new Vector2(spritePositionX + size.X / 2f, spritePositionY + size.Y / 2f);
            }
            set
            {
                spritePositionX = (int)(value.X - size.X / 2f);
                spritePositionY = (int)(value.Y - size.Y / 2f);
            }
        }


        public EnemyBoomerang(IPlayer player, Vector2 position, int directionCode)
        {
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            CollisionHandler = new EnemyCollisionHandler(this, size.X, size.Y, 0, 0);
            Position = position;
            this.directionCode = directionCode;
        }

        public void Update()
        {

            animationFrame++;
            movementFrame++;

            if (animationFrame == 20)
                animationFrame = 1;

            if (movementFrame > 100)
                drawBoomerang = false;

            if (directionCode == 0)
            {
                if (movementFrame < 50)
                {
                    spritePositionY = spritePositionY - 5;
                }
                else if(movementFrame >= 50 && movementFrame <= 100)
                {
                    spritePositionY = spritePositionY + 5;
                }
            }
            if (directionCode == 1)
            {
                if (movementFrame < 50)
                {
                    spritePositionY = spritePositionY + 5;
                }
                else if (movementFrame >= 50 && movementFrame <= 100)
                {
                    spritePositionY = spritePositionY - 5;
                }
            }
            if (directionCode == 2)
            {
                if (movementFrame < 50)
                {
                    spritePositionX = spritePositionX - 5;
                }
                else if (movementFrame >= 50 && movementFrame <= 100)
                {
                    spritePositionX = spritePositionX + 5;
                }
            }
            if (directionCode == 3)
            {
                if (movementFrame < 50)
                {
                    spritePositionX = spritePositionX + 5;
                }
                else if (movementFrame >= 50 && movementFrame <= 100)
                {
                    spritePositionX = spritePositionX - 5;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if(drawBoomerang == true)
            {
                if (animationFrame >= 1 && animationFrame < 7)
                {
                    sourceRectangle = new Rectangle(290, 11, 8, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 30, 60);
                }
                else if (animationFrame >= 7 && animationFrame < 14)
                {
                    sourceRectangle = new Rectangle(299, 11, 8, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 30, 60);
                }
                else if (animationFrame >= 14)
                {
                    sourceRectangle = new Rectangle(308, 11, 8, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 30, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(308, 11, 8, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 30, 60);
                }

                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
    }
}
