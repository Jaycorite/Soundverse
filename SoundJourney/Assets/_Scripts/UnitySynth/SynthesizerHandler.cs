using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using SoundMakers;
public class SynthesizerHandler : MonoBehaviour
{


    private bool playing = false;
    private bool stopped = false;
    List<InputControl> KeysPressed = new();
    List<float> FreqToPlay = new List<float>();
    
   
    public List<BaseSoundMaker> soundMakers = new List<BaseSoundMaker>();

    List<saveInfo> signalsToSave;

    public InputAction playNote;
    
    public int currentSoundMaker = 0;

    public float Frequency;
    private float PlayingFrequency;
    public SoundsHolder SoundsHolder;
    [Range(0f,1f)]
    public float Mastervol= 0.5f;







    private double sampleRate;  // samples per second
                                //private double myDspTime;	// dsp time
    private double dataLen;     // the data length of each channel
    double chunkTime;
    double dspTimeStep;
    double currentDspTime;


    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        SoundsHolder.Init();
        playNote.Enable();
        signalsToSave = new List<saveInfo>();
        Debug.Log(sampleRate * 10);
        InitTest();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(signalsToSave.Count);
        //Debug.Log(sampleRate*3);
        /*if (!playing && signalsToSave.Count > sampleRate*2)
        {
            Debug.Log(Application.persistentDataPath + "   PATH");
            StaticSaver.SaveStuff(signalsToSave, "signals" + currentDspTime);
            signalsToSave.Clear();
        }
        */
        sampleRate = AudioSettings.outputSampleRate;
        currentDspTime = AudioSettings.dspTime;

        foreach(var v in playNote.controls)
        {
            if (v.IsPressed() && !KeysPressed.Contains(v))
            {
                KeysPressed.Add(v);
            }
            else if(!v.IsPressed() && KeysPressed.Contains(v))
            {
                KeysPressed.Remove(v);
            }
        }
        //Debug.Log(KeysPressed.Count);

