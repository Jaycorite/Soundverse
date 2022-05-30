using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public interface IWave
    {
        public string ID { get; set; }
        public double SignalValue(float cTime);
    }
}
