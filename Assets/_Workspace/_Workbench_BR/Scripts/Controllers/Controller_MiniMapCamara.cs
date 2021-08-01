using System.Collections;
using System.Collections.Generic;
using LunarLander.ExtensionMethods;
using Nvp.Events;
using UnityEngine;

public class Controller_MiniMapCamara : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.AddEventListener("OnReportPosition", OnReportPosition);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnReportPosition", OnReportPosition);
    }

    private void OnReportPosition(object sender, object eventargs)
    {
        var pos = transform.position;
        pos.x = eventargs.GetValueAs<float>();
        transform.position = pos;
    }
}
