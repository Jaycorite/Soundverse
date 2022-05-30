using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class SineWaveGenerator : Wave
    {
        public SineWaveGenerator(string name, double freq) : base(name, freq)
        {
        }
        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            return Math.Sin(dFreq);
        }
    }
}
