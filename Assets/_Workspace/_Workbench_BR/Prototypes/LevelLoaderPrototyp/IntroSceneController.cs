using Nvp.Events;
using UnityEngine;

public class IntroSceneController : MonoBehaviour
{
    public void GotoMainMenu()
    {
        EventManager.Invoke(GameEvents.OnUiButtonClicked_GotoMainMenu, this, null);
    }
}