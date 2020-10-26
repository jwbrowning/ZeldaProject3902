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
using System.Dynamic;

namespace Sprint0
{
    class Fireball : IEnemy
    {
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }

        public int spritePositionX;
        public int spritePositionY;
        int fireballCode = 1;

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

        public Fireball(IPlayer player, Vector2 position, int fireballCode) //fireballCode is a number between 0-2 that determines which of the 3 fireballs will be drawn.
        {
            Texture = NPCSpriteFactory.Instance.textureBosses;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(this, size.X, size.Y, 0, 5);
            this.fireballCode = fireballCode;
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

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(119, 11, 8, 16);
            destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 20, 40);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}