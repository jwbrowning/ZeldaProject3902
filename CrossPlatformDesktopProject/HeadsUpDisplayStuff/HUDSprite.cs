using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;

namespace CrossPlatformDesktopProject.HeadsUpDisplayStuff
{
    class HUDSprite : ISprite
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
        private float scale = 1.75f;

        public HUDSprite(Texture2D texture)
        {
            Texture = texture;
            Rows = 1;
            Columns = 1;
            startFrame = 0;
            totalFrames = 1;
            currentFrame = startFrame;
            frameCounter = 0;
            frameInterval = (int)(10f / 1);
            overlayColor = Color.White;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X - (int)(width * scale / 2f), (int)location.Y - (int)(height * scale / 2f), (int)(scale * width), (int)(scale * height));

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, overlayColor);
            spriteBatch.End();
        }
    }
}
