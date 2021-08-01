using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_ThrustParticleSystem : MonoBehaviour
{
    
    void OnEnable()
    {
        EventManager.AddEventListener("OnReportThrottle", OnReportThrottle);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnReportThrottle", OnReportThrottle);
    }

    void OnReportThrottle(object sender, object eventArgs){
        
    }
}
