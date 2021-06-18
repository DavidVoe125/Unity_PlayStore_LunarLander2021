using LunarLander.Scenes.SceneControllers;
using Nvp.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Scenes.SceneControllers
{
    public class SceneController_MainMenu : MonoBehaviour
    {
        public void GotoNextScene(string sceneName)
        {
            SceneController_Loading.SetNextScene(sceneName);
        }
    }
}