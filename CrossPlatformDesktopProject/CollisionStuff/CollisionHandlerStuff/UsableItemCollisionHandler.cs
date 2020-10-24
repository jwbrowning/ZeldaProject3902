﻿using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using CrossPlatformDesktopProject.Environment;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else if (item is UsableArrow && player.ActiveItems.Contains(item))
            {
                player.ActiveItems.Remove(item);
            }
        }

        public void HandleBlockCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }

        public void HandleEnemyCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
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
    }
}