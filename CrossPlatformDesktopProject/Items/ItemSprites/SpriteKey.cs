using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Items;
using System;
using Sprint0;

public class SpriteKey : IItem
{

	public Vector2 Position { get; set; }
	public ISprite Sprite { get; set; }
	public SpriteKey()
	{
		Sprite = ItemSpriteFactory.Instance.CreateSpriteKey();
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
