using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.Environment
{

    class DoorClosed : IDoor

    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 size = new Vector2(128, 128);
        public string type;
        public string next;
        public List<IEnemy> enemies;
        public static Dictionary<string, bool> isClosed = new Dictionary<string, bool>();

        public DoorClosed(Vector2 position, string t, string n, List<IEnemy> e)
        {
            Texture = DoorSpriteFactory.Instance.environment;
            Position = position;
            type = t;
            next = n;
            enemies = e;
            if (!isClosed.ContainsKey(next))
            {
                isClosed.Add(next, false);
            }
            getCollider();
        }

        private void getCollider()
        {
            if (enemies.Count == 0)
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
            if (enemies.Count == 0)
            {
                getCollider();
            }
        }

        public static void ResetClosedDoors()
        {
            isClosed.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle;
            if (enemies.Count == 0)
            {
                if (type == "Up")
                {
                    sourceRectangle = new Rectangle(848, 11, 32, 32);
                }
                else if (type == "Down")
                {
                    sourceRectangle = new Rectangle(848, 110, 32, 32);
                }
                else if (type == "Left")
                {
                    sourceRectangle = new Rectangle(848, 44, 32, 32);
                }
                else if (type == "Right")
                {
                    sourceRectangle = new Rectangle(848, 77, 32, 32);
                }
            }
            else
            {
                if (type == "Up")
                {
                    sourceRectangle = new Rectangle(914, 11, 32, 32);
                }
                else if (type == "Down")
                {
                    sourceRectangle = new Rectangle(914, 110, 32, 32);
                }
                else if (type == "Left")
                {
                    sourceRectangle = new Rectangle(914, 44, 32, 32);
                }
                else if (type == "Right")
                {
                    sourceRectangle = new Rectangle(914, 77, 32, 32);
                }
            }


            destinationRectangle = new Rectangle((int)(Position.X - size.X / 2f), (int)(Position.Y - size.Y / 2f), (int)size.X, (int)size.Y);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
