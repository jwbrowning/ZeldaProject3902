using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class UpAttackPlayerState : IPlayerState
    {
        private IPlayer player;

        public UpAttackPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateUpSwordLinkSprite();
            this.player.Sword = new WoodenSword(this.player, -Vector2.UnitY);
            if (this.player.Health == this.player.TotalHealth)
            {
                IUsableItem swordBeam = new SwordBeam(this.player.Position + 16 * -Vector2.UnitY, -Vector2.UnitY, this.player);
                this.player.ActiveItems.Add(swordBeam);
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
            player.State = new UpStillPlayerState(player);
        }
    }
}
