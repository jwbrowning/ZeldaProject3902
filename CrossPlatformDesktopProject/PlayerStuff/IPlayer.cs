using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Sprint0;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    public interface IPlayer : IGameObject
    {
        IPlayerState State { get; set; }
        ISprite Sprite { get; set; }
        List<IUsableItem> ActiveItems { get; set; }
        Dictionary<ItemType, int> ItemCounts { get; set; }
        Vector2 MoveDirection { get; set; }
        ISword Sword { get; set; }
        int Health { get; set; }
        int TotalHealth { get; set; }
        void PickUp(ItemType itemType, int count);
        void TakeDamage();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void Attack();
        void ShootArrow();
        void ThrowBoomerang();
        void UseBomb();
        void FinishAction();
    }
}
