using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Environment
{
    class FloorTile : IBlock
    {
 
            public Texture2D Texture { get; set; }

            public FloorTile(Texture2D texture)
            {
                Texture = texture;
            }


            public void Draw(SpriteBatch spriteBatch, Vector2 location)
            {
                Rectangle sourceRectangle;
                Rectangle destinationRectangle;

                sourceRectangle = new Rectangle(984, 11, 16, 16);
                destinationRectangle = new Rectangle(200, 200, 50, 50);

                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
}
