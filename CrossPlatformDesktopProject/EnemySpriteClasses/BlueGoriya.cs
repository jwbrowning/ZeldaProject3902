using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint0
{
    class BlueGoriya : IEnemy
    {
        private IEntity spawnEffect, deathEffect;
        private int spawnTime = 25, deathTime = 25;
        private bool spawning = true, dying = false;
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        public string carriedLoot { get; set; }

        private int animationFrame = 1;
        private int movementFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        int directionCode = 0; //keeps track of which direction sprite should move. 0 is up, 1 is down, 2 is left, 3 is right.
        int patrolPhase = 0;
        int patrolFrame = 1;
        private IPlayer player;
        private Game1 game;
        private int health = 2;
        public bool boomerangThrown;
        int tileFrame = 1;
        Random rand = new Random();

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


        public BlueGoriya(Game1 game, Vector2 position)
        {
            spawnEffect = new ExplosionEffect(position);
            deathEffect = new DeathEffect(position);
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 2, 2);
            this.player = game.player;
            this.game = game;
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

            Vector2 position = player.Position;
            float playerPositionX = position.X;
            float playerPositionY = position.Y;

            if (tileFrame == 1 && boomerangThrown == false)
            {
                directionCode = rand.Next(4);
            }

            if (boomerangThrown == false)
            {
                tileFrame++;
            }

            animationFrame++;
            patrolFrame++;


            if (animationFrame == 20)
                animationFrame = 1;

            if (patrolFrame == 200)
                patrolFrame = 1;

            if (tileFrame == 32)
                tileFrame = 1;

            /*
            if (patrolPhase == 1) //default phase of enemies, is changed after the enemy "sees" link 
            {
                if (patrolFrame <= 100)
                {
                    directionCode = 0;
                }
                else if (patrolFrame > 100)
                {
                    directionCode = 1;
                }

                if (((spritePositionX - 10) <= playerPositionX && playerPositionX <= (spritePositionX + 10)) || ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10)))
                {
                    patrolPhase = 0;
                }

            }

            if (patrolPhase == 0 && boomerangThrown == false)
            {
                if ((spritePositionX - 10) <= playerPositionX && playerPositionX <= (spritePositionX + 10))
                {
                    if (playerPositionY < spritePositionY)
                    {
                        directionCode = 0;

                        if (spritePositionY - playerPositionY <= 300 && boomerangThrown == false)
                        {
                            game.currentRoom.Enemies.Add(new EnemyBoomerang(game, this, new Vector2(spritePositionX, spritePositionY), directionCode)); //is created when the goriya gets close enough to player
                            boomerangThrown = true;
                            directionCode = -1;
                        }
                    }
                    else if (playerPositionY > spritePositionY)
                    {
                        directionCode = 1;

                        if (playerPositionY - spritePositionY <= 300 && boomerangThrown == false)
                        {
                            game.currentRoom.Enemies.Add(new EnemyBoomerang(game, this, new Vector2(spritePositionX, spritePositionY), directionCode));
                            boomerangThrown = true;
                            directionCode = -1;
                        }
                    }
                }

                if ((spritePositionY - 10) <= playerPositionY && playerPositionY <= (spritePositionY + 10))
                {
                    if (playerPositionX < spritePositionX)
                    {
                        directionCode = 2;

                        if (spritePositionX - playerPositionX <= 300 && boomerangThrown == false)
                        {
                            game.currentRoom.Enemies.Add(new EnemyBoomerang(game, this, new Vector2(spritePositionX, spritePositionY), directionCode));
                            boomerangThrown = true;
                            directionCode = -1;
                        }
                    }
                    else if (playerPositionX > spritePositionX)
                    {
                        directionCode = 3;

                        if (playerPositionX - spritePositionX <= 300 && boomerangThrown == false)
                        {
                            game.currentRoom.Enemies.Add(new EnemyBoomerang(game, this, new Vector2(spritePositionX, spritePositionY), directionCode));
                            boomerangThrown = true;
                            directionCode = -1;
                        }
                    }
                }
            } */

            if (boomerangThrown == false)
            {
                if (tileFrame == 31)
                {
                    game.currentRoom.Enemies.Add(new EnemyBoomerang(game, this, new Vector2(spritePositionX + 32, spritePositionY + 32), directionCode));
                    boomerangThrown = true;
                    if (directionCode == 0)
                    {
                        directionCode = -4;
                    }
                    else if (directionCode == 1)
                    {
                        directionCode = -1;
                    }
                    else if (directionCode == 2)
                    {
                        directionCode = -2;
                    }
                    else if (directionCode == 3)
                    {
                        directionCode = -3;
                    }
                }
            }

            if (directionCode == 0)
            {
                spritePositionY = spritePositionY - 2;
            }
            else if (directionCode == 1)
            {
                spritePositionY = spritePositionY + 2;
            }
            else if (directionCode == 2)
            {
                spritePositionX = spritePositionX - 2;
            }
            else if (directionCode == 3)
            {
                spritePositionX = spritePositionX + 2;
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

            if (directionCode == 3)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(256, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == 0)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(240, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == 2)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(440, 53, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == 1)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(223, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == -1)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(223, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == -2)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(440, 53, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(422, 54, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == -3)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(256, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(273, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else if (directionCode == -4)
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(240, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(424, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }
            else
            {
                if (animationFrame >= 1 && animationFrame < 10)
                {
                    sourceRectangle = new Rectangle(223, 28, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else if (animationFrame >= 10)
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
                else
                {
                    sourceRectangle = new Rectangle(440, 124, 16, 16);
                    destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
                }
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, OverlayColor);
            spriteBatch.End();
        }
    }
}

