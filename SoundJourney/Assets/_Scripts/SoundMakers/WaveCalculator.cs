using System;
using System.Collections;
using System.Collections.Generic;

public class WaveCalculator
{
    Random random = new Random();
    public double WaveAtPhase(float cPhase,WaveType waveType,int sawIt = 20)
    {
        switch (waveType)
        {
            case WaveType.Sine:
                return Math.Sin(cPhase);
            case WaveType.Square:
                return Math.Sin(cPhase) > 0 ? 1.0 : -1.0;
            case WaveType.Triangle:
                return Math.Asin(Math.Sin(cPhase)) * (2 / Math.PI);
            case WaveType.Saw:
                return ((2.0 / Math.PI) * (cPhase * Math.PI * (cPhase % 1)) - (Math.PI / 2.0));
            case WaveType.SawAnalog:
                double outPut = 0.0;
                for (int i = 0; i < sawIt; i++)
                {
                    outPut += (Math.Sin(i * cPhase)) / i;
                }
                return outPut * (2 / Math.PI);
            case WaveType.Noise:
                Random random = new Random();
                return 2.0 * (random.NextDouble() / double.MaxValue) - 1;
            default:
                return 0.0;
        }
    }

    public double WaveAtTime(double freq, double cTime, WaveType waveType, int sawIt = 20)
    {
        double dFreq = w(freq) * cTime;



        switch (waveType)
        {
            case WaveType.Sine:
                return Math.Sin(dFreq);
            case WaveType.Square:
                return Math.Sin(dFreq) > 0 ? 1.0 : -1.0;
            case WaveType.Triangle:
                return Math.Asin(Math.Sin(dFreq)) * (2 / Math.PI);
            case WaveType.Saw:
                return ((2.0 / Math.PI) * (freq * Math.PI * (cTime % (1.0 / freq))) - (Math.PI / 2.0));
            case WaveType.SawAnalog:
                double outPut = 0.0;
                for (int i = 1; i < sawIt; i++)
                {
                    outPut += (Math.Sin(i * dFreq)) / i;
                }
                return outPut * (2 / Math.PI);
            case WaveType.Noise:

                int max = int.MaxValue;
                double hmm = (double.Parse(random.Next().ToString()) / double.Parse(max.ToString()))*2;

                double hmmNum = hmm - 1;
                return hmmNum;
            default:
                return 0.0;
        }

    }
    private double w(double Hz)
    {
        return Hz * 2 * Math.PI;
    }

}
