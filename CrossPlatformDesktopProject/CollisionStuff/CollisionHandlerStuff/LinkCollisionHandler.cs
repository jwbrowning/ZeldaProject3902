using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Sprint0;
using System;

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
            if (collider.GameObject is Stairs)
            {
                game.ChangeRoom("RoomBOW", "Right");
            } 
            else if (collider.GameObject is StairsInvisible)
            {
                game.ChangeRoom("RoomB1", "Left");
            }
            else
            {
                HandleGenericCollision(collider);
            }
        }

        public void HandleEnemyCollision(ICollider collider)
        {
            /*if (!(game.player is DamagedLink))
            {
                float magnitude = 32;
                Vector2 direction = game.player.Position - collider.GameObject.Position;
                direction.Normalize();
                game.player.Position += direction * magnitude;
            }*/
            game.player.TakeDamage();
        }

        public void HandlePlayerCollision(ICollider collider)
        {

        }

        public void HandlePickupItemCollision(ICollider collider)
        {
            if (collider.GameObject is Arrow)
            {
                game.player.PickUp(ItemType.Arrow, 1);
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Bomb)
            {
                game.player.ItemCounts[ItemType.Bomb]++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Boomerang)
            {
                game.player.ItemCounts[ItemType.Boomerang]++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Bow)
            {
                game.player.ItemCounts[ItemType.Bow]++;
                SoundFactory.Instance.sfxNewItem.Play();
            }
            else if (collider.GameObject is Clock)
            {
                game.player.ItemCounts[ItemType.Clock]++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Compass)
            {
                game.player.ItemCounts[ItemType.Compass]++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Fairy)
            {
                game.player.ItemCounts[ItemType.Fairy]++;
                game.player.Health = game.player.TotalHealth;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Heart)
            {
                game.player.ItemCounts[ItemType.Heart]++;
                game.player.Health++;
                SoundFactory.Instance.sfxHeartKeyPickup.Play();
                if (game.player.Health > game.player.TotalHealth) game.player.Health = game.player.TotalHealth;
            }
            else if (collider.GameObject is HeartContainer)
            {
                game.player.ItemCounts[ItemType.HeartContainer]++;
                game.player.TotalHealth++;
                game.player.Health++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Key)
            {
                game.player.ItemCounts[ItemType.Key]++;
                SoundFactory.Instance.sfxHeartKeyPickup.Play();
            }
            else if (collider.GameObject is Map)
            {
                game.player.ItemCounts[ItemType.Map]++;
                SoundFactory.Instance.sfxItemPickup.Play();
            }
            else if (collider.GameObject is Rupee)
            {
                game.player.ItemCounts[ItemType.Rupee]++;
                SoundFactory.Instance.sfxRupeePickup.Play();
            }
            else if (collider.GameObject is TriforcePiece)
            {
                game.player.ItemCounts[ItemType.TriforcePiece]++;
                game.Win();
                //triforce music
            }
            game.currentRoom.Items.Remove((IItem)collider.GameObject);
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
            if(collider.GameObject is DoorOpen) 
            {
                game.ChangeRoom(((DoorOpen)collider.GameObject).next, ((DoorOpen)collider.GameObject).type);
            } else if(collider.GameObject is DoorClosed) 
            {
                game.ChangeRoom(((DoorClosed)collider.GameObject).next, ((DoorClosed)collider.GameObject).type);
            } else if(collider.GameObject is DoorBombed) 
            {
                game.ChangeRoom(((DoorBombed)collider.GameObject).next, ((DoorBombed)collider.GameObject).type);
            }
            else if(collider.GameObject is DoorLocked) 
            {
                doorLockedOptions(collider);
            }
        }

        private void doorLockedOptions(ICollider collider)
        {
            if (!((DoorLocked)collider.GameObject).getisUnlocked() && game.player.ItemCounts[ItemType.Key] > 0)
            {
                    ((DoorLocked)collider.GameObject).updateIsUnlocked();
                    game.player.ItemCounts[ItemType.Key]--;
                    game.ChangeRoom(((DoorLocked)collider.GameObject).next, ((DoorLocked)collider.GameObject).type);
            } else if(((DoorLocked)collider.GameObject).getisUnlocked())
            {
                game.ChangeRoom(((DoorLocked)collider.GameObject).next, ((DoorLocked)collider.GameObject).type);
            }
            
        }

        public void HandleWallCollision(ICollider collider)
        {
            HandleGenericCollision(collider);
        }
    }
}
