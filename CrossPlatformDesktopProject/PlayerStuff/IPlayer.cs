using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    public interface IPlayer : IGameObject
    {
        IPlayerState State { get; set; }
        ISprite Sprite { get; set; }
        List<IUsableItem> ActiveItems { get; set; }
        Vector2 MoveDirection { get; set; }
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
