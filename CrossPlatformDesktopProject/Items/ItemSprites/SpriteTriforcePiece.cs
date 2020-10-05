using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CrossPlatformDesktopProject.Items;
using System;
using Sprint0;

public class SpriteTriforcePiece : IItem
{

	public Vector2 Position { get; set; }
	public ISprite Sprite { get; set; }
	public SpriteTriforcePiece()
	{
		Sprite = ItemSpriteFactory.Instance.CreateSpriteTriforcePiece();
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
