using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff
{
    class LinkCollisionHandler : ICollisionHandler
    {
        private Game1 game;
        public ICollider Collider { get; set; }

        public LinkCollisionHandler(Game1 game, IPlayer player, float colliderWidth, float colliderHeight, float offsetX, float offsetY)
        {
            this.game = game;
            Collider = new BoxCollider(player, colliderWidth, colliderHeight, offsetX, offsetY);
        }

        private void HandleGenericCollision(ICollider collider)
        {
            Rectangle myRectangle = CollisionDetection.GetColliderRectangle(game.player);
            Rectangle colRectangle = CollisionDetection.GetColliderRectangle(collider.GameObject);
            Rectangle overlap = Rectangle.Intersect(myRectangle, colRectangle);
            Point d = (colRectangle.Location - myRectangle.Location);
            Vector2 direction = new Vector2(d.X, d.Y);
            if (overlap.Width > overlap.Height)
            {
                // Up-Down Collision
                direction.X = 0;
                direction.Normalize();
                game.player.Position -= direction * overlap.Height; // might need /2 here, needs testing
            }
            else
            {
                // Left-Right Collision
                direction.Y = 0;
                direction.Normalize();
                game.player.Position -= direction * overlap.Width;
            }
        }

        public void HandleBlockCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }

        public void HandleEnemyCollision(ICollider collider)
        {
            game.player.TakeDamage();
            //HandleGenericCollision(collider);
        }

        public void HandlePlayerCollision(ICollider collider)
        {

        }

        public void HandlePickupItemCollision(ICollider collider)
        {
            if(collider.GameObject is Arrow)
            {
                game.player.PickUp(ItemType.Arrow, 1);
            }
            else if (collider.GameObject is Bomb)
            {
                game.player.ItemCounts[ItemType.Bomb]++;
            }
            else if(collider.GameObject is Boomerang)
            {
                game.player.ItemCounts[ItemType.Boomerang]++;
            }
            else if(collider.GameObject is Bow)
            {
                game.player.ItemCounts[ItemType.Bow]++;
            }
            else if(collider.GameObject is Clock)
            {
                game.player.ItemCounts[ItemType.Clock]++;
            }
            else if(collider.GameObject is Compass)
            {
                game.player.ItemCounts[ItemType.Compass]++;
            }
            else if(collider.GameObject is Fairy)
            {
                game.player.ItemCounts[ItemType.Fairy]++;
            }
            else if(collider.GameObject is Heart)
            {
                game.player.ItemCounts[ItemType.Heart]++;
            }
            else if(collider.GameObject is HeartContainer)
            {
                game.player.ItemCounts[ItemType.HeartContainer]++;
            }
            else if(collider.GameObject is Key)
            {
                game.player.ItemCounts[ItemType.Key]++;
            }
            else if(collider.GameObject is Map)
            {
                game.player.ItemCounts[ItemType.Map]++;
            }
            else if(collider.GameObject is Rupee)
            {
                game.player.ItemCounts[ItemType.Rupee]++;
            }
            else if(collider.GameObject is TriforcePiece)
            {
                game.player.ItemCounts[ItemType.TriforcePiece]++;
            }
            game.items.Remove((IItem)collider.GameObject);
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
    }
}
