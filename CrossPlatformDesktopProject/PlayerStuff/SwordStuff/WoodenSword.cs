using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.PlayerStuff.SwordStuff
{
    public class WoodenSword : ISword
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

        public WoodenSword(IPlayer player, Vector2 direction)
        {
            this.player = player;
            int swordLength = 48;
            int swordWidth = 32;
            if (direction == Vector2.UnitX)
            {
                CollisionHandler = new SwordCollisionHandler(this, swordLength, swordWidth, 32 + swordLength / 2, 6);
            }
            else if (direction == -Vector2.UnitX)
            {
                CollisionHandler = new SwordCollisionHandler(this, swordLength, swordWidth, -32 - swordLength / 2, 6);
            }
            else if (direction == Vector2.UnitY)
            {
                CollisionHandler = new SwordCollisionHandler(this, swordWidth, swordLength, 2, 32 + swordLength / 2);
            }
            else
            {
                CollisionHandler = new SwordCollisionHandler(this, swordWidth, swordLength, -5, -32 - swordLength / 2);
            }
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {

        }
    }
}
