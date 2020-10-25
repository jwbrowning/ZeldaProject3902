using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.Environment
{
    class BlockSpriteFactory
    {

		public Texture2D environment;
		private static BlockSpriteFactory instance = new BlockSpriteFactory();


		public static BlockSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}
		public BlockSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			environment = content.Load<Texture2D>("SpriteArrows");
		}
	}
}
