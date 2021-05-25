using UnityEngine;
using UnityEngine.SceneManagement;

namespace LunarLander.Game.States
{
    public class GameState_MainMenu : IState
    {
        private readonly FSM fsm;

        public GameState_MainMenu(FSM fsm)
        {
            this.fsm = fsm;
        }

        public void OnEnter()
        {
            Debug.Log("UI State Entered: MainMenu");
            SceneManager.LoadScene("LunarLander_MainMenu_Scene", LoadSceneMode.Additive);
        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                fsm.SwitchStates(GameStates.Credits);
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                fsm.SwitchStates(GameStates.Intro);
            }
        }

        public void OnExit()
        {
            Debug.Log("UI State Exited: Intro");
            SceneManager.UnloadSceneAsync("LunarLander_MainMenu_Scene");
        }
    }
}