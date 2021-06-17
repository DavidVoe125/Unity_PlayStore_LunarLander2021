using LunarLander.Scenes.SceneControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(this.gameObject);

            SceneController_Loading.SetNextScene("LunarLander_Intro");

            SceneManager.LoadScene("LunarLander_Loading");
        }
    }
}