        if (KeysPressed.Count > 0 && !playing)
        {
            playing = true;
            stopped = false;
            PlayingFrequency = Frequency;
            soundMakers[currentSoundMaker].StartNote((float)currentDspTime);
            foreach (var key in KeysPressed)
            {
                switch (key.name)
                {
                    case "a":
                        AddFreqToList(Frequency);
                        break;
                    case "w":
                        PlayingFrequency = FrequencyIntervals(1);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "s":
                        PlayingFrequency = FrequencyIntervals(2);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "d":
                        PlayingFrequency = FrequencyIntervals(3);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "e":
                        PlayingFrequency = FrequencyIntervals(4);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "f":
                        PlayingFrequency = FrequencyIntervals(5);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "r":
                        PlayingFrequency = FrequencyIntervals(6);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "g":
                        PlayingFrequency = FrequencyIntervals(7);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "h":
                        PlayingFrequency = FrequencyIntervals(8);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "y":
                        PlayingFrequency = FrequencyIntervals(9);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "j":
                        PlayingFrequency = FrequencyIntervals(10);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "u":
                        PlayingFrequency = FrequencyIntervals(11);
                        AddFreqToList(PlayingFrequency);
                        break;
                }
            }
        }
        else if(!stopped && playing)
        {
            foreach (var key in KeysPressed)
            {
                switch (key.name)
                {
                    case "a":
                        AddFreqToList(Frequency);
                        break;
                    case "w":
                        PlayingFrequency = FrequencyIntervals(1);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "s":
                        PlayingFrequency = FrequencyIntervals(2);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "d":
                        PlayingFrequency = FrequencyIntervals(3);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "e":
                        PlayingFrequency = FrequencyIntervals(4);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "f":
                        PlayingFrequency = FrequencyIntervals(5);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "r":
                        PlayingFrequency = FrequencyIntervals(6);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "g":
                        PlayingFrequency = FrequencyIntervals(7);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "h":
                        PlayingFrequency = FrequencyIntervals(8);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "y":
                        PlayingFrequency = FrequencyIntervals(9);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "j":
                        PlayingFrequency = FrequencyIntervals(10);
                        AddFreqToList(PlayingFrequency);
                        break;
                    case "u":
                        PlayingFrequency = FrequencyIntervals(11);
                        AddFreqToList(PlayingFrequency);
                        break;
                }
            }
        }
        if(KeysPressed.Count == 0 && !stopped)
        {
            stopped = true;
            Debug.Log((float)AudioSettings.dspTime);
            soundMakers[currentSoundMaker].StopNote((float)AudioSettings.dspTime);
        }
    }

    /*public async void PlayerNote(InputAction.CallbackContext context)
    {
        InputControl con = context.control;
        playing = true;
        PlayingFrequency = Frequency;

        Debug.Log("Pressed");
        soundMakers[currentSoundMaker].StartNote((float)currentDspTime);

        Debug.Log((float)currentDspTime);

        switch (con.name)
        {
            case "a":
                AddFreqToList(Frequency);
                break;
            case "w":
                PlayingFrequency = FrequencyIntervals(1);
                AddFreqToList(PlayingFrequency);
                break;
            case "s":
                PlayingFrequency = FrequencyIntervals(2);
                AddFreqToList(PlayingFrequency);
                break;
            case "d":
                PlayingFrequency = FrequencyIntervals(3);
                AddFreqToList(PlayingFrequency);
                break;
            case "e":
                PlayingFrequency = FrequencyIntervals(4);
                AddFreqToList(PlayingFrequency);
                break;
            case "f":
                PlayingFrequency = FrequencyIntervals(5);
                AddFreqToList(PlayingFrequency);
                break;
            case "r":
                PlayingFrequency = FrequencyIntervals(6);
                AddFreqToList(PlayingFrequency);
                break;
            case "g":
                PlayingFrequency = FrequencyIntervals(7);
                AddFreqToList(PlayingFrequency);
                break;
            case "h":
                PlayingFrequency = FrequencyIntervals(8);
                AddFreqToList(PlayingFrequency);
                break;
            case "y":
                PlayingFrequency = FrequencyIntervals(9);
                AddFreqToList(PlayingFrequency);
                break;
            case "j":
                PlayingFrequency = FrequencyIntervals(10);
                AddFreqToList(PlayingFrequency);
                break;
            case "u":
                PlayingFrequency = FrequencyIntervals(11);
                AddFreqToList(PlayingFrequency);
                break;
        }


        if (!con.IsPressed())
        {
            soundMakers[currentSoundMaker].StopNote((float)AudioSettings.dspTime);
            Debug.Log((float)currentDspTime);
        }
    }*/


    private void OnAudioFilterRead(float[] data, int channels)
    {
        dataLen = data.Length / channels;

        currentDspTime = AudioSettings.dspTime;
        dataLen = data.Length / channels;   // the actual data length for each channel
        chunkTime = dataLen / sampleRate;   // the time that each chunk of data lasts
        dspTimeStep = chunkTime / dataLen;


        if (!soundMakers[currentSoundMaker].IsPlaying() && playing)
        {
            playing = false;
            FreqToPlay.Clear();
        }


        double preciseDspTime;
        if (playing)
        {
            for (int i = 0; i < dataLen; i++)
            {
                preciseDspTime = currentDspTime + i * dspTimeStep;
                double signalValue = 0.0;
                //Debug.Log(PlayingFrequency);

                foreach(float f in FreqToPlay)
                {
                    signalValue += soundMakers[currentSoundMaker].SignalValueAtTime((float)preciseDspTime, f);
                }
                signalValue = signalValue * Mastervol;
                //signalsToSave.Add(new saveInfo() { SignalVal = (float)signalValue, Time = (float)preciseDspTime});
                //signalValue += soundMakers[currentSoundMaker].GetSound((float)preciseDspTime, Frequency);
                for (int j = 0; j < channels; j++)
                {
                    data[i * channels + j] = (float)signalValue;
                }
                //Debug.Log(signalValue);
            }
        }
        

    }
    
    private float FrequencyIntervals(int i)
    {
        float basefrequency = Frequency;
        return basefrequency * MathF.Pow(2f, (i / 12f));
    }

    private void AddFreqToList(float freq)
    {
        if (!FreqToPlay.Contains(freq))
            FreqToPlay.Add(freq);
    }

    private void InitTest()
    {
        //Envelope envelope = new(0.2f, 0.9f, 1f, 0.9f, 1f);
        //SoundMaker soundtest = new SoundMaker(envelope, (float)currentDspTime);
        Debug.Log(SoundsHolder.soundsMakers.Count);

        foreach(var k in SoundsHolder.soundsMakers)
        {
            soundMakers.Add(k.Value);
        }
        
        soundMakers.Add(SoundsHolder.soundsMakers["sqrSound"]);
    }
    
}
