using CrossPlatformDesktopProject.HeadsUpDisplayStuff;
using CrossPlatformDesktopProject.PlayerStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject
{
    class HeadsUpDisplay
    {
        private Game1 game;
        private HeaderInfo headerInfo;
        private InventoryInfo inventoryInfo;
        public Vector2 Position { get; set; }
        public Point Size { get; set; }
        private Vector2 normalPos;
        private Vector2 pausedPos;
        private bool paused = false;
        private float lerpSpeed = .05f;
        private Vector2 titlePos = new Vector2(-100, -400);

        public HeadsUpDisplay(Game1 game, int rectX, int rectY)
        {
            this.game = game;
            Size = new Point(rectX, rectY);
            pausedPos = new Vector2(rectX / 2f, rectY / 2f);
            normalPos = new Vector2(rectX / 2f, -rectY/2f + 190);
            Position = normalPos;
            headerInfo = new HeaderInfo(game, this);
            inventoryInfo = new InventoryInfo(game, this);
        }

        public void Update()
        {
            if(paused)
            {
                Position = Vector2.Lerp(Position, pausedPos, lerpSpeed);
            }
            else
            {
                Position = Vector2.Lerp(Position, normalPos, lerpSpeed);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(game.rect, new Rectangle(new Point((int)(Position.X - Size.X/2f),(int)(Position.Y-Size.Y/2f)), Size), Color.Black);
            spriteBatch.DrawString(game.font, "PAUSED", Position + titlePos, Color.White);
            spriteBatch.End();
            headerInfo.Draw(spriteBatch);
            inventoryInfo.Draw(spriteBatch);
        }

        public void Pause()
        {
            paused = true;
        }

        public void Unpause()
        {
            paused = false;
        }

    }
}
