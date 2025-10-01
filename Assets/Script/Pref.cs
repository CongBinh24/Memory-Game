using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref
{
    public static int bestMove
    {
        set
        {
            int oldMove = PlayerPrefs.GetInt(Prefkey.BestScore.ToString(), 0);
            if (oldMove > value || oldMove == 0)
                PlayerPrefs.SetInt(Prefkey.BestScore.ToString(), value);
        }

        get => PlayerPrefs.GetInt(Prefkey.BestScore.ToString(), 0);
    }
}
