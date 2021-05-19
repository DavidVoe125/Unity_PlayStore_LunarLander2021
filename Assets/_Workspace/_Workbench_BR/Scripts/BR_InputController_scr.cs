using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BR_InputController_scr : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    
    public Text VerticalInput;
    public Text HorizontalInput;

    private Vector2 _input = new Vector2();


    void Update()
    {
        
        _input.y = -Input.acceleration.z;
        _input.x = Input.acceleration.x;

        VerticalInput.text = $"V: {_input.y:#0.00}";
        HorizontalInput.text = $"H: {_input.x:#0.00}";
    }
}
