using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class LeftUseItemPlayerState : IPlayerState
    {
        private IPlayer player;

        public LeftUseItemPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateLeftUseItemLinkSprite();
            this.player.Sword = new EmptySword(this.player);
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
