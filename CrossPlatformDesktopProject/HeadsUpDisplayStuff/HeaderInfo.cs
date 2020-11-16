using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class HeaderInfo
    {
        public Vector2 Position { get; set; }
        private Game1 game;
        private HeadsUpDisplay hud;
        private ISprite background;
        private Vector2 heartsPos = new Vector2(180, 25);
        private Vector2 rupeeCountPos = new Vector2(-115, -40);
        private Vector2 keyCountPos = new Vector2(-115, 13);
        private Vector2 bombCountPos = new Vector2(-115, 42);
        private Point mapCoverSize = new Point(200, 100);
        private Point mapCoverPos = new Point(-400, -15);
        const int heartWidth = 28;

        public HeaderInfo(Game1 game, HeadsUpDisplay hud)
        {
            this.game = game;
            this.hud = hud;
            Position = new Vector2(0, hud.Size.Y / 2f - 95);
            background = HUDSpriteFactory.Instance.CreateHeaderBackground();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 position = hud.Position + Position;
            background.Draw(spriteBatch, position);
            for (int i = 0; i < game.player.Health; i++)
            {
                ISprite heart = HUDSpriteFactory.Instance.CreateHeart();
                Vector2 pos = position + heartsPos;
                pos.X += i * heartWidth;
                heart.Draw(spriteBatch, pos);
            }
            for (int i = game.player.Health; i < game.player.TotalHealth; i++)
            {
                ISprite heart = HUDSpriteFactory.Instance.CreateLostHeart();
                Vector2 pos = position + heartsPos;
                pos.X += i * heartWidth;
                heart.Draw(spriteBatch, pos);
            }
            spriteBatch.Begin();
            spriteBatch.DrawString(game.font, "x" + game.player.ItemCounts[PlayerStuff.ItemType.Rupee], position + rupeeCountPos, Color.White);
            spriteBatch.DrawString(game.font, "x" + game.player.ItemCounts[PlayerStuff.ItemType.Key], position + keyCountPos, Color.White);
            spriteBatch.DrawString(game.font, "x" + game.player.ItemCounts[PlayerStuff.ItemType.Bomb], position + bombCountPos, Color.White);
            if (game.player.ItemCounts[PlayerStuff.ItemType.Map] == 0)
            {
                spriteBatch.Draw(game.rect, new Rectangle(new Point(mapCoverPos.X + (int)position.X, mapCoverPos.Y + (int)position.Y), mapCoverSize), Color.Black);
            }
            spriteBatch.End();
        }

    }
}
