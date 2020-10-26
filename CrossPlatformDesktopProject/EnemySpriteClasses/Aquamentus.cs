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
    class Aquamentus : IEnemy
    {
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private IPlayer player;
        private int animationFrame = 1;
        private int movementFrame = 1;

        private int spritePositionX = 600;
        private int spritePositionY = 200;


        private Vector2 size = new Vector2(75, 100);
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


        public Aquamentus(IPlayer player, Vector2 position)
        {
            Texture = NPCSpriteFactory.Instance.textureBosses;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(this, size.X, size.Y, 0, 0);
            this.player = player;
        }

        public void Update()
        {
            animationFrame++;
            movementFrame++;
            if (animationFrame == 40)
                animationFrame = 1;

            if (movementFrame == 400)
            {
                movementFrame = 1;
            }

            if (movementFrame <= 100)
            {
                spritePositionX = spritePositionX + 1;
            }
            else if (movementFrame > 100 && movementFrame <= 200)
            {
                spritePositionY = spritePositionY - 1;
            }
            else if (movementFrame > 200 && movementFrame <= 300)
            {
                spritePositionX = spritePositionX - 1;
            }
            else if (movementFrame > 300)
            {
                spritePositionY = spritePositionY + 1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 10)
            {
                sourceRectangle = new Rectangle(1, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame >= 10 && animationFrame < 20)
            {
                sourceRectangle = new Rectangle(26, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame >= 20 && animationFrame < 30)
            {
                sourceRectangle = new Rectangle(51, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame > 30)
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}