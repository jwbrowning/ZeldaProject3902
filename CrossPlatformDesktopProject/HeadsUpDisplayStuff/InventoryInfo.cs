using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    public class InventoryInfo
    {
        public enum InventoryItem
        {
            Empty,
            Boomerang,
            Bow,
            Bomb
        }
        public Vector2 Position { get; set; }
        private Game1 game;
        private HeadsUpDisplay hud;
        private ISprite background;
        private ISprite selector;
        private Vector2 inventoryPos = new Vector2(28, -144);
        private Vector2 inventoryItemSize = new Vector2(86, 62);
        private ISprite compassMarker;
        private Vector2 compassMarkerA1Pos = new Vector2(43, 41);
        private Point mapCoverSize = new Point(450, 285);
        private Point mapCoverPos = new Point(115, 110);
        const int heartWidth = 28;
        private InventoryItem[,] inventoryItems = new InventoryItem[,]
        {
            { InventoryItem.Empty, InventoryItem.Empty, InventoryItem.Empty, InventoryItem.Empty },
            { InventoryItem.Empty, InventoryItem.Empty, InventoryItem.Empty, InventoryItem.Empty }
        };
        public InventoryItem selectedItem = InventoryItem.Empty;
        private Vector2 selectedItemPos = new Vector2(-192, -140);
        private Vector2 mapPos = new Vector2(-268, 80);
        private Vector2 compassPos = new Vector2(-268, 210);
        private Vector2 inventorySize = new Vector2(4, 2);
        const int totalInvSize = 8;
        private Vector2 selectorIndices = new Vector2(0, 0);

        public InventoryInfo(Game1 game, HeadsUpDisplay hud)
        {
            this.game = game;
            this.hud = hud;
            Position = new Vector2(0, -50);
            background = HUDSpriteFactory.Instance.CreateInventoryBackground();
            compassMarker = HUDSpriteFactory.Instance.CreateCompassMarker();
            selector = HUDSpriteFactory.Instance.CreateSelector();
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
            if(game.player.ItemCounts[PlayerStuff.ItemType.Map] > 0)
            {
                ISprite map = ItemSpriteFactory.Instance.CreateSpriteMap();
                map.Draw(spriteBatch, position + mapPos);
            }
            if (game.player.ItemCounts[PlayerStuff.ItemType.Compass] > 0)
            {
                ISprite compass = ItemSpriteFactory.Instance.CreateSpriteCompass();
                compass.Draw(spriteBatch, position + compassPos);
                if (game.rooms[game.roomIndex] != "RoomDEBUG")
                {
                    compassMarker.Draw(spriteBatch, position + compassMarkerA1Pos + RoomPosAdjustment(game.rooms[game.roomIndex]));
                }
                else
                {
                    compassMarker.Draw(spriteBatch, position + compassMarkerA1Pos + RoomPosAdjustment("RoomC1"));
                }
            }

            int index = 0;
            if(game.player.ItemCounts[PlayerStuff.ItemType.Bomb] > 0)
            {
                inventoryItems[index / 4, index % 4] = InventoryItem.Bomb;
                index++;
            }
            for (int i = 0; i < game.player.ItemCounts[PlayerStuff.ItemType.Bow] && index < totalInvSize; i++)
            {
                inventoryItems[index / 4, index % 4] = InventoryItem.Bow;
                index++;
            }
            for (int i = 0; i < game.player.ItemCounts[PlayerStuff.ItemType.Boomerang] && index < totalInvSize; i++)
            {
                inventoryItems[index / 4, index % 4] = InventoryItem.Boomerang;
                index++;
            }
            while (index < totalInvSize)
            {
                inventoryItems[index / 4, index % 4] = InventoryItem.Empty;
                index++;
            }

            for (int i=0;i<2;i++)
            {
                for(int j=0;j<4;j++)
                {
                    ISprite item = CorrectItemSprite(inventoryItems[i, j]);
                    if(item!=null) item.Draw(spriteBatch, position + new Vector2(inventoryItemSize.X * j, inventoryItemSize.Y * i) + inventoryPos);
                }
            }
            selector.Draw(spriteBatch, position + new Vector2(inventoryItemSize.X * selectorIndices.X, inventoryItemSize.Y * selectorIndices.Y) + inventoryPos);


            ISprite selectedItemSprite = CorrectItemSprite(selectedItem);
            if(selectedItemSprite!=null) selectedItemSprite.Draw(spriteBatch, position + selectedItemPos);
        }

        public ISprite CorrectItemSprite(InventoryItem item)
        {
            ISprite sprite = null;
            switch (item)
            {
                case InventoryItem.Bomb:
                    sprite = ItemSpriteFactory.Instance.CreateSpriteBomb();
                    break;
                case InventoryItem.Bow:
                    sprite = ItemSpriteFactory.Instance.CreateSpriteBow();
                    break;
                case InventoryItem.Boomerang:
                    sprite = ItemSpriteFactory.Instance.CreateSpriteBoomerang();
                    break;
                default:
                    //for testing, delete later
                    //sprite = ItemSpriteFactory.Instance.CreateSpriteBomb();
                    break;
            }
            return sprite;
        }

        private Vector2 RoomPosAdjustment(string roomName)
        {
            string coords = roomName.Substring(4);
            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            float xAdjust = Array.FindIndex(letters, x => x == coords[0]);
            xAdjust *= 16 * 1.75f;
            float yAdjust = int.Parse("" + coords[1]);
            yAdjust *= 16 * 1.75f;
            return new Vector2(xAdjust, yAdjust);
        }

        public void MoveSelectorUp()
        {
            selectorIndices.Y--;
            if (selectorIndices.Y < 0) selectorIndices.Y = 0;
        }

        public void MoveSelectorDown()
        {
            selectorIndices.Y++;
            if (selectorIndices.Y >= inventorySize.Y) selectorIndices.Y = inventorySize.Y - 1;
        }

        public void MoveSelectorLeft()
        {
            selectorIndices.X--;
            if (selectorIndices.X < 0) selectorIndices.X = 0;
        }

        public void MoveSelectorRight()
        {
            selectorIndices.X++;
            if (selectorIndices.X >= inventorySize.X) selectorIndices.X = inventorySize.X - 1;
        }

        public void Select()
        {
            selectedItem = inventoryItems[(int)selectorIndices.Y, (int)selectorIndices.X];
        }

    }
}
