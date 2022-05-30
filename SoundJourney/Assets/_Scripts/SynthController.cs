using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class SynthController : MonoBehaviour
{
    [SerializeField]
    private WaveBuilder waveBuilder;
    [SerializeField]
    private EnvelopeHandler envHandler;
    private bool play = false;
    [Range(0f, 1f)]
    public float Mastervol = 0.5f;

    private double sampleRate;
    private double dataLen;
    double chunkTime;
    double dspTimeStep;
    double currentDspTime;

    private void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
    }
    void Update()
    {
        currentDspTime = AudioSettings.dspTime;
        Keyboard keyboard = Keyboard.current;
        if (keyboard.spaceKey.IsPressed() && !play)
        {
            envHandler.timer.TurnOn(currentDspTime);
            play = true;
        }
        else if (keyboard.spaceKey.IsPressed() && play)
        {
            envHandler.timer.UpdateTime(currentDspTime);
        }
        else if (play && !keyboard.spaceKey.IsPressed())
        {
            envHandler.timer.On = false;
            play = false;
        }
            
        
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        dataLen = data.Length / channels;
        currentDspTime = AudioSettings.dspTime;
        dataLen = data.Length / channels; 
        chunkTime = dataLen / sampleRate; 
        dspTimeStep = chunkTime / dataLen;

        double preciseDspTime;
        if (play)
        {
            for (int i = 0; i < dataLen; i++)
            {
                preciseDspTime = currentDspTime + i * dspTimeStep;
                double signalValue = 0.0;
                waveBuilder.waves.ForEach(w => signalValue += envHandler.env.SignalValue((float)preciseDspTime) * w.SignalValue((float)preciseDspTime));
                //signalValue += soundMakers[currentSoundMaker].SignalValueAtTime((float)preciseDspTime, f);
                signalValue = signalValue * Mastervol;
                for (int j = 0; j < channels; j++)
                {
                    data[i * channels + j] = (float)signalValue;
                }
            }
        }
    }
}
