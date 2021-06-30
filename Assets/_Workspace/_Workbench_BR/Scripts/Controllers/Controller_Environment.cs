using Nvp.Events;
using UnityEngine;

namespace LunarLander.Game.Controllers
{
    public class Controller_Environment : MonoBehaviour
    {
        [SerializeField] private int m_Points;

        [SerializeField] private float m_Fuel;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                EventManager.Invoke("OnPlayerCollidedWithEnvironment", this, m_Points);
            }
        }
    }
}