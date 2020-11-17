using CrossPlatformDesktopProject.CollisionStuff.ColliderStuff;
using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Environment;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.CollisionStuff
{
    class CollisionDetection
    {
        public static void DetectCollisions(List<IGameObject> allGameObjects)
        {
            for (int i = 0; i < allGameObjects.Count - 1; i++)
            {
                for (int j = i + 1; j < allGameObjects.Count; j++)
                {
                    Rectangle colliderRect1 = GetColliderRectangle(allGameObjects[i]);
                    Rectangle colliderRect2 = GetColliderRectangle(allGameObjects[j]);
                    Rectangle intersect = Rectangle.Intersect(colliderRect1, colliderRect2);
                    if (!intersect.IsEmpty && intersect.Size != Point.Zero)
                    {
                        CallRightCollisionMethod(allGameObjects[i].CollisionHandler, allGameObjects[j].CollisionHandler.Collider);
                        CallRightCollisionMethod(allGameObjects[j].CollisionHandler, allGameObjects[i].CollisionHandler.Collider);
                    }
                }
            }
        }

        private static void CallRightCollisionMethod(ICollisionHandler collisionHandler, ICollider collider)
        {
            if (collider.GameObject is IPlayer)
            {
                collisionHandler.HandlePlayerCollision(collider);
            }
            else if (collider.GameObject is IItem)
            {
                collisionHandler.HandlePickupItemCollision(collider);
            }
            else if (collider.GameObject is IUsableItem)
            {
                collisionHandler.HandleUsableItemCollision(collider);
            }
            else if (collider.GameObject is IBlock)
            {
                collisionHandler.HandleBlockCollision(collider);
            }
            else if (collider.GameObject is INPC)
            {
                collisionHandler.HandleNPCCollision(collider);
            }
            else if (collider.GameObject is IEnemy)
            {
                collisionHandler.HandleEnemyCollision(collider);
            }
            else if (collider.GameObject is ISword)
            {
                collisionHandler.HandleSwordCollision(collider);
            }
            else if (collider.GameObject is IDoor)
            {
                collisionHandler.HandleDoorCollision(collider);
            }
            else if (collider.GameObject is IWall)
            {
                collisionHandler.HandleWallCollision(collider);
            }
        }

        public static Rectangle GetColliderRectangle(IGameObject gameObject)
        {
            return new Rectangle((int)(gameObject.Position.X + gameObject.CollisionHandler.Collider.Offset.X - gameObject.CollisionHandler.Collider.Size.X / 2), (int)(gameObject.Position.Y + gameObject.CollisionHandler.Collider.Offset.Y - gameObject.CollisionHandler.Collider.Size.Y / 2), (int)gameObject.CollisionHandler.Collider.Size.X, (int)gameObject.CollisionHandler.Collider.Size.Y);
        }

        public static Rectangle GetColliderRectangle(IGameObject gameObject, Vector2 roomPos)
        {
            return new Rectangle((int)(roomPos.X + gameObject.Position.X + gameObject.CollisionHandler.Collider.Offset.X - gameObject.CollisionHandler.Collider.Size.X / 2), (int)(roomPos.Y + gameObject.Position.Y + gameObject.CollisionHandler.Collider.Offset.Y - gameObject.CollisionHandler.Collider.Size.Y / 2), (int)gameObject.CollisionHandler.Collider.Size.X, (int)gameObject.CollisionHandler.Collider.Size.Y);
        }
    }
}
