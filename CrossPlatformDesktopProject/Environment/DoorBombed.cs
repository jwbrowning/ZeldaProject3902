using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Environment
{
    class DoorBombed : IDoor
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(128, 128);
        public string next;
        public string type;
        public static Dictionary<string, bool> isBombed = new Dictionary<string, bool>();
        private string currentRoom;

        public DoorBombed(Vector2 position, string t, string n, string c)
        {
            Texture = DoorSpriteFactory.Instance.environment;
            Position = position;
            next = n;
            type = t;
            currentRoom = c;
            if (!isBombed.ContainsKey(currentRoom))
            {
                isBombed.Add(currentRoom, false);
            }
            getCollider();
        }
        private void getCollider()
        {
            if (isBombed[currentRoom])
            {
                if (type == "Up")
                {
                    CollisionHandler = new DoorCollisionHandler(this, size.X / 4, size.Y - 16, 0, 0);
                }
                else if (type == "Down")
                {
                    CollisionHandler = new DoorCollisionHandler(this, size.X / 4, size.Y - 16, 0, 0);
                }
                else if (type == "Left")
                {
                    CollisionHandler = new DoorCollisionHandler(this, size.X - 16, size.Y / 4, 0, 0);
                }
                else if (type == "Right")
                {
                    CollisionHandler = new DoorCollisionHandler(this, size.X - 16, size.Y / 4, 0, 0);
                }
            }
            else
            {
                CollisionHandler = new DoorCollisionHandler(this, size.X / 4, size.Y / 4, 0, 0);
            }
        }

        public void Update()
        {

        }

        public void updateIsBombed()
        {
            isBombed[currentRoom] = true;
            if (!isBombed.ContainsKey(next))
            {
                isBombed.Add(next, true);
            }
            else
            {
                isBombed[next] = true;
            }

            getCollider();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle;

            if (type == "Up")
            {
                sourceRectangle = new Rectangle(947, 11, 32, 32);
            }
            else if (type == "Down")
            {
                sourceRectangle = new Rectangle(947, 110, 32, 32);
            }
            else if (type == "Left")
            {
                sourceRectangle = new Rectangle(947, 44, 32, 32);
            }
            else if (type == "Right")
            {
                sourceRectangle = new Rectangle(947, 77, 32, 32);
            }

            destinationRectangle = new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y);
            if (isBombed[currentRoom])
            {
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
                spriteBatch.End();
            }

        }
    }
}
