using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope
{
    public float AttackTime { get; private set; }
    public float DecayTime { get; private set; }
    public float SustatinAmp { get; private set; }
    public float ReleaseTime { get; private set; }
    public float StartAmp { get; private set; }

    public float StartTime { get; set; }
    public float StoppedTime { get; set; }

    public bool stopped = false;
    public bool playing = true;
    public Envelope(float attackTime, float decayTime, float sustainAmp, float releaseTime, float startAmp)
    {
        AttackTime = attackTime;
        DecayTime = decayTime;
        SustatinAmp = sustainAmp;
        ReleaseTime = releaseTime;
        StartAmp = startAmp;
        
    }

    public float AmplitudeAtTime(float cTime)
    {
        float Amp = 0;
        if (!stopped)
        {
            float timeOn = cTime - StartTime;
            //Debug.Log(startTime + "              ct: "  + cTime + "            tOn: " +timeOn);
            if (timeOn <= AttackTime)
                Amp = (timeOn / AttackTime) * StartAmp;
            else if (timeOn > AttackTime && timeOn <= (DecayTime + AttackTime))
                Amp = ((timeOn - AttackTime) / DecayTime) * (SustatinAmp - StartAmp) + StartAmp;
            else if (timeOn > (AttackTime + DecayTime))
                Amp = SustatinAmp;
        }
        else
        {
            float timeOff = cTime - StoppedTime;
            if (timeOff <= ReleaseTime)
            {
                //Debug.Log(SustatinAmp + "   in release  " + (timeOff / ReleaseTime)*SustatinAmp);
                Amp = SustatinAmp - ((timeOff / ReleaseTime) * SustatinAmp);
            }

            else if(timeOff > ReleaseTime)
            {
                //Debug.Log("out of release           " + Amp);
                playing = false;
            }
                //Amp = 0;
                
        }

        if (Amp <= 0.01)
            Amp = 0;
        //Debug.Log(Amp);
        return Amp;
    }

    
}
