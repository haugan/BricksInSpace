using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BricksInSpace
{
    class Audio
    {
        SoundPlayer missileSFX;
        SoundPlayer enemyHitSFX;
        SoundPlayer pauseSFX;
        SoundPlayer gameOverMusic;

        public Audio()
        {
            InitSoundPlayers();
        }

        private void InitSoundPlayers()
        {
            missileSFX = new SoundPlayer(Properties.Resources.smw_fireball2);
            enemyHitSFX = new SoundPlayer(Properties.Resources.smw_stomp2);
            pauseSFX = new SoundPlayer(Properties.Resources.smw_yoshi_stomp2);
            gameOverMusic = new SoundPlayer(Properties.Resources.music_shadowgate2);
        }

        public void PlayGameOverMusic()
        {
            gameOverMusic.PlayLooping();
        }

        public void PlayMissileSFX()
        {
            missileSFX.Play();
        }

        public void PlayEnemyHitSFX()
        {
            enemyHitSFX.Play();
        }

        public void PlayPauseSFX()
        {
            pauseSFX.Play();
        }

        public void StopGameOverMusic()
        {
            gameOverMusic.Stop();
        }
    }
}
