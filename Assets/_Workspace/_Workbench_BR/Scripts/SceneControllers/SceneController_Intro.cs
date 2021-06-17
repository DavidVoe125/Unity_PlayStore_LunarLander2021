using System.Collections;
using System.Collections.Generic;
using Ludiq;
using Nvp.Events;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Scenes.SceneControllers
{
    public class SceneController_Intro : MonoBehaviour
    {
        public void GotoNextScene(string sceneName)
        {
            Debug.Log(sceneName);
            SceneController_Loading.SetNextScene(sceneName);
            SceneManager.LoadSceneAsync(1);
        }
    }
}

