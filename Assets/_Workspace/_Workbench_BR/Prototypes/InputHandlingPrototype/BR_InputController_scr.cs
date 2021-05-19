using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BR_InputController_scr : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    public Text VerticalInput;
    public Text HorizontalInput;

    public static Vector2 Input = new Vector2();


    void Update()
    {
        Input.y = -UnityEngine.Input.acceleration.z;
        Input.x = UnityEngine.Input.acceleration.x;

        VerticalInput.text = $"V: {Input.y:#0.00}";
        HorizontalInput.text = $"H: {Input.x:#0.00}";
    }
}
