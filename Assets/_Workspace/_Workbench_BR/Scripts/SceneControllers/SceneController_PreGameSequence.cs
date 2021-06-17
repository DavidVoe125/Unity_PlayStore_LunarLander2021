using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Scenes.SceneControllers
{
    public class SceneController_PreGameSequence : MonoBehaviour
    {
        public void GotoNextScene(string sceneName)
        {
            Debug.Log(sceneName);
            SceneController_Loading.SetNextScene(sceneName);
            SceneManager.LoadSceneAsync(1);
        }
    }
}