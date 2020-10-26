﻿using CrossPlatformDesktopProject.CollisionStuff.CollisionHandlerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{
    public class DamagedEnemy : IEnemy
    {
        private IEnemy enemy;
        private int timer = 1000;
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
            timer-=9;
            if (timer <= 0)
            {
                RemoveDecorator();
            }
            enemy.Update();
        }

        private void RemoveDecorator()
        {
            // call game1 method to replace this damagedenemy with enemy
            game.currentRoom.Enemies[game.currentRoom.Enemies.IndexOf(this)] = enemy;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float value = 1.2f - timer / 1100f;
            float r = ((timer / 100) % 2) * .5f + .5f;
            enemy.OverlayColor = new Color(r, value, value);
            enemy.Draw(spriteBatch);
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