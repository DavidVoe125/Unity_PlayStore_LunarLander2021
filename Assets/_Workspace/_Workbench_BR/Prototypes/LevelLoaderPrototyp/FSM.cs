using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public Dictionary<SceneManagerStates, IState> States = new Dictionary<SceneManagerStates, IState>();
    public IState CurrentState;
    public SceneManagerStates InitialState;

    public void Start()
    {
        CurrentState ??= States[InitialState];
        CurrentState.OnEnter();
    }

    public FSM AddState(SceneManagerStates id, IState state)
    {
        States.Add(id, state);
        return this;
    }

    public void Update()
    {
        CurrentState.OnUpdate();
    }

    public void SwitchStates(SceneManagerStates stateId)
    {
        if (!States.ContainsKey(stateId)) Debug.Log($"Tried to switch to non existing state [{stateId}]");
        var nextState = States[stateId];

        CurrentState.OnExit();
        nextState.OnEnter();
        CurrentState = nextState;
    }
}

public enum SceneManagerStates
{
    Intro,
    MainMenu,
    Credits,
    Settings,
    PreLevel,
    Level,
    LandingSuccessful,
    LandingFailure
}