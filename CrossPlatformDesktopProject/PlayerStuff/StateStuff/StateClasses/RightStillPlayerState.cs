using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff
{
    class RightStillPlayerState : IPlayerState
    {
        private IPlayer player;

        public RightStillPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = Vector2.Zero;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateRightStillLinkSprite();
            this.player.Sword = new EmptySword(this.player);
        }

        public void ShootArrow()
        {
            player.ActiveItems.Add(new UsableArrow(player.Position, Vector2.UnitX, player));
            player.State = new RightUseItemPlayerState(player);
        }

        public void UseBomb()
        {
            player.ActiveItems.Add(new UsableBomb(player.Position + 64 * Vector2.UnitX, player));
            player.State = new RightUseItemPlayerState(player);
        }

        public void ThrowBoomerang()
        {
            player.ActiveItems.Add(new UsableBoomerang(player.Position, Vector2.UnitX, player));
            player.State = new RightUseItemPlayerState(player);
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
            player.State = new RightAttackPlayerState(player);
        }

        public void FinishAction()
        {
            // No implementation
        }
    }
}
