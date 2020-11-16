using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableBoomerang : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 direction;
        private float speed = 6f;
        private IPlayer player;
        private int timer = 50;
        private float dist = 5;

        public UsableBoomerang(Vector2 position, Vector2 direction, IPlayer player)
        {
            Position = position;
            this.direction = direction;
            this.player = player;
            Sprite = UsableItemSpriteFactory.Instance.CreateBoomerangSprite();
            SoundFactory.Instance.sfxBoomerang.Play();
            CollisionHandler = new UsableItemCollisionHandler(player, this, 32, 32, 0, 0);
        }

        public void Update()
        {
            if (timer > 0)
            {
                Position += direction * speed;
                timer--;
                Sprite.Update();
            }
            else
            {
                if (Vector2.Distance(player.Position, Position) < dist)
                {
                    if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
                }
                else
                {
                    Vector2 tempDirection = player.Position - Position;
                    tempDirection.Normalize();
                    Position += tempDirection * speed;
                    Sprite.Update();
                }
            }
        }

        public void ComeBack()
        {
            timer = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            Sprite.Draw(spriteBatch, parentPos + Position);
        }
    }
}
