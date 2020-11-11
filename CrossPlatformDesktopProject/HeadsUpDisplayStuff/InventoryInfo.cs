using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class InventoryInfo
    {
        public Vector2 Position { get; set; }
        private Game1 game;
        private HeadsUpDisplay hud;
        private ISprite background;
        private Point mapCoverSize = new Point(450, 285);
        private Point mapCoverPos = new Point(115, 110);
        const int heartWidth = 28;

        public InventoryInfo(Game1 game, HeadsUpDisplay hud)
        {
            this.game = game;
            this.hud = hud;
            Position = new Vector2(0, -50);
            background = HUDSpriteFactory.Instance.CreateInventoryBackground();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = hud.Position + Position;
            background.Draw(spriteBatch, position);
            spriteBatch.Begin();
            if (game.player.ItemCounts[PlayerStuff.ItemType.Map] == 0)
            {
                spriteBatch.Draw(game.rect, new Rectangle(new Point(mapCoverPos.X - (int)(mapCoverSize.X / 2f) + (int)position.X, mapCoverPos.Y - (int)(mapCoverSize.Y / 2f) + (int)position.Y), mapCoverSize), Color.Black);
            }
            spriteBatch.End();
        }

    }
}
