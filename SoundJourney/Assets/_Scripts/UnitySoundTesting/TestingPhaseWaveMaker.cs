using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundMakers;

[RequireComponent(typeof(AudioSource))]
public class TestingPhaseWaveMaker : MonoBehaviour
{
    public float gain = 0.5F;
    public float frequency = 440f;
    //private double nextTick = 0.0F;
    //private float amp = 0.0F;
    private double phase = 0.0F;
    private WaveCalculator waveCalc;
    public WaveType wType =  WaveType.Sine;
    private double increment;

    private double sampleRate;  // samples per second
                                //private double myDspTime;	// dsp time
    private double dataLen;     // the data length of each channel
    double chunkTime;
    double dspTimeStep;
    double currentDspTime;




    private bool running = false;

    private void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        running = true;
        waveCalc = new WaveCalculator();
        
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        
        increment = frequency * 2 * Math.PI / sampleRate;

        dataLen = data.Length / channels;

        currentDspTime = AudioSettings.dspTime;
        dataLen = data.Length / channels;   // the actual data length for each channel
        chunkTime = dataLen / sampleRate;   // the time that each chunk of data lasts
        dspTimeStep = chunkTime / dataLen;

        double preciseDspTime;
        for (int n = 0; n < dataLen; n++)
        {
            //float x = gain * (float)waveCalc.WaveAtPhase((float)phase, wType);
            preciseDspTime = currentDspTime + n * dspTimeStep;
            double x = 0;

            x = gain * waveCalc.WaveAtTime(frequency, preciseDspTime, wType);
            //Debug.Log(x);
            /*for (int i = 0; i < channels; i++)
            {
                data[n + dataLen * i] += x;
                Debug.Log(n + dataLen * i);
            }*/
            //Debug.Log(phase);
            for (int i = 0; i < channels; i++)
            {
                data[n * channels + i] = (float)x;
            }

            
            phase += increment;

            
        }


        /*int n = 0;
         * while (n < dataLen)
        {
            
            
            float x = gain * (float) waveCalc.WaveAtPhase((float)phase, wType);
            Debug.Log("phase: " + phase + "   x: " + x);
            int i = 0;
            data[n] = x;
            if(channels == 2)
                data[n + dataLen] = x;
            
            phase += increment;
            if (phase > 2 * Math.PI)
                phase = 0;
            n++;
        }*/
    }
}
/*while (n > dataLen)
        {
            float x = (float)waveCalc.WaveAtPhase(phase, wType);
            int i = 0;
            while (i < channels)
            {
                data[n * channels + i] += x;
                i++;
            }
            
            n++;
        }*/

/*
float x = gain * (float)waveCalc.WaveAtTime(frequency, sample, wType);
Debug.Log(x);
int i = 0;
while (i < channels)
{
    data[n * channels + i] += x;
    i++;
}

n++;*/