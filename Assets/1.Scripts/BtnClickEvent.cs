using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnClickEvent : MonoBehaviour
{
    public void OnGameStart()
    {
        SceneChange.instance.Change("Game");
    }
    public void OnGameOption()
    {
        SceneChange.instance.Change("Option");
    }
    public void OnGameExit()
    {
        Application.Quit();
    }
}
