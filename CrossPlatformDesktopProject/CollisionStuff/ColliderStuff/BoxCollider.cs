using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.CollisionStuff.ColliderStuff
{
    class BoxCollider : ICollider
    {
        public IGameObject GameObject { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Offset { get; set; }

        public BoxCollider(IGameObject gameObject, float width, float height, float offsetX, float offsetY)
        {
            GameObject = gameObject;
            Offset = new Vector2(offsetX, offsetY);
            Size = new Vector2(width, height);
        }
    }
}
