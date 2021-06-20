using System.Collections;
using LunarLander.Scenes.SceneControllers;
using Nvp.Events;
using UnityEngine;

namespace LunarLander.Prototypes.BR.LandscapePrototype
{
    public class BR_PlayerController_scr : MonoBehaviour
    {
        [SerializeField] private float torque;
        [SerializeField] private float force;
        [SerializeField] private Transform forceDir;
        [SerializeField] private string m_NextSceneName;
        [SerializeField] private LayerMask m_GroundLayerMask;

        private Vector3 m_torqueVector;
        private Rigidbody m_rb;
        private bool m_IsLanded;




        // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void Start()
        {
            m_torqueVector = transform.rotation.eulerAngles;
            m_rb = GetComponent<Rigidbody>();
            m_rb.velocity = new Vector3(
                -10f
                , 0f
                , 0f);

            StartCoroutine(
                MeasureGroundDistanceCoroutine());
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    //Debug.Log("touch");
                    SceneController_Loading.SetNextScene(
                        m_NextSceneName);
                }
            }
        }

        private void FixedUpdate()
        {
            if (m_IsLanded) return;

            m_torqueVector.z += BR_InputController_scr.INPUT.x * torque * Time.deltaTime;
            transform.rotation = Quaternion.Euler(
                m_torqueVector);
            //Debug.Log(BR_InputController_scr.INPUT.y);

            m_rb.AddForce(
                forceDir.forward 
                * BR_InputController_scr.INPUT.y 
                * force 
                * Time.deltaTime
                , ForceMode.Force);
        }

        private void OnEnable()
        {
            EventManager.AddEventListener("OnPlayerCollidedWithLandingPad", OnPlayerCollidedWithLandingPad);
        }

        private void OnDisable()
        {
            EventManager.RemoveEventListener("OnPlayerCollidedWithLandingPad", OnPlayerCollidedWithLandingPad);
        }




        // +++ Event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void OnPlayerCollidedWithLandingPad(object sender, object eventargs)
        {
            m_IsLanded = true;
        }


        // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private IEnumerator MeasureGroundDistanceCoroutine()
        {
            while (true)
            {
                Helper_MeasureDistanceToGround();
                Helper_ReportVelocity();
                yield return new WaitForSeconds(0.3f);
            }
        }

        private void Helper_ReportVelocity()
        {
            EventManager.Invoke("OnReportVelocityVertical", this, m_rb.velocity.y);
            EventManager.Invoke("OnReportVelocityHorizontal", this, -m_rb.velocity.x);
        }

        private void Helper_MeasureDistanceToGround()
        {
            RaycastHit hit;
            Ray ray = new Ray(
                this.transform.position, 
                Vector3.down);

            if (Physics.Raycast(ray, out hit, float.MaxValue, m_GroundLayerMask))
            {
                //Debug.Log($"Ground is {hit.distance/0.1f}m away.");
                EventManager.Invoke("OnDistanceToGroundMeasured", this, hit.distance / 0.01f);
            }
        }
    }
}