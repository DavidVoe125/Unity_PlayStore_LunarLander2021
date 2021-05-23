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
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

    }

    // dont think here inverted
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LeftRotation();
        }

        else if (Input.GetKey(KeyCode.D))
        {
            RightRotation();
        }
    }

    void RightRotation()
    {
        ApplyRotation(-rotationThrust);
    }

    void LeftRotation()
    {
        ApplyRotation(rotationThrust);
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate 
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation so the pyhsic can take over
    }
}
