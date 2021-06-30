using System.Collections;
using System.Collections.Generic;
using LunarLander.ExtensionMethods;
using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

public class Controller_SpeedDisplay : MonoBehaviour
{
    [SerializeField] private string m_Prefix;
    [SerializeField] private string m_ListenToSpeedEvent;
    [SerializeField] private Text m_DisplayText;
    [SerializeField] private float m_Factor;

    private void OnEnable()
    {
        if (!string.IsNullOrEmpty(m_ListenToSpeedEvent))
        {
            EventManager.AddEventListener(m_ListenToSpeedEvent, OnSpeedEventInvoked);
        }
    }

    private void OnDisable()
    {
        if (!string.IsNullOrEmpty(m_ListenToSpeedEvent))
        {
            EventManager.RemoveEventListener(m_ListenToSpeedEvent,OnSpeedEventInvoked);
        }
    }

    private void OnSpeedEventInvoked(object sender, object eventargs)
    {
        var value = eventargs.GetValueAs<float>();
        value *= m_Factor;

        m_DisplayText.text = value < 0 
            ? $"{m_Prefix} : -{value:000.0}" 
            : $"{m_Prefix} : +{value:000.0}";
    }
}
