using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarLander.Prototypes.BR.LevelLoaderProtyp
{
    public class GameManager : MonoBehaviour
    {
        // +++ Fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // public
        public GameStates InitialState; // holds the intial state the game starts in

        // private
        private FSM _sceneFsm;




        // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Start()
        {
            _sceneFsm = BuildSceneFsm();
        }

        // Update is called once per frame

        void Update()
        {
            _sceneFsm.Update();
        }




        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private FSM BuildSceneFsm()
        {
            var fsm = new FSM();

            fsm
                .AddState(GameStates.Intro, new SceneState_Intro(fsm))
                .AddState(GameStates.MainMenu, new SceneState_MainMenu(fsm))
                .AddState(GameStates.Credits, new SceneState_Credits(fsm));

            // todo: Add Game Over State
            // todo: Add Pre Level State
            // todo: Add Highscore Index State
            // todo: Add Highscore Name Input State
            // todo: Add Settings State
            // todo: Add Game State
            // todo: Add Landing Successfull State
            // todo: Add Landing Failure State

            fsm.InitialState = InitialState;

            fsm.Start();

            return fsm;
        }
    }
}

