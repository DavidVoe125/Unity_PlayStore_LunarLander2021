using System.Collections.Generic;
using UnityEngine;

namespace LunarLander.Game.States
{
    public class FSM
    {
        public Dictionary<GameStates, IState> States = new Dictionary<GameStates, IState>();
        public IState CurrentState;
        public GameStates InitialState;

        public void Start()
        {
            CurrentState ??= States[InitialState];
            CurrentState.OnEnter();
        }

        public FSM AddState(GameStates id, IState state)
        {
            States.Add(id, state);
            return this;
        }

        public void Update()
        {
            CurrentState.OnUpdate();
        }

        public void SwitchStates(GameStates stateId)
        {
            if (!States.ContainsKey(stateId)) Debug.Log($"Tried to switch to non existing state [{stateId}]");
            var nextState = States[stateId];

            CurrentState.OnExit();
            nextState.OnEnter();
            CurrentState = nextState;
        }
    }
}