using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Sprint0;

namespace CrossPlatformDesktopProject.SoundManagement
{
    class SoundFactory
	{
		public SoundEffect sfxBombExplode;
		public SoundEffect sfxBombPlace;
		public SoundEffect sfxBoomerang;
		public SoundEffect sfxBossScream;
		public SoundEffect sfxCandle; //unused?
		private SoundEffect sfxDoorUnlock; //TODO - Doors not yet implemented
		public SoundEffect sfxEnemyDamage;
		public SoundEffect sfxEnemyDeath;
		private SoundEffect sfxHealthRestore; //unused?
		public SoundEffect sfxHeartKeyPickup;
		private SoundEffect sfxHiddenKeyAppears; //TODO - enemy death not yet implemented
		public SoundEffect sfxItemPickup;
		private SoundEffect sfxLinkDamage;
		private SoundEffect sfxLinkDeath;
		private SoundEffect sfxLowHealthBeep;
		public SoundEffect sfxNewItem;
		public SoundEffect sfxRupeePickup;
		private SoundEffect sfxSecret;
		private SoundEffect sfxShieldBlock;
		private SoundEffect sfxStairs;
		public SoundEffect sfxSword;
		public SoundEffect sfxSwordBeam;
		private SoundEffect sfxTextAppears;


		private static SoundFactory instance = new SoundFactory();
		public static SoundFactory Instance
		{
			get
			{
				return instance;
			}
		}
		public SoundFactory()
		{
		}

		public void LoadAllSounds(ContentManager content)
		{
			sfxBombExplode = content.Load<SoundEffect>("Audio/sfxBombExplode");
			sfxBombPlace = content.Load<SoundEffect>("Audio/sfxBombPlace");
			sfxBoomerang = content.Load<SoundEffect>("Audio/sfxBoomerang");
			sfxBossScream = content.Load<SoundEffect>("Audio/sfxBossScream");
			sfxCandle = content.Load<SoundEffect>("Audio/sfxCandle");
			sfxDoorUnlock = content.Load<SoundEffect>("Audio/sfxDoorUnlock");
			sfxEnemyDamage = content.Load<SoundEffect>("Audio/sfxEnemyDamage");
			sfxEnemyDeath = content.Load<SoundEffect>("Audio/sfxEnemyDeath");
			sfxHealthRestore = content.Load<SoundEffect>("Audio/sfxHealthRestore");
			sfxHeartKeyPickup = content.Load<SoundEffect>("Audio/sfxHeartKeyPickup");
			sfxHiddenKeyAppears = content.Load<SoundEffect>("Audio/sfxHiddenKeyAppears");
			sfxItemPickup = content.Load<SoundEffect>("Audio/sfxItemPickup");
			sfxLinkDamage = content.Load<SoundEffect>("Audio/sfxLinkDamage");
			sfxLinkDeath = content.Load<SoundEffect>("Audio/sfxLinkDeath");
			sfxLowHealthBeep = content.Load<SoundEffect>("Audio/sfxLowHealthBeep");
			sfxNewItem = content.Load<SoundEffect>("Audio/sfxNewItem");
			sfxRupeePickup = content.Load<SoundEffect>("Audio/sfxRupeePickup");
			sfxSecret = content.Load<SoundEffect>("Audio/sfxSecret");
			sfxShieldBlock = content.Load<SoundEffect>("Audio/sfxShieldBlock");
			sfxStairs = content.Load<SoundEffect>("Audio/sfxStairs");
			sfxSword = content.Load<SoundEffect>("Audio/sfxSword");
			sfxSwordBeam = content.Load<SoundEffect>("Audio/sfxSwordBeam");
			sfxTextAppears = content.Load<SoundEffect>("Audio/sfxTextAppears");
		}


	}
}
