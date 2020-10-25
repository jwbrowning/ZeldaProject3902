using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;

namespace CrossPlatformDesktopProject.Environment
{
    class Stairs : IBlock
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(64, 64);

        public Stairs(Vector2 position)
        {
            Texture = BlockSpriteFactory.Instance.environment;
            Position = position;
            CollisionHandler = new BlockCollisionHandler(this, size.X, size.Y, 0, 0);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1036, 29, 14, 14);
            destinationRectangle = new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
