using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using CrossPlatformDesktopProject.EnemySpriteClasses;
using CrossPlatformDesktopProject.Entities;
using CrossPlatformDesktopProject.Items;
using CrossPlatformDesktopProject.PlayerStuff;
using CrossPlatformDesktopProject.SoundManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    class RedKeese : IEnemy
    {
        private IEntity spawnEffect, deathEffect;
        private int spawnTime = 25, deathTime = 25;
        private bool spawning = true, dying = false;
        public Color OverlayColor { get; set; }
        public ICollisionHandler CollisionHandler { get; set; }
        public Texture2D Texture { get; set; }
        public string carriedLoot { get; set; }


        private int animationFrame = 1;
        private int spritePositionX = 500;
        private int spritePositionY = 300;
        private IPlayer player;
        private Game1 game;
        private int health = 1;

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


        public RedKeese(Game1 game, Vector2 position)
        {
            spawnEffect = new ExplosionEffect(position);
            deathEffect = new DeathEffect(position);
            OverlayColor = Color.White;
            Texture = NPCSpriteFactory.Instance.textureEnemies;
            Position = position;
            CollisionHandler = new EnemyCollisionHandler(game, this, size.X, size.Y, 0, 0);
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

            animationFrame++;

            if (animationFrame == 10)
                animationFrame = 1;

            if (playerPositionX < spritePositionX)
            {
                spritePositionX = spritePositionX - 2;
            }
            else if (playerPositionX > spritePositionX)
            {
                spritePositionX = spritePositionX + 2;
            }

            if (playerPositionY < spritePositionY)
            {
                spritePositionY = spritePositionY - 2;
            }
            else if (playerPositionY > spritePositionY)
            {
                spritePositionY = spritePositionY + 2;
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

            if (animationFrame >= 1 && animationFrame < 5)
            {
                sourceRectangle = new Rectangle(183, 27, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else if (animationFrame >= 5)
            {
                sourceRectangle = new Rectangle(201, 29, 14, 14);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }
            else
            {
                sourceRectangle = new Rectangle(183, 27, 16, 16);
                destinationRectangle = new Rectangle(spritePositionX, spritePositionY, 60, 60);
            }

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, new Rectangle(destinationRectangle.Location + new Point((int)parentPos.X, (int)parentPos.Y), destinationRectangle.Size), sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}

