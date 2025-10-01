using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameoverDialog : Dialog
{
    public Text totalMoveTxt;
    public Text bestMoveTxt;

    public override void Show(bool isShow)
    {
        base.Show(isShow);

        if(totalMoveTxt && GameManager.Ins)
            totalMoveTxt.text = GameManager.Ins.TotalMoving.ToString();

        if (bestMoveTxt)
            bestMoveTxt.text = Pref.bestMove.ToString();
    }

    public void Continue()
    {
        SceneManager.sceneLoaded += OnSceneLoadEvent;
        if (SceneController.Ins)
            SceneController.Ins.LoadCurrentScene();
    }

    private void OnSceneLoadEvent(Scene scene, LoadSceneMode mode)
    {
        if (GameManager.Ins)
            GameManager.Ins.PlayGame();

        SceneManager.sceneLoaded -= OnSceneLoadEvent;

    }
}
