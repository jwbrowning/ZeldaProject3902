using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.SoundManagement;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class LeftAttackPlayerState : IPlayerState
    {
        private IPlayer player;

        public LeftAttackPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateLeftSwordLinkSprite();
            this.player.Sword = new WoodenSword(this.player, -Vector2.UnitX);
            SoundFactory.Instance.sfxSword.Play();
            if (this.player.Health == this.player.TotalHealth)
            {
                if (player.ActiveItems.FindAll((IUsableItem item) => item is SwordBeam).Count > 0) return;
                IUsableItem swordBeam = new SwordBeam(this.player.Position + 16 * -Vector2.UnitX, -Vector2.UnitX, this.player);
                this.player.ActiveItems.Add(swordBeam);
                SoundFactory.Instance.sfxSwordBeam.Play();
            }
        }

        public void ShootArrow()
        {
            // No implementation
        }

        public void UseBomb()
        {
            // No implementation
        }

        public void ThrowBoomerang()
        {
            // No implementation
        }

        public void MoveDown()
        {
            // No implementation
        }

        public void MoveLeft()
        {
            // No implementation
        }

        public void MoveRight()
        {
            // No implementation
        }

        public void MoveUp()
        {
            // No implementation
        }

        public void StopMoving()
        {
            // No implementation
        }

        public void Attack()
        {
            // No implementation
        }

        public void FinishAction()
        {
            player.State = new LeftStillPlayerState(player);
        }
    }
}
