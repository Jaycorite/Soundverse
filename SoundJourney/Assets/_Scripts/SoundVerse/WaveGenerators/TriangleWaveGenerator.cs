using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class TriangleWaveGenerator : Wave
    {
        public TriangleWaveGenerator(string name, double freq) : base(name, freq)
        {
        }
        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            return Math.Asin(Math.Sin(dFreq)) * (2 / Math.PI);
        }
    }
}
