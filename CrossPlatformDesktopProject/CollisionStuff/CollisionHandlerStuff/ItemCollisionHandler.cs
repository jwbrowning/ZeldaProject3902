using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class ItemCollisionHandler : ICollisionHandler
    {
        private IItem item;
        public ICollider Collider { get; set; }

        public ItemCollisionHandler(IItem item, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            Collider = new BoxCollider(item, colliderWidth, colliderHeight, offsetX, offsetY);
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
    }
}
