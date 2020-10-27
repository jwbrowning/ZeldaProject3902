﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class Statue2 : IBlock
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(50, 50);

        public Statue2(Texture2D texture)
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

            sourceRectangle = new Rectangle(1035, 11, 16, 16);
            destinationRectangle = new Rectangle(200, 200, 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
