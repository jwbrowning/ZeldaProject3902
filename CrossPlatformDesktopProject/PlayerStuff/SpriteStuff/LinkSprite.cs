using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.PlayerStuff.SpriteStuff
{
    public class LinkSprite : ISprite
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
        private IPlayer player;
        private bool loop;
        private int scale = 4;

        public LinkSprite(Texture2D texture, int rows, int columns, int start, int total, bool loop, float speed, IPlayer player = null)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            startFrame = start;
            totalFrames = total;
            currentFrame = startFrame;
            frameCounter = 0;
            frameInterval = (int)(10 / speed);
            this.player = player;
            this.loop = loop;
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
                    if(!loop)
                    {
                        Finish();
                    } else
                    {
                        currentFrame = startFrame;
                    }
                }
            }
        }

        void Finish()
        {
            if(player!=null) player.FinishAction();
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
