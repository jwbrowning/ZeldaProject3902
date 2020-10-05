using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Items;
using System;
using Sprint0;

public class SpriteBomb : IItem
{

	public Vector2 Position { get; set; }
	public ISprite Sprite { get; set; }
	public SpriteBomb()
	{
		Sprite = ItemSpriteFactory.Instance.CreateSpriteBomb();
	}
	public void Update()
	{

	}
	public void PickUp()
	{

	}
	public void Draw(SpriteBatch spriteBatch)
	{
		Sprite.Draw(spriteBatch, Position);
	}

}
