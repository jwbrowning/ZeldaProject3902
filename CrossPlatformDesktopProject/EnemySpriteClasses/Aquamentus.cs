﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class Aquamentus : IEnemy
    {
        private IEntity spawnEffect, deathEffect;
        private int spawnTime = 25, deathTime = 25;
        private bool spawning = true, dying = false;
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        public string carriedLoot { get; set; }
        private IPlayer player;
        private Game1 game;
        private int health = 6;
        private int animationFrame = 1;
        private int movementFrame = 1;
        int shootFireBall = 0;
        int fireballFrame = 1;

        private int spritePositionX = 600;
        private int spritePositionY = 200;


        private Vector2 size = new Vector2(75, 100);
        public Vector2 Position
        {
            get
            {
                return new Vector2(spritePositionX + size.X / 2f, spritePositionY + size.Y / 2f);
            }
            set
            {
                spritePositionX = (int)(value.X - size.X / 2f);
                spritePositionY = (int)(value.Y - size.Y / 2f);
            }
        }


        public Aquamentus(Game1 game, Vector2 position)
        {
            spawnEffect = new ExplosionEffect(position);
            deathEffect = new DeathEffect(position);
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureBosses;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 0);
            this.player = game.player;
            this.game = game;
        }

        public void TakeDamage()
        {
            health--;
            SoundFactory.Instance.sfxBossScream.Play();
            if (health <= 0)
            {
                Die();
            }
            else
            {
                game.currentRoom.Enemies[game.currentRoom.Enemies.IndexOf(this)] = new DamagedEnemy(this, game);
            }
        }

        public void Die()
        {
            if (!dying)
            {
                deathEffect = new DeathEffect(Position);
                dying = true;
                CollisionHandler = new EmptyCollisionHandler(this);
                SoundFactory.Instance.sfxEnemyDeath.Play();
                LootManagement.Instance.enemyDeathLootCheck(game.currentRoom, this);
            }
        }

        public void Update()
        {
            if (spawning)
            {
                spawnTime--;
                spawnEffect.Update();
                if (spawnTime <= 0)
                {
                    spawning = false;
                }
                return;
            }
            if (dying)
            {
                deathTime--;
                deathEffect.Update();
                if (deathTime <= 0)
                {
                    if (game.currentRoom.Enemies.Contains(this)) game.currentRoom.Enemies.Remove(this);
                }
                return;
            }

            animationFrame++;
            movementFrame++;
            fireballFrame++;


            if (animationFrame == 40)
                animationFrame = 1;

            if (fireballFrame == 70)
                fireballFrame = 1;

            if (movementFrame == 360)
            {
                movementFrame = 1;
            }

            if (movementFrame <= 90)
            {
                spritePositionX = spritePositionX - 1;
            }
            else if (movementFrame > 90 && movementFrame <= 180)
            {
                spritePositionY = spritePositionY + 1;
            }
            else if (movementFrame > 180 && movementFrame <= 270)
            {
                spritePositionX = spritePositionX + 1;
            }
            else if (movementFrame > 270)
            {
                spritePositionY = spritePositionY - 1;
            }

            if (fireballFrame == 25)//will periodically produce 3 fireballs at set intervals.
            {
                game.currentRoom.Enemies.Add(new Fireball(game, player, new Vector2(spritePositionX - 10, spritePositionY - 10), 0));
                game.currentRoom.Enemies.Add(new Fireball(game, player, new Vector2(spritePositionX - 10, spritePositionY - 0), 1));
                game.currentRoom.Enemies.Add(new Fireball(game, player, new Vector2(spritePositionX - 10, spritePositionY + 10), 2));
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            if (spawning)
            {
                spawnEffect.Draw(spriteBatch, parentPos);
                return;
            }
            if (dying)
            {
                deathEffect.Draw(spriteBatch, parentPos);
                return;
            }

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            if (animationFrame >= 1 && animationFrame < 10)
            {
                sourceRectangle = new Rectangle(1, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame >= 10 && animationFrame < 20)
            {
                sourceRectangle = new Rectangle(26, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame >= 20 && animationFrame < 30)
            {
                sourceRectangle = new Rectangle(51, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else if (animationFrame > 30)
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }
            else
            {
                sourceRectangle = new Rectangle(76, 11, 24, 32);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 75, 100);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}