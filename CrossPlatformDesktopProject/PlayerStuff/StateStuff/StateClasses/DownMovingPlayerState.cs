using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class DownMovingPlayerState : IPlayerState
    {
        private IPlayer player;

        public DownMovingPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.UnitY;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateDownMovingLinkSprite();
        }

        public void ShootArrow()
        {
            player.ActiveItems.Add(new UsableArrow(player.Position, Vector2.UnitY, player));
            player.State = new DownUseItemPlayerState(player);
        }

        public void UseBomb()
        {
            player.ActiveItems.Add(new UsableBomb(player.Position, player));
            player.State = new DownUseItemPlayerState(player);
        }

        public void ThrowBoomerang()
        {
            player.ActiveItems.Add(new UsableBoomerang(player.Position, Vector2.UnitY, player));
            player.State = new DownUseItemPlayerState(player);
        }

        public void MoveDown()
        {
            // No implementation
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
            player.State = new DownStillPlayerState(player);
        }

        public void Attack()
        {
            player.State = new DownAttackPlayerState(player);
        }

        public void FinishAction()
        {
            // No implementation
        }
    }
}
