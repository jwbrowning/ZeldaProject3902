using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    public interface ICollisionHandler
    {
        ICollider Collider { get; set; }
        void HandleBlockCollision(ICollider collider);
        void HandlePickupItemCollision(ICollider collider);
        void HandleUsableItemCollision(ICollider collider);
        void HandlePlayerCollision(ICollider collider);
        void HandleNPCCollision(ICollider collider);
        void HandleEnemyCollision(ICollider collider);
        void HandleSwordCollision(ICollider collider);
    }
}
