using UnityEngine;

namespace LunarLander.Prototypes.BR.LandscapePrototype
{
    public class BR_PlayerController_scr : MonoBehaviour
    {
        [SerializeField] private float torque;
        [SerializeField] private float force;
        [SerializeField] private Transform forceDir;

        private Vector3 torqueVector ;
        private Rigidbody rb;

        private void Start()
        {
            torqueVector = transform.rotation.eulerAngles;
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            torqueVector.z += BR_InputController_scr.INPUT.x * torque * Time.deltaTime;
            transform.rotation = Quaternion.Euler(torqueVector);
            //Debug.Log(torqueVector);

            rb.AddForce(forceDir.forward * BR_InputController_scr.INPUT.y * force * Time.deltaTime, ForceMode.Force);
        }
    }
}