using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundMakers
{
    public interface IWave
    {
        public WaveType GetType { get; set; }
        public double SignalValue(float cTime, float cFrequency);
    }
}