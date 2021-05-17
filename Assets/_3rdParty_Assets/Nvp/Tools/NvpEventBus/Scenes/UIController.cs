using System.Collections;
using System.Collections.Generic;
using Nvp.Tools.Events;
using Nvp.Tools.Events.EventBus;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Text _thing02HealthText;




    // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void OnEnable()
    {
        NvpEventBus.AddListener("Thing02Hit", OnThing02Hit);
    }

    void OnDisable()
    {
        NvpEventBus.RemoveListener("Thing02Hit", OnThing02Hit);
    }




    // +++ event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnThing02Hit(object eventArgs)
    {
        // unbox eventArgs
        var health = (int) eventArgs;

        _thing02HealthText.text = $"Health: {health:000}";
    }
}
