using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Scenes.SceneControllers
{
    public class SceneController_GameOver : MonoBehaviour
    {
        public void GotoNextScene(string sceneName)
        {
            SceneController_Loading.SetNextScene(sceneName);
        }
    }
}