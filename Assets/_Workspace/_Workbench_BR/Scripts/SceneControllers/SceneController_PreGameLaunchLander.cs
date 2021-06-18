using System.Collections;
using System.Collections.Generic;
using LunarLander.Scenes.SceneControllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController_PreGameLaunchLander : MonoBehaviour
{
    [SerializeField] float m_LoadLevelAfterSecondsElapsed;
    [SerializeField] private string m_NextSceneName;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("touch");
                SceneController_Loading.SetNextScene(m_NextSceneName);
            }
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(m_LoadLevelAfterSecondsElapsed);
        
        SceneController_Loading.SetNextScene(m_NextSceneName);
    }

}
