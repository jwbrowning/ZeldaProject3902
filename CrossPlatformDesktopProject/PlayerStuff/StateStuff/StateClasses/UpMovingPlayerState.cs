using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses
{
    class UpMovingPlayerState : IPlayerState
    {
        private IPlayer player;

        public UpMovingPlayerState(IPlayer player)
        {
            this.player = player;
            this.player.MoveDirection = -Vector2.UnitY;
            this.player.Sprite = LinkSpriteFactory.Instance.CreateUpMovingLinkSprite();
            this.player.Sword = new EmptySword(this.player);
        }

        public void ShootArrow()
        {
            player.ActiveItems.Add(new UsableArrow(player.Position, -Vector2.UnitY, player));
            player.State = new UpUseItemPlayerState(player);
        }

        public void UseBomb()
        {
            player.ActiveItems.Add(new UsableBomb(player.Position + 64 * -Vector2.UnitY, player));
            player.State = new UpUseItemPlayerState(player);
        }

        public void ThrowBoomerang()
        {
            player.ActiveItems.Add(new UsableBoomerang(player.Position, -Vector2.UnitY, player));
            player.State = new UpUseItemPlayerState(player);
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
            // No implementation
        }

        public void StopMoving()
        {
            player.State = new UpStillPlayerState(player);
        }

        public void Attack()
        {
            player.State = new UpAttackPlayerState(player);
        }

        public void FinishAction()
        {
            // No implementation
        }
    }
}
