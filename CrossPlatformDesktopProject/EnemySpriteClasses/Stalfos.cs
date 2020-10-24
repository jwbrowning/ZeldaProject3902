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
    class Stalfos : IEnemy
    {
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        int directionCode = 0; //keeps track of which direction sprite should move
        int patrolPhase = 1;
        int patrolFrame = 1;
        private IPlayer player;

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


        public Stalfos(Texture2D texture, IPlayer player)
        {
            Texture = texture;
            CollisionHandler = new EnemyCollisionHandler(this, size.X, size.Y, 0, 0);
            this.player = player;
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


            if(patrolPhase == 1)
            {
                if(patrolFrame <= 100)
                {
                    directionCode = 0;
                }
                else if(patrolFrame > 100)
                {
                    directionCode = 1;
                }

                if (((spritePositionX - 10) <= playerPositionX && playerPositionX <= (spritePositionX + 10)) || ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10)))
                {
                    patrolPhase = 0;
                }

            }


          if(patrolPhase == 0)
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
            else if(directionCode == 1)
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

            if (animationFrame >= 1 && animationFrame < 10)
            {
                sourceRectangle = new Rectangle(1, 59, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 10)
            {
                sourceRectangle = new Rectangle(234, 193, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(234, 193, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

