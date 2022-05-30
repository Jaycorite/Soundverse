using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public abstract class WaveComposite : IWave
    {
        public string ID { get; set; }
        public List<IWave> Waves { get; private set; }

        public WaveComposite(List<IWave> initWaves = null)
        {
            if(initWaves != null)
            {
                Waves = initWaves;
            }
            else
            {
                Waves = new();
            }
        }
        public abstract void AddWave(IWave wave);
        public abstract IWave GetWave(string waveID);
        public abstract void RemoveWave(IWave wave);
        public abstract double SignalValue(float cTime);
    }
}
