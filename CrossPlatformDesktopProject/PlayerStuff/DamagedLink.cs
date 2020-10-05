using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    class DamagedLink : IPlayer
    {
        public IPlayerState State { get => player.State; set => player.State = value; }
        public ISprite Sprite { get => player.Sprite; set => player.Sprite = value; }
        public Vector2 MoveDirection { get => player.MoveDirection; set => player.MoveDirection = value; }
        public Vector2 Position { get => player.Position; set => player.Position = value; }
        private IPlayer player;
        private Game1 game;
        private int timer = 1000;

        public DamagedLink(IPlayer player, Game1 game)
        {
            this.player = player;
            this.game = game;
        }

        public void Attack()
        {
            player.Attack();
        }

        public void Update()
        {
            timer-=9;
            if(timer<=0)
            {
                RemoveDecorator();
            }
            player.Update();
        }

        private void RemoveDecorator()
        {
            game.player = player;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            LinkSprite s = (LinkSprite)Sprite;
            float value = 1.2f - timer / 1100f;
            float r = ((timer / 100)%2)*.5f+.5f;
            s.overlayColor = new Color(r, value, value);
            Sprite.Draw(spriteBatch, Position);
        }

        public void TakeDamage()
        {
            // Can't take damage
        }

        public void FinishAction()
        {
            player.FinishAction();
        }

        public void MoveDown()
        {
            player.MoveDown();
        }

        public void MoveLeft()
        {
            player.MoveLeft();
        }

        public void MoveRight()
        {
            player.MoveRight();
        }

        public void MoveUp()
        {
            player.MoveUp();
        }

        public void ShootArrow()
        {
            player.ShootArrow();
        }

        public void StopMoving()
        {
            player.StopMoving();
        }

        public void ThrowBoomerang()
        {
            player.ThrowBoomerang();
        }

        public void UseBomb()
        {
            player.UseBomb();
        }

        public void UseItem()
        {
            player.UseItem();
        }
    }
}
