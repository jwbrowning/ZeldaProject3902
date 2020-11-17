using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class SwordCollisionHandler : ICollisionHandler
    {
        private ISword sword;
        public ICollider Collider { get; set; }

        public SwordCollisionHandler(ISword sword, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.sword = sword;
            Collider = new BoxCollider(sword, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        public void HandleBlockCollision(ICollider collider)
        {

        }

        public void HandleEnemyCollision(ICollider collider)
        {

        }

        public void HandlePlayerCollision(ICollider collider)
        {

        }

        public void HandlePickupItemCollision(ICollider collider)
        {

        }

        public void HandleUsableItemCollision(ICollider collider)
        {

        }

        public void HandleNPCCollision(ICollider collider)
        {

        }

        public void HandleSwordCollision(ICollider collider)
        {

        }

        public void HandleDoorCollision(ICollider collider)
        {

        }
        public void HandleWallCollision(ICollider collider)
        {

        }
    }
}
