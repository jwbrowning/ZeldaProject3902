using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class OldMan : INPC
    {
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 600;
        private int spritePositionY = 200;

        private Vector2 size = new Vector2(60, 60);
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


        public OldMan(Vector2 position)
        {
            Texture = NPCSpriteFactory.Instance.textureNPCs;
            Position = position;
            CollisionHandler = new NPCCollisionHandler(this, size.X, size.Y, 0, 0);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 5)
            {
                sourceRectangle = new Rectangle(18, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 5)
            {
                sourceRectangle = new Rectangle(18, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(18, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

