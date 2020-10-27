﻿using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.StateStuff.StateClasses;
using CrossPlatformDesktopProject.PlayerStuff.SwordStuff;
using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;

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
