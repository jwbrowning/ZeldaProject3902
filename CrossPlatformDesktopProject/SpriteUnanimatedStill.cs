using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint0
{
	class SpriteUnanimatedStill : ISprite
	{
		public Texture2D Texture { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }


		public SpriteUnanimatedStill(Texture2D texture)
		{
			Texture = texture;

		}
		public void Update()
		{
		}
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{
			int width = Texture.Width;
			int height = Texture.Height;

			Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
			Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

			spriteBatch.Begin();
			spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
			spriteBatch.End();
		}
	}
}
