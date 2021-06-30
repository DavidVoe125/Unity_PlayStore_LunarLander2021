using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;
using UnityEngine.UI;

namespace LunarLander.UI.Displays
{


    public class Controller_AGLDisplay : MonoBehaviour
    {
        [SerializeField] private Text m_DisplayText;

        [SerializeField] private string m_Prefix = "AGL :  ";

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
            m_DisplayText.text = $"{m_Prefix} {agl:000.0}";
        }
    }
}
