using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;


   

    private void Awake()
    {
        instance = this;
    }
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //GameOver시 AddActive 를 실행한다.
}
