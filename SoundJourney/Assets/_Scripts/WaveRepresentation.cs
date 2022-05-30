using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveRepresentation
{
    public string Name;
    public double Frequency;
    [Range(0f,1f)]
    public float Amp;
    public WType Type;
}

[System.Serializable]
public enum WType
{
    Sine,
    Square,
    Triangle,
    Saw,
    SawAnalog,
    Noise
}
