using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing.Imaging;

namespace Sprint0
{
	public interface ISprite
	{
		void Update();

        void Draw(SpriteBatch sprteBatch, Vector2 location);
	}
}
