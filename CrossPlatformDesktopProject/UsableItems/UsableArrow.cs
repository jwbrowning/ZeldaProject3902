using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableArrow : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        private Vector2 direction;
        private float speed = 10f;
        private IPlayer player;
        private int timer = 300;

        public UsableArrow(Vector2 position, Vector2 direction, IPlayer player)
        {
            Position = position;
            this.player = player;
            this.direction = direction;
            if(direction == Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateRightArrowSprite();
            }
            else if (direction == -Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateLeftArrowSprite();
            }
            else if (direction == Vector2.UnitY)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateDownArrowSprite();
            }
            else
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateUpArrowSprite();
            }
        }

        public void Update()
        {
            if(timer > 0)
            {
                timer--;
                Position += direction * speed;
                Sprite.Update();
            }
            else
            {
                if(player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }
    }
}
