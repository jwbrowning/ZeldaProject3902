using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
	interface ISprite
	{
		void Update();

		void Draw(SpriteBatch sprteBatch, Vector2 location);
	}
}
