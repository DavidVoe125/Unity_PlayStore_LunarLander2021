using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nvp.Events;
public class Test_B_scr : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            EventManager.Invoke("OnMouseLeftClick", this, null);
        }

        if(Input.GetMouseButtonDown(1))
        {
            EventManager.Invoke(GameEvents.OnMouseRightClick, this, null);
        }
    }
}
