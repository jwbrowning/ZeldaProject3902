using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace CrossPlatformDesktopProject.Entities
{
    class SplittingEffect : IEntity
    {
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private ISprite explosionSprite;
        private Random random;

        public SplittingEffect(Vector2 position)
        {
            Position = position;
            explosionSprite = UsableItemSpriteFactory.Instance.CreateExplosionSprite();
            CollisionHandler = new EmptyCollisionHandler(this);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {

        }

        public void Update()
        {

        }
    }
}
