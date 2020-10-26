using CrossPlatformDesktopProject.PlayerStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{
    public interface IEnemy : IGameObject
    {
        void TakeDamage();
        void Die();
    }
}
