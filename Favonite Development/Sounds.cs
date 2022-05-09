using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace Favonite_Development
{
   public class Sounds
    {
        private SoundEffectInstance jumpSoundInstance;
        private SoundEffectInstance bulletSoundInstance;

        public void Initialize(SoundEffect jumpSound, SoundEffect bulletSound)
        {
            jumpSoundInstance = jumpSound.CreateInstance();
            bulletSoundInstance = bulletSound.CreateInstance();
        }

        public SoundEffectInstance JUMP
        {
            get { return jumpSoundInstance; }
        }

        public SoundEffectInstance SHOOT
        {
            get { return bulletSoundInstance; }
        }
    }
}
