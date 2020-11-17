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
        private ISprite topLeft,topRight,bottomLeft,bottomRight;
        float distance = 8;
        const float speed = 5f;
        private Random random;
        private float timer = 0, interval = 5;

        public SplittingEffect(Vector2 position)
        {
            Position = position;
            random = new Random();
            topLeft = UsableItemSpriteFactory.Instance.CreateTopLeftEffectSprite(Color.White);
            topRight = UsableItemSpriteFactory.Instance.CreateTopRightEffectSprite(Color.White);
            bottomLeft = UsableItemSpriteFactory.Instance.CreateBottomLeftEffectSprite(Color.White);
            bottomRight = UsableItemSpriteFactory.Instance.CreateBottomRightEffectSprite(Color.White);
            CollisionHandler = new EmptyCollisionHandler(this);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Color overlay;
            if((int)(timer/interval)%5==0)
            {
                overlay = Color.White;
            }
            else
            {
                overlay = new Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble(), 1);
            }
            ((UsableItemSprite)bottomRight).overlayColor = overlay;
            ((UsableItemSprite)bottomLeft).overlayColor = overlay;
            ((UsableItemSprite)topLeft).overlayColor = overlay;
            ((UsableItemSprite)topRight).overlayColor = overlay;
            Vector2 adjust = Vector2.Transform(distance * Vector2.UnitX, Matrix.CreateRotationZ(0 * (float)Math.PI / 2f + (float)Math.PI / 4f));
            bottomRight.Draw(spriteBatch, parentPos + Position + adjust);
            adjust = Vector2.Transform(distance * Vector2.UnitX, Matrix.CreateRotationZ(1 * (float)Math.PI / 2f + (float)Math.PI / 4f));
            bottomLeft.Draw(spriteBatch, parentPos + Position + adjust);
            adjust = Vector2.Transform(distance * Vector2.UnitX, Matrix.CreateRotationZ(2 * (float)Math.PI / 2f + (float)Math.PI / 4f));
            topLeft.Draw(spriteBatch, parentPos + Position + adjust);
            adjust = Vector2.Transform(distance * Vector2.UnitX, Matrix.CreateRotationZ(3 * (float)Math.PI / 2f + (float)Math.PI / 4f));
            topRight.Draw(spriteBatch, parentPos + Position + adjust);
        }

        public void Update()
        {
            timer++;
            distance += speed;
        }
    }
}
