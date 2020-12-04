using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Sprint0;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class UsableItemCollisionHandler : ICollisionHandler
    {
        private IUsableItem item;
        private IPlayer player;
        public ICollider Collider { get; set; }

        public UsableItemCollisionHandler(IPlayer player, IUsableItem item, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.player = player;
            this.item = item;
            Collider = new BoxCollider(item, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {
            if (item is UsableBoomerang)
            {
                ((UsableBoomerang)item).ComeBack();
            }
            else if (item is SwordBeam)
            {
                ((SwordBeam)item).Destroy();
            }
            else if (item is UsableArrow && player.ActiveItems.Contains(item))
            {
                player.ActiveItems.Remove(item);
            }

            if (item is UsableBomb && collider.GameObject is Dodongo)
            {
                player.ActiveItems.Remove(this.item);
            }
        }

        public void HandleBlockCollision(ICollider collider)
        {
            //HandleGenericCollision(collider);
            if (item is SwordBeam)
            {
                ((SwordBeam)item).Destroy();
            }
        }

        public void HandleEnemyCollision(ICollider collider)
        {
            if (!(collider.GameObject is Fireball)) HandleGenericCollision(collider);
        }

        public void HandlePlayerCollision(ICollider collider)
        {

        }

        public void HandlePickupItemCollision(ICollider collider)
        {

        }

        public void HandleUsableItemCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }

        public void HandleNPCCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }

        public void HandleSwordCollision(ICollider collider)
        {

        }

        public void HandleDoorCollision(ICollider collider)
        {
            if (item is SwordBeam)
            {
                ((SwordBeam)item).Destroy();
            }
            if (item is UsableBomb && collider.GameObject is DoorBombed)
            {
                ((DoorBombed)collider.GameObject).updateIsBombed();
            }
        }

        public void HandleWallCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }
    }
}
