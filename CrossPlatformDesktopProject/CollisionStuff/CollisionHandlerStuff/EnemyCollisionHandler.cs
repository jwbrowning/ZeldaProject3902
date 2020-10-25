using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class EnemyCollisionHandler : ICollisionHandler
    {
        private IEnemy enemy;
        public ICollider Collider { get; set; }

        public EnemyCollisionHandler(IEnemy enemy, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.enemy = enemy;
            Collider = new BoxCollider(enemy, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {
            Rectangle myRectangle = GetColliderRectangle(enemy);
            Rectangle colRectangle = GetColliderRectangle(collider.GameObject);
            Rectangle overlap = Rectangle.Intersect(myRectangle, colRectangle);
            Point d = (colRectangle.Location - myRectangle.Location);
            Vector2 direction = new Vector2(d.X, d.Y);
            if (overlap.Width > overlap.Height)
            {
                // Up-Down Collision
                direction.X = 0;
                direction.Normalize();
                enemy.Position -= direction * overlap.Height; // might need /2 here, needs testing
            }
            else
            {
                // Left-Right Collision
                direction.Y = 0;
                direction.Normalize();
                enemy.Position -= direction * overlap.Width;
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
            // Should enemies collide with eachother?
        }

        public void HandlePlayerCollision(ICollider collider)
        {
            //HandleGenericCollision(collider);
        }

        public void HandlePickupItemCollision(ICollider collider)
        {

        }

        public void HandleUsableItemCollision(ICollider collider)
        {
            // should take damage from usable item here
        }

        public void HandleNPCCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }
    }
}
