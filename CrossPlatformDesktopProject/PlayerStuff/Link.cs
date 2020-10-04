using CrossPlatformDesktopProject.PlayerStuff.StateStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff
{
    class Link : IPlayer
    {
        public IPlayerState State { get; set; }
        public ISprite Sprite { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 MoveDirection { get; set; }
        private float speed = 5; // play around with this
        private Game1 game;

        public Link(Game1 game)
        {
            this.game = game;
            State = new DownStillPlayerState(this);
            Position = Vector2.Zero;
            MoveDirection = Vector2.Zero;
        }

        public void Update()
        {
            Sprite.Update();
            Position += MoveDirection * speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch,Position);
        }

        public void Attack()
        {
            State.Attack();
        }

        public void ShootArrow()
        {
            
        }

        public void ThrowBoomerang()
        {

        }

        public void UseBomb()
        {

        }

        public void UseItem()
        {
            State.UseItem();
        }

        public void MoveUp()
        {
            State.MoveUp();
        }

        public void MoveDown()
        {
            State.MoveDown();
        }

        public void MoveLeft()
        {
            State.MoveLeft();
        }

        public void MoveRight()
        {
            State.MoveRight();
        }

        public void StopMoving()
        {
            State.StopMoving();
        }

        public void FinishAction()
        {
            State.FinishAction();
        }
    }
}
