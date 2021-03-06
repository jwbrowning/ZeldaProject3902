﻿using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;

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
            this.player.Sword = new EmptySword(this.player);
        }

        public void ShootArrow()
        {
            player.ActiveItems.Add(new UsableArrow(player.Position, Vector2.UnitY, player));
            player.State = new DownUseItemPlayerState(player);
        }

        public void UseBomb()
        {
            player.ActiveItems.Add(new UsableBomb(player.Position + 64 * Vector2.UnitY, player));
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
