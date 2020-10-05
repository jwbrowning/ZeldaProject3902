using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff
{
    class DownStillPlayerState : IPlayerState
    {
        private IPlayer player;

        public DownStillPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateDownStillLinkSprite();
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
