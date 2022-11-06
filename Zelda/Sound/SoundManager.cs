﻿using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

//using Zelda.Interfaces;

namespace Zelda.Sound
{
    class SoundManager
    {
        private Song mainTheme;
        private SoundEffect arrowBoomerang;
        private SoundEffect bombBlow;
        private SoundEffect bombDrop;
        private SoundEffect bossHit;
        private SoundEffect bossScream1;
        private SoundEffect bossScream2;
        private SoundEffect bossScream3;
        private SoundEffect candle;
        private SoundEffect doorUnlock;
        private SoundEffect enemyDie;
        private SoundEffect enemyHit;
        private SoundEffect fanfare;
        private SoundEffect getHeart;
        private SoundEffect getItem;
        private SoundEffect getRupee;
        private SoundEffect keyAppear;
        private SoundEffect linkDie;
        private SoundEffect linkHurt;
        private SoundEffect lowHealth;
        private SoundEffect magicalRod;
        private SoundEffect rocorder;
        private SoundEffect refillLoop;
        private SoundEffect secret;
        private SoundEffect shield;
        private SoundEffect shore;
        private SoundEffect stairs;
        private SoundEffect swordCombined;
        private SoundEffect swordShoot;
        private SoundEffect swordSlash;
        private SoundEffect text;
        private SoundEffect textSlow;


        //private Song undergroundSong;
        //private Song overworldSong;
        //private Song starSong;
        private bool IsMuted = false;

        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundManager()
        {

        }

        public void Initialize(ContentManager content)
        {
            mainTheme = content.Load<Song>("SoundEffect\\LOZ_Main_Theme");
            arrowBoomerang = content.Load<SoundEffect>("SoundEffect\\LOZ_Arrow_boomerang");
            bombBlow = content.Load<SoundEffect>("SoundEffect\\LOZ_Bomb_Blow");
            bombDrop = content.Load<SoundEffect>("SoundEffect\\LOZ_Bomb_Drop");
            bossHit = content.Load<SoundEffect>("SoundEffect\\LOZ_Boss_Hit");
            bossScream1 = content.Load<SoundEffect>("SoundEffect\\LOZ_Boss_Scream1");
            bossScream2 = content.Load<SoundEffect>("SoundEffect\\LOZ_Boss_Scream2");
            bossScream3 = content.Load<SoundEffect>("SoundEffect\\LOZ_Boss_Scream3");
            candle = content.Load<SoundEffect>("SoundEffect\\LOZ_Candle");
            doorUnlock = content.Load<SoundEffect>("SoundEffect\\LOZ_Door_Unlock");
            enemyDie = content.Load<SoundEffect>("SoundEffect\\LOZ_Enemy_Die");
            enemyHit = content.Load<SoundEffect>("SoundEffect\\LOZ_Enemy_Hit");
            fanfare = content.Load<SoundEffect>("SoundEffect\\LOZ_Fanfare");
            getHeart = content.Load<SoundEffect>("SoundEffect\\LOZ_Get_Heart");
            getItem = content.Load<SoundEffect>("SoundEffect\\LOZ_Get_Item");
            getRupee = content.Load<SoundEffect>("SoundEffect\\LOZ_Get_Rupee");
            keyAppear = content.Load<SoundEffect>("SoundEffect\\LOZ_Key_Appear");
            linkDie = content.Load<SoundEffect>("SoundEffect\\LOZ_Link_Die");
            linkHurt = content.Load<SoundEffect>("SoundEffect\\LOZ_Link_Hurt");
            lowHealth = content.Load<SoundEffect>("SoundEffect\\LOZ_LowHealth");
            magicalRod = content.Load<SoundEffect>("SoundEffect\\LOZ_MagicalRod");
            rocorder = content.Load<SoundEffect>("SoundEffect\\LOZ_Recorder");
            refillLoop = content.Load<SoundEffect>("SoundEffect\\LOZ_Refill_Loop");
            secret = content.Load<SoundEffect>("SoundEffect\\LOZ_Secret");
            shield = content.Load<SoundEffect>("SoundEffect\\LOZ_Shield");
            shore = content.Load<SoundEffect>("SoundEffect\\LOZ_Shore");
            stairs = content.Load<SoundEffect>("SoundEffect\\LOZ_Stairs");
            swordCombined = content.Load<SoundEffect>("SoundEffect\\LOZ_Sword_Combined");
            swordShoot = content.Load<SoundEffect>("SoundEffect\\LOZ_Sword_Shoot");
            swordSlash = content.Load<SoundEffect>("SoundEffect\\LOZ_Sword_Slash");
            text = content.Load<SoundEffect>("SoundEffect\\LOZ_Text");
            textSlow = content.Load<SoundEffect>("SoundEffect\\LOZ_Text_Slow");

        }

        public void muteAndUnmute(bool Muted)
        {
            if (Muted)
            {
                MediaPlayer.Pause();
                IsMuted = true;
            }
            else
            {
                MediaPlayer.Resume();
                IsMuted = false;
            }
        }

        public void PlayLinkDieSound()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                linkDie.Play();
            }
        }

        public void PlayMainThemeSound()
        {
            if (!IsMuted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mainTheme);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayBombDropSound()
        {
            if (!IsMuted)
            {
                bombDrop.Play();
            }
        }
        public void PlayBombBlowSound()
        {
            if (!IsMuted)
            {
                bombBlow.Play();
            }
        }

        public void PlayArrowBoomerangSound()
        {
            if (!IsMuted)
            {
                arrowBoomerang.Play();
            }
        }

        public void PlaySwardCombinedSound()
        {
            if (!IsMuted)
            {
                swordCombined.Play();
            }
        }
        public void PlaySwarShootSound()
        {
            if (!IsMuted)
            {
                swordShoot.Play();
            }
        }

        public void PlayEnemyDieSound()
        {
            if (!IsMuted)
            {
                enemyDie.Play();
            }
        }
    }
}