using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CrossPlatformDesktopProject.Environment
{
    class DoorLocked : IDoor
    {

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(96, 96);
        public string next;
        public string type;

        public DoorLocked(Vector2 position, string t, string n)
        {
            Texture = DoorSpriteFactory.Instance.environment;
            Position = position;
            CollisionHandler = new DoorCollisionHandler(this, size.X, size.Y, 0, 0);
            type = t;
            next = n;
        }

        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Rectangle sourceRectangle = new Rectangle(0,0,0,0);
            Rectangle destinationRectangle;

            if(type == "Up"){
                sourceRectangle = new Rectangle(881, 11, 32, 32);
            } else if(type == "Down") {
                sourceRectangle = new Rectangle(881, 110, 32, 32);
            } else if(type == "Left") {
                sourceRectangle = new Rectangle(881, 44, 32, 32);
            } else if(type == "Right") {
                sourceRectangle = new Rectangle(881, 77, 32, 32);
            }

            destinationRectangle = new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
