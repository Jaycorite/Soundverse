using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class SquareWaveGenerator : Wave
    {
        public SquareWaveGenerator(string name, double freq) : base(name, freq)
        {
        }
        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            return Math.Sin(dFreq) > 0 ? 1.0 : -1.0;
        }
    }
}
