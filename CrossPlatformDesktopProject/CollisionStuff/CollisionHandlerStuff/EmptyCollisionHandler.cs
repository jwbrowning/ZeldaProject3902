﻿using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class EmptyCollisionHandler : ICollisionHandler
    {
        public ICollider Collider { get; set; }

        public EmptyCollisionHandler(IGameObject gameObject)
        {
            Collider = new BoxCollider(gameObject, 0, 0, 0, 0);
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
