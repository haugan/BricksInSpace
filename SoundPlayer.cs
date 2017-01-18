using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BricksInSpace
{
    class SoundPlayer
    {
        System.Media.SoundPlayer missileSFX;
        System.Media.SoundPlayer enemyHitSFX;
        System.Media.SoundPlayer pauseSFX;
        System.Media.SoundPlayer gameOverMusic;

        public SoundPlayer()
        {
            InitSoundPlayers();
        }

        private void InitSoundPlayers()
        {
            missileSFX = new System.Media.SoundPlayer(Properties.Resources.smw_fireball2);
            enemyHitSFX = new System.Media.SoundPlayer(Properties.Resources.smw_stomp2);
            pauseSFX = new System.Media.SoundPlayer(Properties.Resources.smw_yoshi_stomp2);
            gameOverMusic = new System.Media.SoundPlayer(Properties.Resources.music_shadowgate2);
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
