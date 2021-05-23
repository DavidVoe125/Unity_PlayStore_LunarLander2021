using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float velocitirigidbody;

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


    // writes Velocity(later can be used magnitude as precise calculation) writes Points, starts StartNextLevel ans Reload Level
    // At Moment Scene Change is "//" to not chnage the Sceen but funcionalty is working! if necessary change the build Settings and this script to make tests.

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || Collisiontoggle) { return; }


        switch (other.gameObject.tag)
        {
            case "First Lander":
                Debug.Log(rb.velocity);
                Debug.Log("This Thing gives you 100 Points");
                //StartNextLevel();
                break;
            case "Secound Lander":
                Debug.Log(rb.velocity);
                Debug.Log("This Thing gives you 200 Points");
                //StartNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }

    }

    // ReloadLevel as method basicly a crash Sequenz restart the current Level in the build
    // StartNextLevel as method chnage +1 in the SceneManager to get to the next Level

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void StartNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {

            nextSceneIndex = 0;

        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
