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
using System.Runtime.CompilerServices;

namespace Sprint0
{
    class BlueKeese : IEnemy
    {
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
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


        public BlueKeese(Game1 game, Vector2 position)
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

            Vector2 position = player.Position;
            float playerPositionX = position.X;
            float playerPositionY = position.Y;

            animationFrame++;
            
            if (animationFrame == 10)
                animationFrame = 1;

            if(playerPositionX < spritePositionX)
            {
                spritePositionX = spritePositionX - 2;
            }
            else if (playerPositionX > spritePositionX)
            {
                spritePositionX = spritePositionX + 2;
            }

            if (playerPositionY < spritePositionY)
            {
                spritePositionY = spritePositionY - 2;
            }
            else if (playerPositionY > spritePositionY)
            {
                spritePositionY = spritePositionY + 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 5)
            {
                sourceRectangle = new Rectangle(183, 11, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 5)
            {
                sourceRectangle = new Rectangle(200, 11, 15, 15);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(183, 11, 15, 15);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

