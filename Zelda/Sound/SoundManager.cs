using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

//using Zelda.Interfaces;

namespace Zelda.Sound
{
    public class SoundManager
    {
        private Song mainTheme;
        private SoundEffect arrowBoomerang;
        private SoundEffect bombBlow;
        private SoundEffect bombDrop;
        private SoundEffect bossHit;
        private SoundEffect bossScream1; //needwork
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
        private SoundEffect linkDie; //need work
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
        private SoundEffect achievement;

        private bool muted = false;

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
            achievement = content.Load<SoundEffect>("SoundEffect\\achievement");
        }

        public void ToggleMute()
        {
            muted = !muted;
            if (muted)
            {
                MediaPlayer.Pause();
            }
            else
            {
                MediaPlayer.Resume();
            }
        }

        public void Pause()
        {
            MediaPlayer.Pause();
            muted = true;
        }

        public void Resume()
        {
            MediaPlayer.Resume();
            muted = false;
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }

        private void PlaySound(SoundEffect soundEffect)
        {
            if (!muted)
            {
                soundEffect.Play();
            }
        }

        public void PlayLinkDieSound()
        {
            if (!muted)
            {
                MediaPlayer.Stop();
                linkDie.Play();
            }
        }

        public void PlayMainThemeSound()
        {
            if (!muted)
            {
                MediaPlayer.Stop();
                MediaPlayer.Play(mainTheme);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayBombDropSound()
        {
            PlaySound(bombDrop);
        }
        public void PlayBombBlowSound()
        {
            PlaySound(bombBlow);
        }

        public void PlayArrowBoomerangSound()
        {
            PlaySound(arrowBoomerang);
        }

        public void PlaySwardCombinedSound()
        {
            PlaySound(swordCombined);
        }
        public void PlaySwarShootSound()
        {
            PlaySound(swordShoot);
        }

        public void PlayEnemyDieSound()
        {
            PlaySound(enemyDie);
        }

        public void PlayBossHitSound()
        {
            PlaySound(bossHit);
        }

        public void PlayLinkHurtSound()
        {
            PlaySound(linkHurt);
        }

        public void PlayBossScream1Sound()
        {
            PlaySound(bossScream1);
        }

        public void PlayArrowSound()
        {
            PlaySound(arrowBoomerang);
        }

        public void PlayFireSound()
        {
            PlaySound(candle);
        }

        public void PlayDoorUnlockSound()
        {
            PlaySound(doorUnlock);
        }

        public void PlayGetHealthSound()
        {
            PlaySound(getHeart);
        }

        public void PlayGetItemSound()
        {
            PlaySound(getItem);
        }

        public void PlayItemAppearSound()
        {
            PlaySound(keyAppear);
        }

        public void PlayStairSound()
        {
            PlaySound(stairs);
        }

        public void PlaySecretSound()
        {
            PlaySound(secret);
        }

        public void PlayMenuClickSound()
        {
            PlaySound(getItem);
        }

        public void PlayAchievementSound()
        {
            PlaySound(achievement);
        }
    }
}