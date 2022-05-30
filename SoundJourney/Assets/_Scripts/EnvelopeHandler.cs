using SoundVerse;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvelopeHandler : MonoBehaviour
{
    [SerializeField]
    
    List<EnvelopeValue> EnvelopeValues;
    public Envelope env;
    public Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        List<(float, float)> values = new();
        EnvelopeValues.ForEach(ev => values.Add(new(ev.amp, ev.time)));
        timer = new(AudioSettings.dspTime);
        env = new(values, ref timer);
        //Debug.Log(env.ID);
    }

    // Update is called once per frame
    void Update()
    {
        timer.UpdateTime(AudioSettings.dspTime);
        //Debug.Log(timer.CurrentTime());
        //Debug.Log(env.SignalValue((float)timer.CurrentTime()));
    }
}

[System.Serializable]
struct EnvelopeValue
{
    public float amp;
    public float time;
}
