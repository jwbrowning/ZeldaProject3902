using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

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

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            explosionSprite.Draw(spriteBatch, parentPos + Position);
        }

        public void Update()
        {
            explosionSprite.Update();
        }
    }
}
