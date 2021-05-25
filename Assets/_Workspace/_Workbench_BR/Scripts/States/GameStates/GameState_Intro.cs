using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Game.States
{
    public class GameState_Intro : IState
    {
        private readonly FSM fsm;

        public GameState_Intro(FSM fsm)
        {
            this.fsm = fsm;
        }

        public void OnEnter()
        {
            Debug.Log("UI State Entered: Intro");
            SceneManager.LoadScene("LunarLander_Intro_Scene", LoadSceneMode.Additive);
        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                fsm.SwitchStates(GameStates.MainMenu);
            }
        }

        public void OnExit()
        {
            Debug.Log("UI State Exited: Intro");
            SceneManager.UnloadSceneAsync("LunarLander_Intro_Scene");
        }
    }
}