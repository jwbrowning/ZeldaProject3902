using CrossPlatformDesktopProject.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatformDesktopProject.PlayerStuff;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{

    
    class NPCSpriteFactory
    {
		private IPlayer player;
		private BlueKeese blueKeeseSprite;
		private RedKeese redKeeseSprite;
		private BlackGel blackGelSprite;
		private BlackZol blackZolSprite;
		private Stalfos stalfosSprite;
		private BlueGoriya blueGoriyaSprite;
		private BladeTrap bladeTrapSprite;
		private Rope ropeSprite;
		private WallMaster wallMasterSprite;
		private OldMan oldManSprite;
		private Merchant merchantSprite;
		private Flame flameSprite;
		private Aquamentus aquamentusSprite;
		private Dodongo dodongoSprite;
		public Texture2D textureEnemies;
		public Texture2D textureNPCs;
		public Texture2D textureBosses;

		private static NPCSpriteFactory instance = new NPCSpriteFactory();
		public static NPCSpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}
		public NPCSpriteFactory()
		{
		}

		public void LoadAllTextures(ContentManager content)
		{
			textureEnemies = content.Load<Texture2D>("NES_-_The_Legend_of_Zelda_-_Dungeon_Enemies");
			textureNPCs = content.Load<Texture2D>("The_Legend_of_Zelda_-_NPCs");
			textureBosses = content.Load<Texture2D>("The_Legend_of_Zelda_-_Bosses");
			blueKeeseSprite = new BlueKeese(textureEnemies, player);
			redKeeseSprite = new RedKeese(textureEnemies, player);
			blackGelSprite = new BlackGel(textureEnemies, player);
			blackZolSprite = new BlackZol(textureEnemies, player);
			stalfosSprite = new Stalfos(textureEnemies, player);
			blueGoriyaSprite = new BlueGoriya(textureEnemies);
			bladeTrapSprite = new BladeTrap(textureEnemies);
			ropeSprite = new Rope(textureEnemies, player);
			wallMasterSprite = new WallMaster(textureEnemies, player);
			oldManSprite = new OldMan(textureNPCs);
			merchantSprite = new Merchant(textureNPCs);
			flameSprite = new Flame(textureNPCs);
			aquamentusSprite = new Aquamentus(textureBosses, player);
			dodongoSprite = new Dodongo(textureBosses, player);

		}

		
	}
}
