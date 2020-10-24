﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Entities
{
    class ExplosionEffect : IEntity
    {
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private ISprite explosionSprite;
        private Random random;

        public ExplosionEffect(Vector2 position)
        {
            Position = position;
            random = new Random();
            explosionSprite = UsableItemSpriteFactory.Instance.CreateExplosionSprite();
            CollisionHandler = new EmptyCollisionHandler(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            explosionSprite.Draw(spriteBatch, Position);
        }

        public void Update()
        {
            explosionSprite.Update();
        }
    }
}