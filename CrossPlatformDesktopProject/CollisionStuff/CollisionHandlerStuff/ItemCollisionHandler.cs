using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class ItemCollisionHandler : ICollisionHandler
    {
        private IItem item;
        private float followSpeed = 6.2f;
        public ICollider Collider { get; set; }

        public ItemCollisionHandler(IItem item, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.item = item;
            Collider = new BoxCollider(item, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {
            Rectangle myRectangle = CollisionDetection.GetColliderRectangle(item);
            Rectangle colRectangle = CollisionDetection.GetColliderRectangle(collider.GameObject);
            Rectangle overlap = Rectangle.Intersect(myRectangle, colRectangle);
            Point d = (colRectangle.Location - myRectangle.Location);
            Vector2 direction = new Vector2(d.X, d.Y);
            if (overlap.Width > overlap.Height)
            {
                // Up-Down Collision
                direction.X = 0;
                direction.Normalize();
                item.Position -= direction * overlap.Height; // might need /2 here, needs testing
            }
            else
            {
                // Left-Right Collision
                direction.Y = 0;
                direction.Normalize();
                item.Position -= direction * overlap.Width;
            }
        }

        private Rectangle GetColliderRectangle(IGameObject gameObject)
        {
            return new Rectangle((int)(gameObject.Position.X + gameObject.CollisionHandler.Collider.Offset.X - gameObject.CollisionHandler.Collider.Size.X / 2), (int)(gameObject.Position.Y + gameObject.CollisionHandler.Collider.Offset.Y - gameObject.CollisionHandler.Collider.Size.Y / 2), (int)gameObject.CollisionHandler.Collider.Size.X, (int)gameObject.CollisionHandler.Collider.Size.Y);
        }

        public void HandleBlockCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
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
            if (collider.GameObject is UsableBoomerang)
            {
                ((UsableBoomerang)collider.GameObject).ComeBack();
                Vector2 direction = collider.GameObject.Position - item.Position;
                direction.Normalize();
                item.Position += direction * followSpeed;
            }
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
