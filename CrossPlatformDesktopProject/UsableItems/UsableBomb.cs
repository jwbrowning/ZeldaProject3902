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
    class UsableBomb : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        private IPlayer player;
        private int timeTillExplosion = 50;
        private int timeTillDone = 25;

        public UsableBomb(Vector2 position, IPlayer player)
        {
            Position = position;
            this.player = player;
            Sprite = UsableItemSpriteFactory.Instance.CreateBombSprite();
        }

        public void Update()
        {
            if(timeTillExplosion > 0)
            {
                timeTillExplosion--;
                Sprite.Update();
            }
            else if(timeTillExplosion == 0)
            {
                timeTillExplosion--;
                Sprite.Update();
                Sprite = UsableItemSpriteFactory.Instance.CreateExplosionSprite();
            }
            else
            {
                timeTillDone--;
                Sprite.Update();
                if (timeTillDone<0)
                {
                    if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }
    }
}
