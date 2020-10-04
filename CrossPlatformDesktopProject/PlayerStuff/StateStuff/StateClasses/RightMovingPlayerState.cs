using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class RightMovingPlayerState : IPlayerState
    {
        private IPlayer player;

        public RightMovingPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.UnitX;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateRightMovingLinkSprite();
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
            // No implementation
        }

        public void MoveUp()
        {
            player.State = new UpMovingPlayerState(player);
        }

        public void StopMoving()
        {
            player.State = new RightStillPlayerState(player);
        }

        public void Attack()
        {
            player.State = new RightAttackPlayerState(player);
        }

        public void UseItem()
        {
            player.State = new RightUseItemPlayerState(player);
        }

        public void FinishAction()
        {
            // No implementation
        }
    }
}
