using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_SongData
{
    
    public static float bpm;
    public static float distancePerBeat;
    public static float offsetXMultiplier;
    public static float offsetCoin;
    public static Vector3 offset;


    public static void SetBpm(float newBPM)
    {
        bpm = newBPM;
    }

    public static void SetDistancePerBeat(float newDist)
    {
        distancePerBeat = newDist;
    }

    public static void SetOffsetXMultiplier(float newOffsetX)
    {
        offsetXMultiplier = newOffsetX;
    }

    public static void SetOffsetCoin(float newOffsetCoin)
    {
        offsetCoin = newOffsetCoin;
    }

    public static void SetOffset()
    {
        offset = new Vector3(distancePerBeat * offsetXMultiplier, 0, 0);
    }

    

}
