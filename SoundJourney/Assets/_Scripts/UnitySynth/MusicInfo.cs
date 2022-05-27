using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInfo : ScriptableObject
{

    public Dictionary<string, int> possibleNotes = new Dictionary<string, int>() {
        {"A", 0},
        { "A#", 1 },
        { "B", 2 },
        { "C", 3 },
        { "C#", 4 },
        { "D", 5 },
        { "D#", 6 },
        { "E", 7 },
        { "F", 8 },
        { "F#", 9 },
        { "G", 10 },
        { "Ab", 11 },} ;

    public float BaseFreq = 440;
    
    [Range(0,1)]
    public float MasterVolume = 0.5f;
    


}
