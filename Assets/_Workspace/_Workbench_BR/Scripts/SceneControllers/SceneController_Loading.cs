using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController_Loading : MonoBehaviour
{
    public string m_GameControllerSceneName;
    public string m_FirstSceneName;
    private static string m_LastSceneName;
    private static SceneController_Loading m_Instance;
    private static string m_NextSceneName;

    private void Awake()
    {
        if (m_Instance != null)
        {
            Destroy(m_Instance.gameObject);
        }
        else
        {
            m_Instance = this;
        }
    }

    public static void SetNextScene(string nextSceneName)
    {
        m_NextSceneName = nextSceneName;
    }

    void Start()
    {
        SceneManager.LoadSceneAsync(m_NextSceneName);
        m_LastSceneName = m_NextSceneName;
        SceneManager.UnloadSceneAsync("LunarLander_Loading");
    }
}
