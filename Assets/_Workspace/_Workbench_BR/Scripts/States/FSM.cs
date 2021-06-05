using System;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

namespace LunarLander.Game.States
{
    public class FSM : IDisposable
    {
        public Dictionary<GameStates, IState> States = new Dictionary<GameStates, IState>();
        public IState CurrentState;
        public GameStates InitialState;

        public void Start()
        {
            CurrentState ??= States[InitialState];
            CurrentState.OnEnter();

            EventManager.AddEventListener(GameEvents.OnUiButtonClicked_GotoMainMenu, TransitionToMainMenu);
            EventManager.AddEventListener(GameEvents.OnUiButtonClicked_GotoCredits, TransitionToCredits);
            EventManager.AddEventListener(GameEvents.OnUiButtonClicked_GotoIntro, TransitionToIntro);
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

        public void Dispose()
        {
            EventManager.RemoveEventListener(GameEvents.OnUiButtonClicked_GotoMainMenu, TransitionToMainMenu);
            EventManager.RemoveEventListener(GameEvents.OnUiButtonClicked_GotoCredits, TransitionToCredits);
            EventManager.RemoveEventListener(GameEvents.OnUiButtonClicked_GotoIntro, TransitionToIntro);
        }

        private void TransitionToMainMenu(object sender, object eventargs)
        {
            this.SwitchStates(GameStates.MainMenu);
        }

        private void TransitionToCredits(object sender, object eventargs)
        {
            this.SwitchStates(GameStates.Credits);
        }

        private void TransitionToIntro(object sender, object eventargs)
        {
            this.SwitchStates(GameStates.Intro);
        }
    }
}
