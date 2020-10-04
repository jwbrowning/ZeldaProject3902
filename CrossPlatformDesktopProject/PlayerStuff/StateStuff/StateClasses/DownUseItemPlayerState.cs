using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class DownUseItemPlayerState : IPlayerState
    {
        private IPlayer player;

        public DownUseItemPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateDownUseItemLinkSprite();
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
            player.State = new DownStillPlayerState(player);
        }
    }
}
