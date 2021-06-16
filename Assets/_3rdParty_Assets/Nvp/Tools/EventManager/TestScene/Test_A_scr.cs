using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;


public class Test_A_scr : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable(){
        EventManager.AddEventListener("OnMouseLeftClick", OnMouseLeftClick);
        EventManager.AddEventListener(GameEvents.OnMouseRightClick, OnMouseRightClick);
    }

    void OnDisable(){
        EventManager.RemoveEventListener("OnMouseLeftClick", OnMouseLeftClick);
        EventManager.RemoveEventListener(GameEvents.OnMouseRightClick, OnMouseRightClick);
    }


    void OnMouseLeftClick(object sender, object eventArgs){
        Debug.Log("OnMouseLeftClick called");
    }

    void OnMouseRightClick(object sender, object eventArgs){
        Debug.Log("OnMouseRightClick called");
    }
}
