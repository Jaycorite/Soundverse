using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public abstract class Wave : IWave
    {
        public string ID { get; set; }
        public double Frequency { get; set; }

        public Wave(string id, double freq)
        {
            ID = id;
            Frequency = freq;
        }
        public abstract double SignalValue(float cTime);


        public double w(double Hz)
        {
            return Hz * 2 * Math.PI;
        }
    }
}
