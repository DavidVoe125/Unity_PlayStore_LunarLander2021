using System;
using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine.SceneManagement;

public static class SceneEventManager
{
    // Transition Intro to Main Menu
    public static event EventHandler OnIntroToMainMenu;
    public static void Raise_OnIntroToMainMenu(object s, EventArgs e) { OnIntroToMainMenu?.Invoke(s, e);}

    // Transition Main Menu to Intro
    public static event EventHandler OnMainMenuToIntro;
    public static void Raise_OnMainMenuToIntro(object s, EventArgs e) { OnMainMenuToIntro?.Invoke(s, e); }




    // Transition Main Menu to Credits
    public static event EventHandler OnMainMenuToCredits;
    public static void Raise_OnMainMenuToCredits(object s, EventArgs e) { OnMainMenuToCredits?.Invoke(s, e); }

    // Transition Credits to Main Menu
    public static event EventHandler OnCreditsToMainMenu;
    public static void Raise_OnCreditsToMainMenu(object s, EventArgs e) { OnCreditsToMainMenu?.Invoke(s, e); }
}