﻿using System;
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
    class Dodongo : IEnemy
    {
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        int directionCode = 0; //keeps track of which direction sprite should move
        int patrolPhase = 1;
        int patrolFrame = 1;
        private IPlayer player;
        private Game1 game;
        private int health = 6;

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


        public Dodongo(Game1 game, Vector2 position)
        {
            Texture = NPCSpriteFactory.Instance.textureBosses;
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
            patrolFrame++;

            if (animationFrame == 20)
                animationFrame = 1;

            if (patrolFrame == 200)
                patrolFrame = 1;


            if (patrolPhase == 1)
            {
                if (patrolFrame <= 100)
                {
                    directionCode = 0;
                }
                else if (patrolFrame > 100)
                {
                    directionCode = 1;
                }

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
            }

            if (directionCode == 0)
            {
                spritePositionY = spritePositionY - 2;
            }
            else if (directionCode == 1)
            {
                spritePositionY = spritePositionY + 2;
            }
            else if (directionCode == 2)
            {
                spritePositionX = spritePositionX - 2;
            }
            else if (directionCode == 3)
            {
                spritePositionX = spritePositionX + 2;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (directionCode == 3)
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
            else if (directionCode == 0)
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
            else if (directionCode == 2)
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
            else if (directionCode == 1)
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
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

