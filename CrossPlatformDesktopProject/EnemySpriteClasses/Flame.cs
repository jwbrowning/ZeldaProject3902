using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class Flame : IEnemy
    {
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 600;
        private int spritePositionY = 200;
        private IPlayer player;
        private Game1 game;
        private int health = 1;

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


        public Flame(Game1 game, Vector2 position)
        {
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureNPCs;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 0);
            this.player = game.player;
            this.game = game;
        }

        public void TakeDamage()
        {
            health--;
            SoundFactory.Instance.sfxEnemyDamage.Play();
            if (health <= 0)
            {
                Die();
            }
            else
            {
                game.currentRoom.Enemies[game.currentRoom.Enemies.IndexOf(this)] = new DamagedEnemy(this, game);
            }
        }

        public void Die()
        {
            SoundFactory.Instance.sfxEnemyDeath.Play();
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
                sourceRectangle = new Rectangle(52, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 5)
            {
                sourceRectangle = new Rectangle(170, 12, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(1, 59, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

