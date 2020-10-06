﻿using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableBoomerang : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        private Vector2 direction;
        private float speed = 6f;
        private IPlayer player;
        private int timer = 50;
        private float dist = 5;

        public UsableBoomerang(Vector2 position, Vector2 direction, IPlayer player)
        {
            Position = position;
            this.direction = direction;
            this.player = player;
            Sprite = UsableItemSpriteFactory.Instance.CreateBoomerangSprite();
        }

        public void Update()
        {
            if(timer > 0)
            {
                Position += direction * speed;
                timer--;
                Sprite.Update();
            }
            else
            {
                if(Vector2.Distance(player.Position,Position) < dist)
                {
                    if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
                } 
                else
                {
                    Vector2 tempDirection = player.Position - Position;
                    tempDirection.Normalize();
                    Position += tempDirection * speed;
                    Sprite.Update();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }
    }
}