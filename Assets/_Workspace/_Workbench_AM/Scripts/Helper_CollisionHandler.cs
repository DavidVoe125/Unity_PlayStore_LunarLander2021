using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_CollisionHandler : MonoBehaviour
{
    [SerializeField] string NextLevelName;

    bool isTransitioning = false;
    bool Collisiontoggle = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || Collisiontoggle) { return; }


        switch (other.gameObject.tag)
        {
            case "First Lander":
                Debug.Log(rb.velocity);
                Debug.Log("This Thing gives you 100 Points");
                break;
            case "Secound Lander":
                Debug.Log(rb.velocity);
                Debug.Log("This Thing gives you 200 Points");
                break;
            default:
                Debug.Log(rb.velocity);
                break;
        }

    }
}
