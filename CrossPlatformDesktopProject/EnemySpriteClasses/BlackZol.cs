using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.EnemySpriteClasses;

namespace Sprint0
{
    class BlackZol : INPC
    {
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        public Vector2 Position
        {
            get
            {
                return new Vector2(spritePositionX, spritePositionY);
            }
            set
            {
                spritePositionX = (int)value.X;
                spritePositionY = (int)value.Y;
            }
        }


        public BlackZol(Texture2D texture)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 10)
            {
                sourceRectangle = new Rectangle(113, 11, 12, 16);
                destinationRectangle = new Rectangle(spritePositionX + 7, spritePositionY, 45, 60);
            }
            else if (animationFrame >= 10)
            {
                sourceRectangle = new Rectangle(129, 13, 14, 14);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(183, 11, 15, 15);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}


