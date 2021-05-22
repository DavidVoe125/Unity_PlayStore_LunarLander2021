using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Speed += Time.deltaTime * 1.5f;
        this.transform.Translate(Vector3.up * Speed * Time.deltaTime, Space.World);
    }
}
