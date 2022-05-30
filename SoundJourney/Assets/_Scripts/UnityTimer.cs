using SoundVerse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTimer : AbstractTimer
{
    float startTime;
    float currentTime;
    
    public UnityTimer(float sTime)
    {
        startTime = sTime;
        currentTime = startTime;
    }
    public override float CurrentTime()
    {
        return currentTime;
    }
    public override float StartTime()
    {
        return startTime;
    }
    public override void UpdateTime(float cTime)
    {
        currentTime = cTime;
    }
}
