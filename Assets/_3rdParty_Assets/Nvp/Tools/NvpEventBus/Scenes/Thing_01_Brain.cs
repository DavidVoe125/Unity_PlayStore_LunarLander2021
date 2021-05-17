using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events;
using Nvp.Tools.Events.EventBus;
using UnityEngine;

public class Thing_01_Brain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Fire event on key-down for space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NvpEventBus.DispatchEvent("AttackAll", 10);
        }
    }
}
