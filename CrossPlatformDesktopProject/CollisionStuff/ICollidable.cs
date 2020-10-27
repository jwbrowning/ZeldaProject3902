using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;

namespace CrossPlatformDesktopProject.CollisionStuff
{
    public interface ICollidable
    {
        ICollisionHandler CollisionHandler { get; set; }
    }
}
