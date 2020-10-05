using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Environment
{
    class Statue : IBlock
    {
        public Texture2D Texture { get; set; }

        public Statue(Texture2D texture)
        {
            Texture = texture;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1018, 11, 16, 16);
            destinationRectangle = new Rectangle(200, 200, 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
