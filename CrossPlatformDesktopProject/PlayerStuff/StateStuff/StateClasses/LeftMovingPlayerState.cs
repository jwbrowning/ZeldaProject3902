using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class LeftMovingPlayerState : IPlayerState
    {
        private IPlayer player;

        public LeftMovingPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = -Vector2.UnitX;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateLeftMovingLinkSprite();
        }

        public void MoveDown()
        {
            player.State = new DownMovingPlayerState(player);
        }

        public void MoveLeft()
        {
            // No implementation
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
            player.State = new LeftStillPlayerState(player);
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
