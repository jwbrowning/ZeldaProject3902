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
    class Aquamentus : INPC
    {
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;

        private int spritePositionX = 600;
        private int spritePositionY = 200;

        private int fireballPosition1X = 600;
        private int fireballPosition1Y = 180;

        private int fireballPosition2X = 600;
        private int fireballPosition2Y = 200;

        private int fireballPosition3X = 600;
        private int fireballPosition3Y = 220;
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


        public Aquamentus(Texture2D texture)
        {
            Texture = texture;
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
                fireballPosition1X = 600;
                fireballPosition2X = 600;
                fireballPosition3X = 600;

                fireballPosition1Y = 180;
                fireballPosition2Y = 200;
                fireballPosition3Y = 220;


            }

            if (movementFrame <= 100)
            {
                spritePositionX = spritePositionX + 1;

                fireballPosition1X = fireballPosition1X - 3;
                fireballPosition2X = fireballPosition2X - 3;
                fireballPosition3X = fireballPosition3X - 3;

                fireballPosition1Y = fireballPosition1Y - 1;
                fireballPosition2Y = fireballPosition2Y - 0;
                fireballPosition3Y = fireballPosition3Y + 1;
            }
            else if (movementFrame > 100 && movementFrame <= 200)
            {
                spritePositionY = spritePositionY - 1;

                fireballPosition1X = fireballPosition1X - 3;
                fireballPosition2X = fireballPosition2X - 3;
                fireballPosition3X = fireballPosition3X - 3;

                fireballPosition1Y = fireballPosition1Y - 1;
                fireballPosition2Y = fireballPosition2Y - 0;
                fireballPosition3Y = fireballPosition3Y + 1;
            }
            else if (movementFrame > 200 && movementFrame <= 300)
            {
                spritePositionX = spritePositionX - 1;

                fireballPosition1X = fireballPosition1X - 3;
                fireballPosition2X = fireballPosition2X - 3;
                fireballPosition3X = fireballPosition3X - 3;

                fireballPosition1Y = fireballPosition1Y - 1;
                fireballPosition2Y = fireballPosition2Y - 0;
                fireballPosition3Y = fireballPosition3Y + 1;
            }
            else if (movementFrame > 300)
            {
                spritePositionY = spritePositionY + 1;

                fireballPosition1X = fireballPosition1X - 3;
                fireballPosition2X = fireballPosition2X - 3;
                fireballPosition3X = fireballPosition3X - 3;

                fireballPosition1Y = fireballPosition1Y - 1;
                fireballPosition2Y = fireballPosition2Y - 0;
                fireballPosition3Y = fireballPosition3Y + 1;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;
            Rectangle sourceRectangleFireball1;
            Rectangle destinationRectangleFireball1;
            Rectangle sourceRectangleFireball2;
            Rectangle destinationRectangleFireball2;
            Rectangle sourceRectangleFireball3;
            Rectangle destinationRectangleFireball3;

            if (animationFrame >= 1 && animationFrame < 10)
            {
                sourceRectangle = new Rectangle(1, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);

                sourceRectangleFireball1 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball1 = new Rectangle(fireballPosition1X, fireballPosition1Y, 20, 40);

                sourceRectangleFireball2 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball2 = new Rectangle(fireballPosition2X, fireballPosition2Y, 20, 40);

                sourceRectangleFireball3 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball3 = new Rectangle(fireballPosition3X, fireballPosition3Y, 20, 40);
            }
            else if (animationFrame >= 10 && animationFrame < 20)
            {
                sourceRectangle = new Rectangle(26, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);

                sourceRectangleFireball1 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball1 = new Rectangle(fireballPosition1X, fireballPosition1Y, 20, 40);

                sourceRectangleFireball2 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball2 = new Rectangle(fireballPosition2X, fireballPosition2Y, 20, 40);

                sourceRectangleFireball3 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball3 = new Rectangle(fireballPosition3X, fireballPosition3Y, 20, 40);
            }
            else if (animationFrame >= 20 && animationFrame < 30)
            {
                sourceRectangle = new Rectangle(51, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);

                sourceRectangleFireball1 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball1 = new Rectangle(fireballPosition1X, fireballPosition1Y, 20, 40);

                sourceRectangleFireball2 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball2 = new Rectangle(fireballPosition2X, fireballPosition2Y, 20, 40);

                sourceRectangleFireball3 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball3 = new Rectangle(fireballPosition3X, fireballPosition3Y, 20, 40);
            }
            else if (animationFrame > 30)
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);

                sourceRectangleFireball1 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball1 = new Rectangle(fireballPosition1X, fireballPosition1Y, 20, 40);

                sourceRectangleFireball2 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball2 = new Rectangle(fireballPosition2X, fireballPosition2Y, 20, 40);

                sourceRectangleFireball3 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball3 = new Rectangle(fireballPosition3X, fireballPosition3Y, 20, 40);

            }
            else
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);

                sourceRectangleFireball1 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball1 = new Rectangle(fireballPosition1X, fireballPosition1Y, 20, 40);

                sourceRectangleFireball2 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball2 = new Rectangle(fireballPosition2X, fireballPosition2Y, 20, 40);

                sourceRectangleFireball3 = new Rectangle(119, 11, 8, 16);
                destinationRectangleFireball3 = new Rectangle(fireballPosition3X, fireballPosition3Y, 20, 40);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.Draw(Texture, destinationRectangleFireball1, sourceRectangleFireball1, Color.White);
            spriteBatch.Draw(Texture, destinationRectangleFireball2, sourceRectangleFireball2, Color.White);
            spriteBatch.Draw(Texture, destinationRectangleFireball3, sourceRectangleFireball3, Color.White);
            spriteBatch.End();
        }
    }
}