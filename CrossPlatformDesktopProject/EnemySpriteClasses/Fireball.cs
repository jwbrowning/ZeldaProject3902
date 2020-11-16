using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class Fireball : IEnemy
    {
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }

        public int spritePositionX;
        public int spritePositionY;
        int fireballCode = 1;
        private Game1 game;

        private Vector2 size = new Vector2(20, 30);
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

        public Fireball(Game1 game, IPlayer player, Vector2 position, int fireballCode) //fireballCode is a number between 0-2 that determines which of the 3 fireballs will be drawn. 0 is top, 1 is middle, 2 is bottom.
        {
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureBosses;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 5);
            this.fireballCode = fireballCode;
            this.game = game;
        }

        public void TakeDamage()
        {
            //Fireballs are invincible
        }

        public void Die()
        {
            //Fireballs are invincible
        }

        public void Update()
        {

            if (fireballCode == 0)
            {
                spritePositionX = spritePositionX - 2;
                spritePositionY = spritePositionY - 2;
            }

            if (fireballCode == 1)
            {
                spritePositionX = spritePositionX - 2;
            }

            if (fireballCode == 2)
            {
                spritePositionX = spritePositionX - 2;
                spritePositionY = spritePositionY + 2;
            }

            if (spritePositionX < -600)//when a fireball moves off screen to the left it will be deleted to save space.
            {
                game.currentRoom.Enemies.Remove(this);
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(119, 11, 8, 16);
            destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 20, 40);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
