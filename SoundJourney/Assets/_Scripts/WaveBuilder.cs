using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundVerse;

public class WaveBuilder : MonoBehaviour
{
    [SerializeField]
    SoundContainer sounds;
    public List<Wave> waves;

    // Start is called before the first frame update
    void Start()
    {
        waves = new();
        foreach(var s in sounds.waves)
        {
            waves.Add(BuildWave(s.Name, s.Frequency, s.Amp, s.Type));
        }

        waves.ForEach(w => Debug.Log(w.ID));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Wave BuildWave(string name, double frequency, float amp, WType wt)
    {
        switch (wt)
        {
            case WType.Sine:
                Wave siwave = new SineWaveGenerator(name, frequency);
                return new GeneratorContainer(amp, siwave);
            case WType.Square:
                Wave sqwave = new SquareWaveGenerator(name, frequency);
                return new GeneratorContainer(amp, sqwave);
            case WType.Triangle:
                Wave stwave = new TriangleWaveGenerator(name, frequency);
                return new GeneratorContainer(amp, stwave);
            case WType.Saw:
                Wave swwave = new SawWaveGenerator(name, frequency);
                return new GeneratorContainer(amp, swwave);
            case WType.SawAnalog:
                Wave sawave = new SawAnalogWaveGenerator(name, frequency);
                return new GeneratorContainer(amp, sawave);
            case WType.Noise:
                Wave nowave = new RandomNoiseGenerator(name, frequency);
                return new GeneratorContainer(amp, nowave);
            default:
                return null;
        }
    }
}
