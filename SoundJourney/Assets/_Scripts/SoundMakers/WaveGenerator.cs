using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundMakers
{
    public class WaveGenerator : IWave
    {
        private WaveType wType;
        public int sawIt = 20;
        Random random = new Random();


        public WaveGenerator(WaveType type = WaveType.Sine)
        {
            wType = type;
        }
        WaveType IWave.GetType { get => wType; set => wType = value; }

        public double SignalValue(float cTime, float cFrequency)
        {
            double dFreq = w(cFrequency) * cTime;




            switch (wType)
            {
                case WaveType.Sine:
                    return Math.Sin(dFreq);
                case WaveType.Square:
                    return Math.Sin(dFreq) > 0 ? 1.0 : -1.0;
                case WaveType.Triangle:
                    return Math.Asin(Math.Sin(dFreq)) * (2 / Math.PI);
                case WaveType.Saw:
                    return ((2.0 / Math.PI) * (cFrequency * Math.PI * (cTime % (1.0 / cFrequency))) - (Math.PI / 2.0));
                case WaveType.SawAnalog:
                    double outPut = 0.0;
                    for (int i = 1; i < sawIt; i++)
                    {
                        outPut += (Math.Sin(i * dFreq)) / i;
                    }
                    return outPut * (2 / Math.PI);
                case WaveType.Noise:

                    int max = int.MaxValue;
                    double RandomValue = (double.Parse(random.Next().ToString()) / double.Parse(max.ToString())) * 2;

                    double Normalised = RandomValue - 1;
                    return Normalised;
                default:
                    return 0.0;
            }

            double w(double Hz)
            {
                return Hz * 2 * Math.PI;
            }
        }
    }

}