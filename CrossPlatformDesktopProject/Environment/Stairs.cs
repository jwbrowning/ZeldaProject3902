using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CrossPlatformDesktopProject.Environment
{
    class Stairs : IBlock
    {
        public Texture2D Texture { get; set; }

        public Stairs(Texture2D texture)
        {
            Texture = texture;
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle;
            Rectangle destinationRectangle;

            sourceRectangle = new Rectangle(1036, 29, 14, 14);
            destinationRectangle = new Rectangle(200, 200, 50, 50);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
