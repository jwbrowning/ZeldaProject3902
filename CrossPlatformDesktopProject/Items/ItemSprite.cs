using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.Items
{
    public class ItemSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int startFrame;
        private int totalFrames;
        private int currentFrame;
        private int frameCounter;
        private int frameInterval;
        private int scale = 4;

        public ItemSprite(Texture2D texture,int rows, int columns, int start, int frames)
        {
            Texture = texture;
            Rows = 1;
            Columns = columns;
            startFrame = start;
            totalFrames = frames;
            currentFrame = 0;
            frameCounter = 0;
            frameInterval = 10;
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
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
