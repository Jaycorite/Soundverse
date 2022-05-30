using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SoundMakers
{
    public class SoundMaker
    {
        private WaveGenerator waveGenerator;
        private Envelope enveLope;
        private float startTime = 0f;

        public float Frequency { get; set; } = 0.0f;
        public SoundMaker(Envelope env, float start)
        {
            enveLope = env;
            startTime = start;
            waveGenerator = new WaveGenerator();
        }
        public void StartNote(float start)
        {
            startTime = start;
            enveLope.playing = true;
            enveLope.stopped = false;
        }

        public void StopNote(float stop)
        {
            enveLope.StoppedTime = stop;
            enveLope.stopped = true;
            //enveLope.StopNote(stop);
        }
        public float GetSound(float cTime)
        {
            return enveLope.AmplitudeAtTime(cTime) * (float)waveGenerator.SignalValue(cTime, Frequency);
        }
        public float GetSound(float cTime, float aFrequency)
        {
            float envT = enveLope.AmplitudeAtTime(cTime);
            float sigT = (float)waveGenerator.SignalValue(cTime, aFrequency);


            return enveLope.AmplitudeAtTime(cTime) * (float)waveGenerator.SignalValue(cTime, aFrequency);
        }

        public bool Stopped()
        {
            return !enveLope.playing;
        }

    }
}