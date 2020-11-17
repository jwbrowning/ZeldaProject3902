using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.Environment
{
    class BlockInvisible : IBlock
    {

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(64, 64);

        public BlockInvisible(Vector2 position)
        {
            Texture = BlockSpriteFactory.Instance.environment;
            Position = position;
            CollisionHandler = new BlockCollisionHandler(this, size.X, size.Y, 0, 0);
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1001, 11, 16, 16);
            destinationRectangle = new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, new Color(0,0,0,0));
            spriteBatch.End();
        }
    }
}
