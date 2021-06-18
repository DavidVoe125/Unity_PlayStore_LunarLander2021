using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_EventMonitor : MonoBehaviour
{
    [SerializeField] private string m_EventToMonitor;

    void OnEnable()
    {
        EventManager.AddEventListener(m_EventToMonitor, OnEventInvokation);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener(m_EventToMonitor, OnEventInvokation);
    }

    private void OnEventInvokation(object sender, object eventargs)
    {
        Debug.Log($"{((GameObject)sender).name} invokes {m_EventToMonitor}");
    }
}
