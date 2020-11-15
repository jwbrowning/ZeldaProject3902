using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableBomb : IUsableItem
    {
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; set; }
        private List<IEntity> explosionEffects;
        public ICollisionHandler CollisionHandler { get; set; }
        private IPlayer player;
        private int timeTillExplosion = 50;
        private int timeTillDone = 25;

        public UsableBomb(Vector2 position, IPlayer player)
        {
            Position = position;
            this.player = player;
            Sprite = UsableItemSpriteFactory.Instance.CreateBombSprite();
            SoundFactory.Instance.sfxBombPlace.Play();
            CollisionHandler = new UsableItemCollisionHandler(player, this, 32, 32, 0, 0);
            explosionEffects = new List<IEntity>();
            this.player.ItemCounts[ItemType.Bomb]--;
        }

        public void Update()
        {
            if (timeTillExplosion > 0)
            {
                timeTillExplosion--;
                Sprite.Update();
            }
            else if (timeTillExplosion == 0)
            {
                timeTillExplosion--;
                Sprite.Update();
                Explode();
            }
            else
            {
                timeTillDone--;
                Sprite.Update();
                foreach (IEntity entity in explosionEffects)
                {
                    entity.Update();
                }
                if (timeTillDone < 0)
                {
                    if (player.ActiveItems.Contains(this)) player.ActiveItems.Remove(this);
                }
            }
        }

        private void Explode()
        {
            explosionEffects.Add(new ExplosionEffect(Position));
            SoundFactory.Instance.sfxBombExplode.Play();
            for (int i = 0; i < 6; i++)
            {
                Vector2 adjust = Vector2.Transform(64 * Vector2.UnitX, Matrix.CreateRotationZ(i * (float)Math.PI / 3f));
                explosionEffects.Add(new ExplosionEffect(Position + adjust));
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (timeTillExplosion >= 0)
            {
                Sprite.Draw(spriteBatch, Position);
            }
            if (explosionEffects.Count > 0)
            {
                explosionEffects[0].Draw(spriteBatch);
                for (int i = 1; i < explosionEffects.Count; i++)
                {
                    if (timeTillDone % 2 == i % 2)
                    {
                        explosionEffects[i].Draw(spriteBatch);
                    }
                }
            }
        }
    }
}
