using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConts.BEST_SCORE, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConts.BEST_SCORE, 0);

            if (value > curScore)
            {
                PlayerPrefs.SetInt(GameConts.BEST_SCORE, value);
            }
        }
    }
}
