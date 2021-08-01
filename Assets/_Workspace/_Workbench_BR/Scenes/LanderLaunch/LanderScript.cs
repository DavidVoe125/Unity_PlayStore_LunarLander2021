using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderScript : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    public void OnAnimationEvent()
    {
        ParticleSystem.Play();
    }
}
