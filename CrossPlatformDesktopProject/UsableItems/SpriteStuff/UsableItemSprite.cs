using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.UsableItems
{
    class UsableItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Color overlayColor;
        private int startFrame;
        private int totalFrames;
        private int currentFrame;
        private int frameCounter;
        private int frameInterval;
        private int scale = 4;

        public UsableItemSprite(Texture2D texture, int rows, int columns, int start, int total, float speed)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            startFrame = start;
            totalFrames = total;
            currentFrame = startFrame;
            frameCounter = 0;
            frameInterval = (int)(10f / speed);
            overlayColor = Color.White;
        }

        public void Update()
        {
            frameCounter++;
            if (frameCounter >= frameInterval)
            {
                frameCounter = 0;

                currentFrame++;
                if (currentFrame >= startFrame + totalFrames)
                {
                    currentFrame = startFrame;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - width * scale / 2, (int)location.Y - height * scale / 2, scale * width, scale * height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, overlayColor);
            spriteBatch.End();
        }
    }
}
