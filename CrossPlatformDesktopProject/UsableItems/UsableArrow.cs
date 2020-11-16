using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableArrow : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 direction;
        private float speed = 10f;
        private IPlayer player;
        private int timer = 300;

        public UsableArrow(Vector2 position, Vector2 direction, IPlayer player)
        {
            Position = position;
            this.player = player;
            this.direction = direction;
            if (direction == Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateRightArrowSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, 32, 8, 0, 0);
            }
            else if (direction == -Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateLeftArrowSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, 32, 8, 0, 0);
            }
            else if (direction == Vector2.UnitY)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateDownArrowSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, 8, 32, 0, 0);
            }
            else
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateUpArrowSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, 8, 32, 0, 0);
            }
            this.player.ItemCounts[ItemType.Arrow]--;
        }

        public void Update()
        {
            if (timer > 0)
            {
                timer--;
                Position += direction * speed;
                Sprite.Update();
            }
            else
            {
                if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Sprite.Draw(spriteBatch, parentPos + Position);
        }
    }
}
