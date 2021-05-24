using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FSM Scene_FSM;
    public SceneManagerStates InitialState;


    // Start is called before the first frame update
    void Start()
    {
        Scene_FSM = new FSM();
        

        Scene_FSM
            .AddState(SceneManagerStates.Intro, new SceneState_Intro(Scene_FSM))
            .AddState(SceneManagerStates.MainMenu, new SceneState_MainMenu(Scene_FSM))
            .AddState(SceneManagerStates.Credits, new SceneState_Credits(Scene_FSM));

        Scene_FSM.InitialState = InitialState;

        Scene_FSM.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Scene_FSM.Update();
    }
}