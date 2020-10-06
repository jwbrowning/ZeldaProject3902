using CrossPlatformDesktopProject.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//sprites taken from https://www.spriters-resource.com/nes/legendofzelda/sheet/54720/, edited by M. Landwehr
public class ItemSpriteFactory
{

	private Texture2D SpriteArrows, SpriteBomb, SpriteBoomerang, SpriteBow, SpriteClock,
		SpriteCompass, SpriteFairy, SpriteHeartContainer, SpriteHearts, SpriteKey, 
		SpriteMap, SpriteRupees, SpriteTriforcePiece;
	private static ItemSpriteFactory instance = new ItemSpriteFactory();
	

	public static ItemSpriteFactory Instance
	{
		get
		{
			return instance;
		}
	}
	public ItemSpriteFactory()
	{
	}

	public void LoadAllTextures(ContentManager content)
    {
		SpriteArrows = content.Load<Texture2D>("SpriteArrows");
		SpriteBomb = content.Load<Texture2D>("SpriteBomb");
		SpriteBoomerang = content.Load<Texture2D>("SpriteBoomerang");
		SpriteBow = content.Load<Texture2D>("SpriteBow");
		SpriteClock = content.Load<Texture2D>("SpriteClock");
		SpriteCompass = content.Load<Texture2D>("SpriteCompass");
		SpriteFairy = content.Load<Texture2D>("SpriteFairy");
		SpriteHeartContainer = content.Load<Texture2D>("SpriteHeartContainer");
		SpriteHearts = content.Load<Texture2D>("UsableItems/SpriteHearts");
		SpriteKey = content.Load<Texture2D>("SpriteKey");
		SpriteMap = content.Load<Texture2D>("SpriteMap");
		SpriteRupees = content.Load<Texture2D>("SpriteRupees");
		SpriteTriforcePiece = content.Load<Texture2D>("SpriteTriforcePiece");

	}

	public ISprite CreateSpriteArrow()
	{
		return new ItemSprite(SpriteArrows, 1, 2, 0, 1) ;
	}
	public ISprite CreateSpriteBomb()
	{
		return new ItemSprite(SpriteBomb, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteBoomerang()
	{
		return new ItemSprite(SpriteBoomerang, 1, 2, 0, 1);
	}
	public ISprite CreateSpriteBow()
	{
		return new ItemSprite(SpriteBow, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteClock()
	{
		return new ItemSprite(SpriteClock, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteCompass()
	{
		return new ItemSprite(SpriteCompass, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteFairy()
	{
		return new ItemSprite(SpriteFairy, 1, 2, 0, 2);
	}
	public ISprite CreateSpriteHeartContainer()
	{
		return new ItemSprite(SpriteHeartContainer, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteHeart()
	{
		return new ItemSprite(SpriteHearts, 1, 2, 0, 2);
	}
	public ISprite CreateSpriteKey()
	{
		return new ItemSprite(SpriteKey, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteMap()
	{
		return new ItemSprite(SpriteMap, 1, 1, 0, 1);
	}
	public ISprite CreateSpriteRupee()
	{
		return new ItemSprite(SpriteRupees, 1, 2, 0, 2);
	}
	public ISprite CreateSpriteTriforcePiece()
	{
		return new ItemSprite(SpriteTriforcePiece, 1, 1, 0, 1);
	}
}
