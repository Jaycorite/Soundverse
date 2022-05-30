using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public abstract class AmpManipulator : IWave
    {
        public string ID { get; set; }
        public List<(float, float)> AmpTimePoints;



        public abstract double SignalValue(float cTime);
    }
}
