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
    class BladeTrap : IEnemy
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
        private int health = 1;
        int patrolPhase = 1;
        int patrolFrame = 1;
        int directionCode = -1; //keeps track of which direction sprite should move. 0 is up, 1 is down, 2 is left, 3 is right.

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


        public BladeTrap(Game1 game, Vector2 position)
        {
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 0);
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
                game.currentRoom.Enemies[game.currentRoom.Enemies.IndexOf(this)] = new DamagedEnemy(this, game);
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
            patrolFrame++;

            if (animationFrame == 20)
                animationFrame = 1;

            if (patrolFrame == 200)
                patrolFrame = 1;


            if (patrolPhase == 1) //default phase of enemies, is changed after the enemy "sees" link. Bladetrap stays still
            {
                if (((spritePositionX - 10) <= playerPositionX && playerPositionX <= (spritePositionX + 10)) || ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10)))
                {
                    patrolPhase = 0;
                }
            }

            if (patrolPhase == 0)
            {
                if ((spritePositionX - 10) <= playerPositionX && playerPositionX <= (spritePositionX + 10))
                {
                    if (playerPositionY < spritePositionY)
                    {
                        directionCode = 0;
                    }
                    else if (playerPositionY > spritePositionY)
                    {
                        directionCode = 1;
                    }
                }

                if ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10))
                {
                    if (playerPositionX < spritePositionX)
                    {
                        directionCode = 2;
                    }
                    else if (playerPositionX > spritePositionX)
                    {
                        directionCode = 3;
                    }
                }

                patrolPhase = -1;
            }

            if (directionCode == 0)
            {
                spritePositionY = spritePositionY - 5;
            }
            else if (directionCode == 1)
            {
                spritePositionY = spritePositionY + 5;
            }
            else if (directionCode == 2)
            {
                spritePositionX = spritePositionX - 5;
            }
            else if (directionCode == 3)
            {
                spritePositionX = spritePositionX + 5;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(164, 59, 16, 16);
            destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

