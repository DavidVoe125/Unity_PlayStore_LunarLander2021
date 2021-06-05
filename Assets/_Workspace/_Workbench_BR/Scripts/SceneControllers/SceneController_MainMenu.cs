using Nvp.Events;
using UnityEngine;

public class SceneController_MainMenu : MonoBehaviour
{
    public void GotoCredits()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoCredits, this, null);
    }
    public void GotoIntro()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoIntro, this, null);
    }
}