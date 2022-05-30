using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundMakers
{
    public class GenericSoundMaker : BaseSoundMaker
    {
        public GenericSoundMaker(Envelope env, List<(float, WaveGenerator)> wavesAndAmps) : base(env, wavesAndAmps)
        {
        }


    }
}
