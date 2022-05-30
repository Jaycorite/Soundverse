using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class SawAnalogWaveGenerator : Wave
    {

        public int Iterations { get; private set; }

        public SawAnalogWaveGenerator(string name, double freq, int iterations = 10) : base(name, freq)
        {
            Iterations = iterations;
        }
        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            double outPut = 0.0;
            for (int i = 1; i < Iterations; i++)
            {
                outPut += (Math.Sin(i * dFreq)) / i;
            }
            return outPut * (2 / Math.PI);
        }

    }
}
