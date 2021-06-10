using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LunarLander.Prototypes.BR.LandscapePrototype
{
    public class BR_InputController_scr : MonoBehaviour
    {
        // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public static Vector2 INPUT = new Vector2();


        // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        void Update()
        {
            INPUT.y = Mathf.Clamp(
                -UnityEngine.Input.acceleration.z,
                0.30f,
                0.95f);
            var sign = Mathf.Sign(INPUT.y);
            INPUT.y = Mathf.Abs(INPUT.y) - 0.30f; 
            INPUT.y /= (0.95f - 0.30f) * sign;
            //Debug.Log(INPUT.y);

            INPUT.x = Mathf.Clamp(
                UnityEngine.Input.acceleration.x,
                -0.45f,
                0.45f);
            INPUT.x /= 0.45f;
            //Debug.Log(INPUT.x);
        }
    }
}
