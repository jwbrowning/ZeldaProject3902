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
		private SoundEffect sfxBombExplode;
		private SoundEffect sfxBombPlace;
		private SoundEffect sfxBoomerang;
		private SoundEffect sfxBossScream;
		private SoundEffect sfxCandle;
		private SoundEffect sfxDoorUnlock;
		private SoundEffect sfxEnemyDamage;
		private SoundEffect sfxEnemyDeath;
		private SoundEffect sfxHealthRestore; //unused?
		private SoundEffect sfxHeartKeyPickup;
		private SoundEffect sfxHiddenKeyAppears;
		private SoundEffect sfxItemPickup;
		private SoundEffect sfxLinkDamage;
		private SoundEffect sfxLinkDeath;
		private SoundEffect sfxLowHealthBeep;
		private SoundEffect sfxNewItem;
		private SoundEffect sfxRupeePickup;
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

			sfxSword = content.Load<SoundEffect>("Audio/sfxSword");
			sfxSwordBeam = content.Load<SoundEffect>("Audio/sfxSwordBeam");
		}


	}
}
