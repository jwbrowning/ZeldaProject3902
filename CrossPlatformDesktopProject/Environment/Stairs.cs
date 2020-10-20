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
        private Vector2 size = new Vector2(50, 50);

        public Stairs(Texture2D texture)
        {
            Texture = texture;
            CollisionHandler = new BlockCollisionHandler(this, size.X, size.Y, 0, 0);
        }

        public void Update() { }
        public void Draw(SpriteBatch spriteBatch) { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Position = location;
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1036, 29, 14, 14);
            destinationRectangle = new Rectangle(200, 200, 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
