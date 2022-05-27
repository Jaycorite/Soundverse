using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundsData", menuName = "ScriptableObjects/SoundsHolder", order = 1)]
public class SoundsHolder : ScriptableObject
{
    public Dictionary<string, BaseSoundMaker> soundsMakers;


    public void Init()
    {
        soundsMakers = new();

        WaveGenerator sineWave = new WaveGenerator(WaveType.Sine);
        WaveGenerator sqrWave = new WaveGenerator(WaveType.Square);
        WaveGenerator sawWave = new WaveGenerator(WaveType.Saw);
        WaveGenerator sawAnaWave = new WaveGenerator(WaveType.SawAnalog);
        WaveGenerator triWave = new WaveGenerator(WaveType.Triangle);
        WaveGenerator noise = new WaveGenerator(WaveType.Noise);



        Envelope FastRiseAndFall = new Envelope(0.2f, 0.1f, 1f, 0.2f, 2f);
        Envelope SlowRiseFastFall = new Envelope(0.8f, 0.1f, 1f, 0.1f, 1.2f);
        Envelope BumBy = new Envelope(0.5f, 1f, 1f, 0.5f, 0.5f);

        List<(float, WaveGenerator)> windySound = new() { (0.8f, sineWave), (0.5f, sawAnaWave), (0.3f, noise) };

        List<(float, WaveGenerator)> sqrSound = new() { (0.8f, sqrWave), (0.5f, sawAnaWave), (0.5f, sawWave) };

        List<(float, WaveGenerator)> wooosh = new() { (0.05f, sineWave), (0.1f, noise), (0.1f, noise), (0.1f, noise), (0.05f, sawAnaWave) };

        GenericSoundMaker FastWindySound = new GenericSoundMaker(SlowRiseFastFall, windySound);

        GenericSoundMaker sqreSound = new GenericSoundMaker(FastRiseAndFall, sqrSound);

        GenericSoundMaker WooshSound = new GenericSoundMaker(BumBy, wooosh);

        Debug.Log(windySound.Count);
        soundsMakers.Add("fastWindySound", FastWindySound);
        soundsMakers.Add("sqrSound", sqreSound);
        soundsMakers.Add("woosh", WooshSound);
    }
    

}
