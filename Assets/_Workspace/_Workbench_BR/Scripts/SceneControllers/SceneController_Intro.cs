using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class SceneController_Intro : MonoBehaviour
{
    public void GotoMainMenu()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoMainMenu, null, null);
    }
}