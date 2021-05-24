using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    // Controller for Test use in Prototyp 

    [SerializeField] float mainThrust;
    [SerializeField] float rotationThrust;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        ApplyRotation();
        StartThrusting();
    }

   // // void ProcessThrust()
   ////{
   //     if (Input.GetKey(KeyCode.Space))
   //     {
   //         StartThrusting();
   //     }
   // }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * BR_InputController_scr.Input.y * Time.deltaTime);

    }

    // dont think here inverted
    //void ProcessRotation()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        LeftRotation();
    //    }

    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        RightRotation();
    //    }
    //}

    //void RightRotation()
    //{
    //    ApplyRotation(-rotationThrust);
    //}

    //void LeftRotation()
    //{
    //    ApplyRotation(rotationThrust);
    //}

    void ApplyRotation()
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate 
        transform.Rotate(Vector3.forward  * BR_InputController_scr.Input.x * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the pyhsic can take over
    }
}
