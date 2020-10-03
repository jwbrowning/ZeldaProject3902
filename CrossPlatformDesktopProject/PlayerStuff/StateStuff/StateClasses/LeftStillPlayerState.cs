using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff
{
    class LeftStillPlayerState : IPlayerState
    {
        private IPlayer player;

        public LeftStillPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateLeftStillLinkSprite();
        }

        public void MoveDown()
        {
            player.State = new DownMovingPlayerState(player);
        }

        public void MoveLeft()
        {
            player.State = new LeftMovingPlayerState(player);
        }

        public void MoveRight()
        {
            player.State = new RightMovingPlayerState(player);
        }

        public void MoveUp()
        {
            player.State = new UpMovingPlayerState(player);
        }

        public void StopMoving()
        {
            // No implementation
        }

        public void Attack()
        {
            player.State = new LeftAttackPlayerState(player);
        }

        public void UseItem()
        {
            player.State = new LeftUseItemPlayerState(player);
        }

        public void FinishAction()
        {
            // No implementation
        }
    }
}
