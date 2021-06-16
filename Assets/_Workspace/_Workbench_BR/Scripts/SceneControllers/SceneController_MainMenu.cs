using Nvp.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController_MainMenu : MonoBehaviour
{
    public void GotoNextScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneController_Loading.SetNextScene(sceneName);
        SceneManager.LoadSceneAsync(1);
    }
}