using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
    class BladeTrap : IEnemy
    {
        private IEntity spawnEffect, deathEffect;
        private int spawnTime = 25, deathTime = 25;
        private bool spawning = true, dying = false;
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX;
        private int spritePositionY;

        private IPlayer player;
        private Game1 game;
        private int health = 1;
        int patrolPhase = 1;
        int patrolFrame = 1;
        int activeFrame = 1;
        bool resetting = false;
        int directionCode = -1; //keeps track of which direction sprite should move. 0 is up, 1 is down, 2 is left, 3 is right.
        int originalPositionX;
        int originalPositionY;

        private Vector2 size = new Vector2(60, 60);
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


        public BladeTrap(Game1 game, Vector2 position)
        {
            spawnEffect = new ExplosionEffect(position);
            deathEffect = new DeathEffect(position);
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 0);
            this.player = game.player;
            this.game = game;
            originalPositionX = spritePositionX;
            originalPositionY = spritePositionY;
        }

        public void TakeDamage()
        {
            health--;
            SoundFactory.Instance.sfxEnemyDamage.Play();
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

            Vector2 position = player.Position;
            float playerPositionX = position.X;
            float playerPositionY = position.Y;


            animationFrame++;
            patrolFrame++;

            if (animationFrame == 20)
                animationFrame = 1;




            if (patrolPhase == 1 && resetting == false) //default phase of enemies, is changed after the enemy "sees" link. Bladetrap stays still
            {
                Console.WriteLine(patrolPhase);

                if (((spritePositionX) <= playerPositionX && playerPositionX <= (spritePositionX + 40)) || ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10)))
                {
                    patrolPhase = 0;
                }
            }

            if (patrolPhase == 0 && resetting == false)
            {
                if ((spritePositionX) <= playerPositionX && playerPositionX <= (spritePositionX + 40))
                {
                    if (playerPositionY < spritePositionY)
                    {
                        directionCode = 0;
                    }
                    else if (playerPositionY > spritePositionY)
                    {
                        directionCode = 1;
                    }
                }

                if ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 30))
                {
                    if (playerPositionX < spritePositionX)
                    {
                        directionCode = 2;
                    }
                    else if (playerPositionX > spritePositionX)
                    {
                        directionCode = 3;
                    }
                }

            }

            if (!(patrolPhase == 1) && resetting == false)
            {
                activeFrame++;
            }

            if (activeFrame > 100 && resetting == false)
            {
                patrolPhase = 1;
                activeFrame = 1;
                resetting = true;
            }

            if (activeFrame > 1 && activeFrame <= 100 && resetting == false)
            {
                patrolPhase = -1;
            }

            if (resetting == true)
            {
                if (spritePositionX > originalPositionX)
                {
                    spritePositionX = spritePositionX - 2;
                }
                if (spritePositionX < originalPositionX)
                {
                    spritePositionX = spritePositionX + 2;
                }
                if (spritePositionY > originalPositionY)
                {
                    spritePositionY = spritePositionY - 2;
                }
                if (spritePositionY < originalPositionY)
                {
                    spritePositionY = spritePositionY + 2;
                }
            }



            if (directionCode == 0 && resetting == false)
            {
                spritePositionY = spritePositionY - 8;
            }
            else if (directionCode == 1 && resetting == false)
            {
                spritePositionY = spritePositionY + 8;
            }
            else if (directionCode == 2 && resetting == false)
            {
                spritePositionX = spritePositionX - 8;
            }
            else if (directionCode == 3 && resetting == false)
            {
                spritePositionX = spritePositionX + 8;
            }

            if (spritePositionX == originalPositionX && spritePositionY == originalPositionY)
            {
                resetting = false;
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

            sourceRectangle = new Rectangle(164, 59, 16, 16);
            destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

