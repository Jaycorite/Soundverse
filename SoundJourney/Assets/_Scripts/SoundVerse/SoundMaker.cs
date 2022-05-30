using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundVerse
{
    public class SoundMaker : WaveComposite
    {
        public override void AddWave(IWave wave)
        {
            Waves.Add(wave);
        }

        public override IWave GetWave(string waveID)
        {
            return Waves.Find(w => w.ID == waveID);
        }

        public override void RemoveWave(IWave wave)
        {
            Waves.RemoveAll(w => w.ID == wave.ID);
        }

        public override double SignalValue(float cTime)
        {
            double signalV = 0;
            for (int i = 1; i < Waves.Count; i++)
            {
                signalV += Waves[0].SignalValue(cTime) * Waves[i].SignalValue(cTime);
            }
            return signalV;
        }
    }
}
