using CrossPlatformDesktopProject.UsableItems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    public class HeaderInfo
    {
        public Vector2 Position { get; set; }
        private Game1 game;
        private HeadsUpDisplay hud;
        private ISprite background;
        private ISprite compassMarker;
        private Vector2 compassMarkerA1Pos = new Vector2(-205 * 1.75f, -11 * 1.75f);
        private Vector2 heartsPos = new Vector2(180, 25);
        private Vector2 rupeeCountPos = new Vector2(-115, -40);
        private Vector2 keyCountPos = new Vector2(-115, 13);
        private Vector2 bombCountPos = new Vector2(-115, 42);
        private Point mapCoverSize = new Point(200, 100);
        private Point mapCoverPos = new Point(-400, -15);
        const int heartWidth = 28;
        private Vector2 bItemPos = new Vector2(6, 22);
        private Vector2 aItemPos = new Vector2(90, 22);

        public HeaderInfo(Game1 game, HeadsUpDisplay hud)
        {
            this.game = game;
            this.hud = hud;
            Position = new Vector2(0, hud.Size.Y / 2f - 95);
            background = HUDSpriteFactory.Instance.CreateHeaderBackground();
            compassMarker = HUDSpriteFactory.Instance.CreateCompassMarker();
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

            if (game.player.ItemCounts[PlayerStuff.ItemType.Compass] > 0)
            {
                if (game.rooms[game.roomIndex] != "RoomDEBUG" && game.rooms[game.roomIndex] != "RoomBOW")
                {
                    compassMarker.Draw(spriteBatch, position + compassMarkerA1Pos + RoomPosAdjustment(game.rooms[game.roomIndex]));
                }
                else
                {
                    compassMarker.Draw(spriteBatch, position + compassMarkerA1Pos + RoomPosAdjustment("RoomB1"));
                }
            }

            ISprite bItemSprite = hud.inventoryInfo.CorrectItemSprite(hud.inventoryInfo.selectedItem);
            if (bItemSprite != null) bItemSprite.Draw(spriteBatch, position + bItemPos);

            ISprite aItemSprite = UsableItemSpriteFactory.Instance.CreateSwordSprite();
            aItemSprite.Draw(spriteBatch, position + aItemPos);
        }

        private Vector2 RoomPosAdjustment(string roomName)
        {
            string coords = roomName.Substring(4);
            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            float xAdjust = Array.FindIndex(letters, x => x == coords[0]);
            xAdjust *= 16 * 1.75f;
            float yAdjust = int.Parse("" + coords[1]);
            yAdjust *= 8 * 1.75f;
            return new Vector2(xAdjust, yAdjust);
        }

    }
}
