using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

public class Controller_AGLDisplay : MonoBehaviour
{
    [SerializeField] private Text m_AboveGroundLevelText;

    void OnEnable()
    {
        EventManager.AddEventListener("OnDistanceToGroundMeasured", OnDistanceToGroundMeasured);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnDistanceToGroundMeasured", OnDistanceToGroundMeasured);
    }

    private void OnDistanceToGroundMeasured(object sender, object eventargs)
    {
        float agl = (float) eventargs;
        //Debug.Log($"AGL : {agl} m");
        m_AboveGroundLevelText.text = $"AGL : {agl:000.0} m";
    }
}
