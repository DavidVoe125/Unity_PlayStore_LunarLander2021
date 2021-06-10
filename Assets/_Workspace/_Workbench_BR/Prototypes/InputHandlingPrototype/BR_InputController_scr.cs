using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LunarLander.Prototypes.InputHandler
{
    public class BR_InputController_scr : MonoBehaviour
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public Text VerticalInput;
        public Text HorizontalInput;

        public static Vector2 Input = new Vector2();


        void Update()
        {
            Input.y = (Mathf.Clamp(-UnityEngine.Input.acceleration.z, 0.30f, 0.95f) - 0.30f) / (0.95f - 0.30f);
            Input.x = Mathf.Clamp(UnityEngine.Input.acceleration.x, -0.45f, 0.45f) / 0.45f;
        }
    }
}

