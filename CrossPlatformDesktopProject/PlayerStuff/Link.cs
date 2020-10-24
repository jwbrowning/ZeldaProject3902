using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.PlayerStuff.SpriteStuff;
using CrossPlatformDesktopProject.PlayerStuff.StateStuff;
using CrossPlatformDesktopProject.UsableItems;
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
        public List<IUsableItem> ActiveItems { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
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
            ActiveItems = new List<IUsableItem>();
            CollisionHandler = new LinkCollisionHandler(this, 64, 32, 0, 16);
        }

        public void Update()
        {
            Sprite.Update();
            Position += MoveDirection * speed;
            for(int i=0;i<ActiveItems.Count;i++)
            {
                ActiveItems[i].Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            LinkSprite s = (LinkSprite)Sprite;
            s.overlayColor = Color.White;
            Sprite = s;
            Sprite.Draw(spriteBatch,Position);
            for (int i = 0; i < ActiveItems.Count; i++)
            {
                ActiveItems[i].Draw(spriteBatch);
            }
        }

        public void TakeDamage()
        {
            game.player = new DamagedLink(this, game);
        }

        public void Attack()
        {
            State.Attack();
        }

        public void ShootArrow()
        {
            State.ShootArrow();
        }

        public void ThrowBoomerang()
        {
            State.ThrowBoomerang();
        }

        public void UseBomb()
        {
            State.UseBomb();
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
