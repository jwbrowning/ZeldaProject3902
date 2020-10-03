using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class RightUseItemPlayerState : IPlayerState
    {
        private IPlayer player;

        public RightUseItemPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateRightUseItemLinkSprite();
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

        public void UseItem()
        {
            // No implementation
        }

        public void FinishAction()
        {
            player.State = new RightStillPlayerState(player);
        }
    }
}
