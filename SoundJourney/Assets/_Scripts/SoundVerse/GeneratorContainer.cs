using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class GeneratorContainer : Wave
    {
        float amp;
        Wave wave;
        public GeneratorContainer(float amp, Wave wave):base(wave.ID,wave.Frequency)
        {
            this.amp = amp;
            this.wave = wave;
        }
        public override double SignalValue(float cTime)
        {
            return amp * wave.SignalValue(cTime);
        }
    }
}
