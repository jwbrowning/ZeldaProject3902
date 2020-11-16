using CrossPlatformDesktopProject.HeadsUpDisplayStuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject
{
    public class HeadsUpDisplay
    {
        private Game1 game;
        public HeaderInfo headerInfo;
        public InventoryInfo inventoryInfo;
        public Vector2 Position { get; set; }
        public Point Size { get; set; }
        private Vector2 normalPos;
        private Vector2 pausedPos;
        private bool inventoryOpen = false;
        private float lerpSpeed = .05f;
        private Vector2 titlePos = new Vector2(-100, -400);

        public HeadsUpDisplay(Game1 game, int rectX, int rectY)
        {
            this.game = game;
            Size = new Point(rectX, rectY);
            pausedPos = new Vector2(rectX / 2f, rectY / 2f);
            normalPos = new Vector2(rectX / 2f, -rectY / 2f + 190);
            Position = normalPos;
            headerInfo = new HeaderInfo(game, this);
            inventoryInfo = new InventoryInfo(game, this);
        }

        public void Update()
        {
            if (inventoryOpen)
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
            spriteBatch.Draw(game.rect, new Rectangle(new Point((int)(Position.X - Size.X / 2f), (int)(Position.Y - Size.Y / 2f)), Size), Color.Black);
            spriteBatch.End();
            headerInfo.Draw(spriteBatch);
            inventoryInfo.Draw(spriteBatch);
        }

        public void OpenInventory()
        {
            inventoryOpen = true;
        }

        public void CloseInventory()
        {
            inventoryOpen = false;
        }

        public void MoveSelectorUp()
        {
            inventoryInfo.MoveSelectorUp();
        }

        public void MoveSelectorDown()
        {
            inventoryInfo.MoveSelectorDown();
        }

        public void MoveSelectorLeft()
        {
            inventoryInfo.MoveSelectorLeft();
        }

        public void MoveSelectorRight()
        {
            inventoryInfo.MoveSelectorRight();
        }

        public void Select()
        {
            inventoryInfo.Select();
        }

    }
}
