using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.Environment;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class DoorCollisionHandler : ICollisionHandler
    {
        private IDoor door;
        public ICollider Collider { get; set; }

        public DoorCollisionHandler(IDoor doors, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.door = doors;
            Collider = new BoxCollider(doors, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {

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
