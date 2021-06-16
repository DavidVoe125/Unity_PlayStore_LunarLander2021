using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController_Intro : MonoBehaviour
{


    public void GotoMainMenu()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoMainMenu, null, null);
    }

    public void GotoNextScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneController_Loading.SetNextScene(sceneName);
        SceneManager.LoadSceneAsync(1);
    }
}