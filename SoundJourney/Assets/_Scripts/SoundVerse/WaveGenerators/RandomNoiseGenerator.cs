using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundVerse
{
    public class RandomNoiseGenerator : Wave
    {
        Random random;

        public RandomNoiseGenerator(string name, double freq) : base(name, freq)
        {
            random = new Random();
        }

        public override double SignalValue(float cTime)
        {
            double dFreq = w(Frequency) * cTime;

            int max = int.MaxValue;
            double RandomValue = (double.Parse(random.Next().ToString()) / double.Parse(max.ToString())) * 2;

            double Normalised = RandomValue - 1;
            return Normalised;
        }

    }
}
