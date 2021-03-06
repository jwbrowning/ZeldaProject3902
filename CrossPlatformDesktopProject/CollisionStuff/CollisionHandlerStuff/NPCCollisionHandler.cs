﻿using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class NPCCollisionHandler : ICollisionHandler
    {
        private INPC npc;
        public ICollider Collider { get; set; }

        public NPCCollisionHandler(INPC npc, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.npc = npc;
            Collider = new BoxCollider(npc, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {

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
            HandleGenericCollision(collider);
        }

        public void HandlePickupItemCollision(ICollider collider)
        {

        }

        public void HandleUsableItemCollision(ICollider collider)
        {

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

        }
        public void HandleWallCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }
    }
}
