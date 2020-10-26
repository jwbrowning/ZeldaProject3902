using System;
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
    class BlueGoriya : IEnemy
    {
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        private IPlayer player;
        private Game1 game;
        private int health = 2;

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


        public BlueGoriya(Game1 game, Vector2 position)
        {
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(this, size.X, size.Y, 0, 0);
            this.player = game.player;
            this.game = game;
        }

        public void TakeDamage()
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                game.enemies[game.enemies.IndexOf(this)] = new DamagedEnemy(this, game);
            }
        }

        public void Die()
        {

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

            if (movementFrame <= 100)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(256, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (movementFrame > 100 && movementFrame <= 200)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(240, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (movementFrame > 200 && movementFrame <= 300)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(440, 53, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (movementFrame > 300)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(223, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else
            {
                sourceRectangle = new Rectangle(422, 54, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

