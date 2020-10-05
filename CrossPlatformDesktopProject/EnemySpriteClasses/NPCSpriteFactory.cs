using CrossPlatformDesktopProject.Items;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDesktopProject.EnemySpriteClasses
{

    
    class NPCSpriteFactory
    {
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
			textureEnemies = content.Load<Texture2D>("NES - The Legend of Zelda - Dungeon Enemies");
			textureNPCs = content.Load<Texture2D>("The Legend of Zelda - NPCs");
			textureBosses = content.Load<Texture2D>("The Legend of Zelda - Bosses");
			blueKeeseSprite = new BlueKeese(textureEnemies);
			redKeeseSprite = new RedKeese(textureEnemies);
			blackGelSprite = new BlackGel(textureEnemies);
			blackZolSprite = new BlackZol(textureEnemies);
			stalfosSprite = new Stalfos(textureEnemies);
			blueGoriyaSprite = new BlueGoriya(textureEnemies);
			bladeTrapSprite = new BladeTrap(textureEnemies);
			ropeSprite = new Rope(textureEnemies);
			wallMasterSprite = new WallMaster(textureEnemies);
			oldManSprite = new OldMan(textureNPCs);
			merchantSprite = new Merchant(textureNPCs);
			flameSprite = new Flame(textureNPCs);
			aquamentusSprite = new Aquamentus(textureBosses);
			dodongoSprite = new Dodongo(textureBosses);

		}

		
	}
}
