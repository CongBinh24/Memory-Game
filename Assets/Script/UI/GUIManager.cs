using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    public GameObject mainMenu;
    public GameObject gamePlay;
    public Image timeBar;

    public PauseDialog pauseDialog;
    public TimeoutDialog timeoutDialog;
    public GameoverDialog gameoverDialog;


    public override void Awake()
    {
        MakeSingleton(false);
    }

    public void ShowGameplay(bool isShow)
    {
        if (gamePlay)
            gamePlay.SetActive(isShow);

        if(mainMenu)
            gamePlay.SetActive(!isShow);
    }

    public void UpdateTimeBar(float curTime, float totalTime)
    {
        float rate = curTime / totalTime;
        if (timeBar)
            timeBar.fillAmount = rate;
    }
}
