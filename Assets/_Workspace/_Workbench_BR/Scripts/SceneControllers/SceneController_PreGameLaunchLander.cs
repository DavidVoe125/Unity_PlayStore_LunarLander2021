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

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(m_LoadLevelAfterSecondsElapsed);

        Debug.Log(m_NextSceneName);
        SceneController_Loading.SetNextScene(m_NextSceneName);
        SceneManager.LoadSceneAsync(1);
    }

}
