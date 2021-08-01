using System.Collections;
using System.Collections.Generic;
using LunarLander.ExtensionMethods;
using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

public class Controller_ThrottleSlider : MonoBehaviour
{
    [SerializeField] private Slider m_ThrottleSlider;

    [SerializeField] private float m_MaxSliderValue = 0.001f;

    void OnEnable()
    {
        EventManager.AddEventListener("OnReportThrottle", OnReportThrottle);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnReportThrottle", OnReportThrottle);
    }

    private void OnReportThrottle(object sender, object eventargs)
    {
        //Debug.Log("OnReportThrottle");
        var value = eventargs.GetValueAs<float>();
        if (value > m_MaxSliderValue) m_MaxSliderValue = value;

        value = Mathf.Clamp(value / m_MaxSliderValue, 0f, 1f);
        m_ThrottleSlider.value = Mathf.Lerp(m_ThrottleSlider.value, value, Time.deltaTime*10) ;

    }
}
