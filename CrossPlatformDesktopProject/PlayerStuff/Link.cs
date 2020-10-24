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
    public enum ItemType
    {
        Rupee,
        Map,
        Key,
        HeartContainer,
        TriforcePiece,
        Boomerang,
        Bow,
        Heart,
        Arrow,
        Bomb,
        Fairy,
        Clock,
        Compass
    }
    class Link : IPlayer
    {
        public IPlayerState State { get; set; }
        public ISprite Sprite { get; set; }
        public List<IUsableItem> ActiveItems { get; set; }
        public Dictionary<ItemType, int> ItemCounts { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 MoveDirection { get; set; }
        private float speed = 5;
        private Game1 game;

        public Link(Game1 game)
        {
            this.game = game;
            State = new DownStillPlayerState(this);
            Position = Vector2.Zero;
            MoveDirection = Vector2.Zero;
            CollisionHandler = new LinkCollisionHandler(game, this, 56, 38, 0, 18);
            ActiveItems = new List<IUsableItem>();
            ItemCounts = new Dictionary<ItemType, int>();
            ItemCounts.Add(ItemType.Rupee, 0);
            ItemCounts.Add(ItemType.Map, 0);
            ItemCounts.Add(ItemType.Key, 0);
            ItemCounts.Add(ItemType.HeartContainer, 0);
            ItemCounts.Add(ItemType.TriforcePiece, 0);
            ItemCounts.Add(ItemType.Boomerang, 1);
            ItemCounts.Add(ItemType.Bow, 1);
            ItemCounts.Add(ItemType.Heart, 0);
            ItemCounts.Add(ItemType.Arrow, 20);
            ItemCounts.Add(ItemType.Bomb, 20);
            ItemCounts.Add(ItemType.Fairy, 0);
            ItemCounts.Add(ItemType.Clock, 0);
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

        public void PickUp(ItemType itemType, int count)
        {
            ItemCounts[itemType] += count;
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
            if (ItemCounts[ItemType.Bow] == 0) return;
            if (ItemCounts[ItemType.Arrow] <= 0) return;
            State.ShootArrow();
        }

        public void ThrowBoomerang()
        {
            if (ItemCounts[ItemType.Boomerang] - ActiveItems.FindAll((IUsableItem item) => item is UsableBoomerang).Count <= 0) return;
            State.ThrowBoomerang();
        }

        public void UseBomb()
        {
            if (ItemCounts[ItemType.Bomb] <= 0) return;
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
