using Nvp.Events;
using UnityEngine;

public class SceneController_Credits : MonoBehaviour
{
    public void GotoMainMenu()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoMainMenu, this, null);
    }
}