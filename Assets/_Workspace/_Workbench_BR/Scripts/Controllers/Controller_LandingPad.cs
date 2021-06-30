using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

namespace LunarLander.Game.Controllers
{
    public class Controller_LandingPad : MonoBehaviour
    {
        [SerializeField] private int m_Points;

        [SerializeField] private float m_Fuel;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"LandingPad collision detected {collision.gameObject.name}");
                EventManager.Invoke("OnPlayerCollidedWithLandingPad", this, m_Points);
            }
        }
    }
}
