using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class SawWaveGenerator : Wave
    {
        public SawWaveGenerator(string name, double freq) : base(name, freq) 
        {
        }
        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            return ((2.0 / Math.PI) * (Frequency * Math.PI * (cTime % (1.0 / Frequency))) - (Math.PI / 2.0));
        }
    }
}
