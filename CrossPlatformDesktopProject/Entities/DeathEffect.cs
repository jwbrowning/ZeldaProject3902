using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace CrossPlatformDesktopProject.Entities
{
    class DeathEffect : IEntity
    {
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private ISprite effectSprite;
        private Random random;

        public DeathEffect(Vector2 position)
        {
            Position = position;
            random = new Random();
            effectSprite = UsableItemSpriteFactory.Instance.CreateExplosionSprite();
            CollisionHandler = new EmptyCollisionHandler(this);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            effectSprite.Draw(spriteBatch, parentPos + Position);
        }

        public void Update()
        {
            effectSprite.Update();
        }
    }
}
