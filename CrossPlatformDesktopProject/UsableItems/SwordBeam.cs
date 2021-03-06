﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    class SwordBeam : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        private Vector2 direction;
        private float speed = 7.5f;
        private IPlayer player;
        private int timer = 310;
        private bool destroying;
        float destroyTime = 15;
        private IEntity effect;

        public SwordBeam(Vector2 position, Vector2 direction, IPlayer player)
        {
            Position = position;
            this.player = player;
            this.direction = direction;
            int beamLength = 64;
            int beamWidth = 24;
            if (direction == Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateRightSwordBeamSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, beamLength, beamWidth, 0, 0);
            }
            else if (direction == -Vector2.UnitX)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateLeftSwordBeamSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, beamLength, beamWidth, 0, 0);
            }
            else if (direction == Vector2.UnitY)
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateDownSwordBeamSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, beamWidth, beamLength, 0, 0);
            }
            else
            {
                Sprite = UsableItemSpriteFactory.Instance.CreateUpSwordBeamSprite();
                CollisionHandler = new UsableItemCollisionHandler(player, this, beamWidth, beamLength, 0, 0);
            }
        }

        public void Update()
        {
            if (destroying)
            {
                destroyTime--;
                effect.Update();
                if (destroyTime <= 0)
                {
                    if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
                }
                return;
            }
            if (timer > 300)
            {
                timer--;
            }
            else if (timer > 0)
            {
                timer--;
                Position += direction * speed;
                Sprite.Update();
            }
            else
            {
                Destroy();
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            if (destroying) effect.Draw(spriteBatch, parentPos);
            else if (timer <= 300) Sprite.Draw(spriteBatch, parentPos + Position);
        }

        public void Destroy()
        {
            if (!destroying)
            {
                CollisionHandler = new EmptyCollisionHandler(this);
                effect = new SplittingEffect(Position);
                destroying = true;
            }
        }
    }
}
