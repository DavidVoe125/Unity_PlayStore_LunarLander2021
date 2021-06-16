namespace Nvp.Events
{    public enum GameEvents
    {
        // scene management Events

        OnIntroEntered,
        OnIntroExited,

        OnMainMenuEntered,
        OnMainMenuExited,

        OnCreditsEntered,
        OnCreditsExited,

        OnSettingsEntered,
        OnSettingsExited,

        // game events
        OnUiButtonClicked_GotoMainMenu,
        OnUiButtonClicked_GotoCredits,
        OnUiButtonClicked_GotoIntro,

        // for testing
        OnMouseRightClick,
  }
}