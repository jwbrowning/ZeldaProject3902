using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class LinkCollisionHandler : ICollisionHandler
    {
        private IPlayer player;
        public ICollider Collider { get; set; }

        public LinkCollisionHandler(IPlayer player, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.player = player;
            Collider = new BoxCollider(player, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {
            Rectangle myRectangle = new Rectangle((int)(player.Position.X+Collider.Offset.X), (int)(player.Position.Y+Collider.Offset.Y), (int)Collider.Size.X, (int)Collider.Size.Y);
            Rectangle colRectangle = new Rectangle((int)(collider.GameObject.Position.X + collider.Offset.X), (int)(collider.GameObject.Position.Y + collider.Offset.Y), (int)collider.Size.X, (int)collider.Size.Y);
            Rectangle overlap = Rectangle.Intersect(myRectangle, colRectangle);
            Point d = (colRectangle.Location - myRectangle.Location);
            Vector2 direction = new Vector2(d.X, d.Y);
            if (overlap.Width > overlap.Height)
            {
                // Up-Down Collision
                direction.X = 0;
                direction.Normalize();
                player.Position -= direction * overlap.Height; // might need /2 here, needs testing
            }
            else
            {
                // Left-Right Collision
                direction.Y = 0;
                direction.Normalize();
                player.Position -= direction * overlap.Width;
            }
        }

        public void HandleBlockCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }

        public void HandleEnemyCollision(ICollider collider)
        {
            player.TakeDamage();
            HandleGenericCollision(collider);
        }

        public void HandlePlayerCollision(ICollider collider)
        {

        }

        public void HandlePickupItemCollision(ICollider collider)
        {
            // do stuff for item pickup
        }

        public void HandleUsableItemCollision(ICollider collider)
        {

        }

        public void HandleNPCCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }
    }
}
