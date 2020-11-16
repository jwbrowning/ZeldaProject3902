using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.PlayerStuff.SwordStuff
{
    public class EmptySword : ISword
    {
        private IPlayer player;
        public Vector2 Position
        {
            get
            {
                return player.Position;
            }
            set
            {

            }
        }
        public ICollisionHandler CollisionHandler { get; set; }

        public EmptySword(IPlayer player)
        {
            this.player = player;
            CollisionHandler = new EmptyCollisionHandler(this);
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {

        }
    }
}
