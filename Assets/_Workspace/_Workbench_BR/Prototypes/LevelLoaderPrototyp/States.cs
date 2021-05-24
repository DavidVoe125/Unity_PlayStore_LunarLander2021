using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneState_Intro : IState
{
    private readonly FSM fsm;

    public SceneState_Intro(FSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("UI State Entered: Intro");
        SceneManager.LoadScene("LevelLoader_Intro", LoadSceneMode.Additive);
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            fsm.SwitchStates(SceneManagerStates.MainMenu);
        }
    }

    public void OnExit()
    {
        Debug.Log("UI State Exited: Intro");
        SceneManager.UnloadSceneAsync("LevelLoader_Intro");
    }
}

public class SceneState_MainMenu : IState
{
    private readonly FSM fsm;

    public SceneState_MainMenu(FSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("UI State Entered: MainMenu");
        SceneManager.LoadScene("LevelLoader_MainMenu", LoadSceneMode.Additive);
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            fsm.SwitchStates(SceneManagerStates.Credits);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            fsm.SwitchStates(SceneManagerStates.Intro);
        }
    }

    public void OnExit()
    {
        Debug.Log("UI State Exited: Intro");
        SceneManager.UnloadSceneAsync("LevelLoader_MainMenu");
    }
}

public class SceneState_Credits : IState
{
    private readonly FSM fsm;

    public SceneState_Credits(FSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        Debug.Log("UI State Entered: Intro");
        SceneManager.LoadScene("LevelLoader_Credits", LoadSceneMode.Additive);
    }

    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            fsm.SwitchStates(SceneManagerStates.MainMenu);
        }
    }

    public void OnExit()
    {
        Debug.Log("UI State Exited: Intro");
        SceneManager.UnloadSceneAsync("LevelLoader_Credits");
    }
}
