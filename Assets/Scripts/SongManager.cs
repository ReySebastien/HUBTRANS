using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    //Sand Fight 165 BPM | Offset : 6.5
    //In the Blood 154 BPM | Offset : 5
    //Montagne Russe 130 BPM | Offset : ?

    [SerializeField] [Range (154, 165)]private float bpm;
    [SerializeField] private float distancePerBeat;
    [SerializeField] [Range(5, 6.5f)] private float offsetXMultiplier;

    void Awake()
    {
        S_SongData.SetBpm(bpm);
        S_SongData.SetDistancePerBeat(distancePerBeat);
        S_SongData.SetOffsetXMultiplier(offsetXMultiplier);
        S_SongData.SetOffset();
    }

}
