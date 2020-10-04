﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class Dodongo
    {
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;


        public Dodongo(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {

            animationFrame++;
            movementFrame++;
            if (animationFrame == 20)
                animationFrame = 1;

            if (movementFrame == 400)
                movementFrame = 1;


            if (movementFrame <= 100)
            {
                spritePositionX = spritePositionX + 2;

            }
            else if (movementFrame > 100 && movementFrame <= 200)
            {
                spritePositionY = spritePositionY - 2;
            }
            else if (movementFrame > 200 && movementFrame <= 300)
            {
                spritePositionX = spritePositionX - 2;
            }
            else if (movementFrame > 300)
            {
                spritePositionY = spritePositionY + 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (movementFrame <= 100)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(69, 58, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(102, 58, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(102, 58, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
            }
            else if (movementFrame > 100 && movementFrame <= 200)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(35, 58, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(347, 270, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(347, 270, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (movementFrame > 200 && movementFrame <= 300)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(264, 270, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(297, 270, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(297, 270, 32, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 120, 60);
                }
            }
            else if (movementFrame > 300)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(1, 58, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(381, 270, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(381, 270, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else
            {
                sourceRectangle = new Rectangle(381, 270, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

