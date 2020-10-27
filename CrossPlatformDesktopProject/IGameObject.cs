using CrossPlatformDesktopProject.CollisionStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    public interface IGameObject : ICollidable
    {
        Vector2 Position { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
