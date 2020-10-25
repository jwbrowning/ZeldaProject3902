using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Environment
{
    class BlockStandard : IBlock
    {

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(50, 50);

        public BlockStandard(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            CollisionHandler = new BlockCollisionHandler(this, size.X, size.Y, 0, 0);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1001, 11, 16, 16);
            destinationRectangle = new Rectangle((int)(Position.X-size.X/2f), (int)(Position.Y-size.Y/2f), 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
