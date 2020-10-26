using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{
    public interface IEnemy : IGameObject
    {
        Color OverlayColor { get; set; }
        void TakeDamage();
        void Die();
    }
}
