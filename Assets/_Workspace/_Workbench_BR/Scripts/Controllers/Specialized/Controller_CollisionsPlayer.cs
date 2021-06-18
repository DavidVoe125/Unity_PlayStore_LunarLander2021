using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_CollisionsPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Environment"))
        {
            EventManager.Invoke(
                "OnPlayerCollidedWithEnvironment", 
                this, 
                this.transform.position);
        }
        else if (collision.collider.gameObject.CompareTag("LandingPad"))
        {
            EventManager.Invoke(
                "OnPlayerCollidedWithLandingPad", 
                this, 
                this.gameObject.GetComponent<Rigidbody>());
        }
    }
}
