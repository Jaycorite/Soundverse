using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoundMakers
{
    public abstract class BaseSoundMaker
    {
        private List<(float, WaveGenerator)> waveGenerators;
        private Envelope envelope;
        private float startTime = 0f;
        public float Frequency { get; set; } = 0.0f;




        public BaseSoundMaker(Envelope env, List<(float, WaveGenerator)> wavesAndAmps)
        {
            envelope = env;
            waveGenerators = wavesAndAmps;
        }

        public virtual void StartNote(float cTime)
        {
            envelope.StartTime = cTime;
            envelope.playing = true;
            envelope.stopped = false;
        }

        public virtual void StopNote(float cTime)
        {
            envelope.StoppedTime = cTime;
            envelope.stopped = true;
        }

        public virtual float SignalValueAtTime(float cTime, float Freq = 440)
        {
            float signalValue = 0;
            foreach (var v in waveGenerators)
            {
                signalValue += v.Item1 * (float)v.Item2.SignalValue(cTime, Freq);
            }
            signalValue = signalValue * envelope.AmplitudeAtTime(cTime);
            return signalValue;
        }

        public bool IsPlaying()
        {
            return envelope.playing;
        }
    }
}