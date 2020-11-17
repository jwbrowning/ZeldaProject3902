using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{
    public class DamagedEnemy : IEnemy
    {
        private IEnemy enemy;
        private int timer = 20;
        private Game1 game;

        public Color OverlayColor { get => enemy.OverlayColor; set => enemy.OverlayColor = value; }
        public Vector2 Position { get => enemy.Position; set => enemy.Position = value; }
        public ICollisionHandler CollisionHandler { get => enemy.CollisionHandler; set => enemy.CollisionHandler = value; }

        public DamagedEnemy(IEnemy enemy, Game1 game)
        {
            this.enemy = enemy;
            this.game = game;
        }

        public void Update()
        {
            timer -= 1;
            if (timer <= 0)
            {
                RemoveDecorator();
            }
            enemy.Update();
        }

        private void RemoveDecorator()
        {
            // call game1 method to replace this damagedenemy with enemy
            OverlayColor = Color.White;
            game.currentRoom.Enemies[game.currentRoom.Enemies.IndexOf(this)] = enemy;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 parentPos)
        {
            float value = 1.2f - timer / 20f;
            float r = ((timer / 8) % 2) * .5f + .5f;
            enemy.OverlayColor = new Color(r, value, r, .8f);
            enemy.Draw(spriteBatch, parentPos);
        }

        public void TakeDamage()
        {
            // can't take damage
        }

        public void Die()
        {

        }
    }
}
