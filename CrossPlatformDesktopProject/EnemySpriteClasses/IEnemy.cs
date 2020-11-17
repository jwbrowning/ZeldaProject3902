using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{
    public interface IEnemy : IGameObject
    {
        Color OverlayColor { get; set; }
        string carriedLoot { get; set; }

        void TakeDamage();
        void Die();
    }
}
