using Microsoft.Xna.Framework;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    interface IPlayer : IGameObject
    {
        IPlayerState State { get; set; }
        ISprite Sprite { get; set; }
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void StopMoving();
        void Attack();
        void UseItem();
        void ShootArrow();
        void ThrowBoomerang();
        void UseBomb();
        void FinishAction();
    }
}
