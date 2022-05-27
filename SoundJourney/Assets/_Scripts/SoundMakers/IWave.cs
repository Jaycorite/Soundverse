using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWave 
{
    public WaveType GetType { get; set; }
    public double SignalValue(float cTime, float cFrequency);
}
