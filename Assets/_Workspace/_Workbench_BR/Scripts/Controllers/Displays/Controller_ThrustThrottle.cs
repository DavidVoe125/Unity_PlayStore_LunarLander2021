using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

public class Controller_ThrustThrottle : MonoBehaviour
{
    [SerializeField] private Slider m_ThrottleSlider;

    public float m_LastSliderValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        m_ThrottleSlider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var currentSliderValue = m_ThrottleSlider.value;

        if (currentSliderValue != m_LastSliderValue)
        {
            m_LastSliderValue = currentSliderValue;

            EventManager.Invoke("OnThrottleValueChanged", this, currentSliderValue);
        }
    }
}
