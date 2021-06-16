using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
