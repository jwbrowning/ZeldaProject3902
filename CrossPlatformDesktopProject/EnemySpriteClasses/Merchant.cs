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
    class Merchant : INPC
    {
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 600;
        private int spritePositionY = 200;
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


        public Merchant(Texture2D texture)
        {
            Texture = texture;
        }

        public void Update()
        {

            animationFrame++;
            movementFrame++;
            if (animationFrame == 10)
                animationFrame = 1;

            if (movementFrame == 400)
                movementFrame = 1;


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 5)
            {
                sourceRectangle = new Rectangle(109, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 5)
            {
                sourceRectangle = new Rectangle(109, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(103, 14, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

