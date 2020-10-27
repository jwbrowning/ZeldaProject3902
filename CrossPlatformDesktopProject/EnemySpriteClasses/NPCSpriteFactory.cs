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
			textureEnemies = content.Load<Texture2D>("NES_-_The_Legend_of_Zelda_-_Dungeon_Enemies"); //the three textures used for all enemies, bosses, NPCS, and their projectiles.
			textureNPCs = content.Load<Texture2D>("The_Legend_of_Zelda_-_NPCs");
			textureBosses = content.Load<Texture2D>("The_Legend_of_Zelda_-_Bosses");
			

		}

		
	}
}
