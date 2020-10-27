using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.CollisionStuff.ColliderStuff
{
    public interface ICollider
    {
        IGameObject GameObject { get; set; }
        Vector2 Size { get; set; }
        Vector2 Offset { get; set; }
    }
}
