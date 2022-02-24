using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    public static int score = 0;
    public static int vinylCount = 0;

    public static void AddVinyl(int value)
    {
        vinylCount += value;
    }
}
