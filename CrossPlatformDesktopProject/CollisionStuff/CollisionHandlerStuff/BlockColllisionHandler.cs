using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.Environment;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class BlockCollisionHandler : ICollisionHandler
    {
        private IBlock block;
        public ICollider Collider { get; set; }

        public BlockCollisionHandler(IBlock block, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.block = block;
            Collider = new BoxCollider(block, colliderWidth, colliderHeight, offsetX, offsetY);
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
    }
}
