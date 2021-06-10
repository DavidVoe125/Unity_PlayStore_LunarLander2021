using System.Collections;
using System.Collections.Generic;
using LunarLander.Prototypes.InputHandler;
using UnityEngine;
using UnityEngine.UI;

namespace LunarLander.Prototypes.InputHandler
{
    public class BR_UIManager_scr : MonoBehaviour
    {
        public Text HorizontalDisplay;
        public Text VerticalDisplay;

        void Update()
        {
            HorizontalDisplay.text = $"H: {BR_InputController_scr.Input.x:#0.00}";
            VerticalDisplay.text = $"V: {BR_InputController_scr.Input.y:#0.00}";
        }
    }
}
