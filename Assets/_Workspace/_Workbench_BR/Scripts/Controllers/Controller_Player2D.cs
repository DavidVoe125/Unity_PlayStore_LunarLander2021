using System;
using System.Collections;
using System.Collections.Generic;
using LunarLander.ExtensionMethods;
using LunarLander.Prototypes.BR.LandscapePrototype;
using Nvp.Events;
using UnityEngine;

public class Controller_Player2D : MonoBehaviour
{
    // +++ editor fields ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Vector2 m_Input = Vector2.zero;
    [SerializeField] private float m_ForceFactor;
    [SerializeField] private float m_Torque;
    [SerializeField] private LayerMask m_GroundLayerMask;
    [SerializeField] private float m_Fuel = 1000f;
    [SerializeField] private float m_FuelConsumptionFactor = 1f;




    // +++ private fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Rigidbody2D m_Rb;
    private Vector3 m_Force;
    private Vector3 m_torqueVector;
    private LineRenderer m_LineRenderer;
    private float m_ThrottleInput = 0;
    private bool m_Landed;
    private Action m_Update;
    private Action m_FixedUpdate;



    // +++ unity event functions ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        m_Update = FlyingUpdate;
        m_FixedUpdate = FlyingFixedUpdate;

        m_Rb = GetComponent<Rigidbody2D>();
        m_LineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(
            MeasureGroundDistanceCoroutine());
    }

    void Update()
    {
        m_Update();
    }

    void FixedUpdate()
    {
        m_FixedUpdate();
    }

    void FlyingUpdate()
    {
        

        m_Input.x = Input.GetAxis("Horizontal") - BR_InputController_scr.INPUT.x;
        m_Input.y = m_ThrottleInput;

        m_torqueVector.z = Mathf.LerpAngle(
            this.m_torqueVector.z, 
            m_Input.x * m_Torque, 
            Time.deltaTime);

        var vel = new Vector3(
                m_Rb.velocity.x,
                m_Rb.velocity.y,
                0);

        m_LineRenderer.SetPosition(
            0, 
            this.transform.position + vel.normalized * 0.25f );
        m_LineRenderer.SetPosition(
            1, 
            this.transform.position + 
            vel.normalized * 
            Mathf.Clamp(
                vel.magnitude * 0.5f, 
                0.35f, 
                1.0f) );

        m_Fuel -= m_Input.y * m_FuelConsumptionFactor * Time.deltaTime;
        //Debug.Log(m_Input.y);
    }

    void LandedUpdate()
    {

    }

    void FlyingFixedUpdate()
    {
        transform.rotation = Quaternion.Euler(m_torqueVector);

        m_Force = transform.up * Time.deltaTime * Mathf.Pow(m_Input.y,5) * m_ForceFactor;

        m_Rb.AddForce(m_Force, ForceMode2D.Force);

    }

    void LandedFixedUpdate()
    {

    }

    void OnEnable()
    {
        EventManager.AddEventListener("OnThrottleValueChanged", OnThrottleValueChanged);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnThrottleValueChanged", OnThrottleValueChanged);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "LandingPad":
                CheckLanding();
                break;
        }
    }


    // +++ eventhandler +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void OnThrottleValueChanged(object sender, object eventargs)
    {
        m_ThrottleInput = eventargs.GetValueAs<float>();
    }


    // +++ co-routines ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private IEnumerator MeasureGroundDistanceCoroutine()
    {
        while (true)
        {
            ReportDistanceToGround();
            ReportSensorData();
            
            yield return new WaitForSeconds(0.1f);
        }
    }


    // +++ class member +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void ReportSensorData()
    {
        EventManager.Invoke("OnReportVelocityVertical", this, m_Rb.velocity.y);
        EventManager.Invoke("OnReportVelocityHorizontal", this, -m_Rb.velocity.x);
        EventManager.Invoke("OnReportRemainingFuel", this, Mathf.Round(m_Fuel));
        EventManager.Invoke("OnReportThrottle", this, m_Input.y);
        EventManager.Invoke("OnReportPosition", this, this.transform.position.x);
    }

    private void ReportDistanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position, 
            Vector2.down,
            float.MaxValue, 
            m_GroundLayerMask);

        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            EventManager.Invoke("OnDistanceToGroundMeasured", this, (distance-0.089f) *100f);
        }
    }

    private bool IsLandingSuccessfull()
    {
        var currentVelocity = m_Rb.velocity;

        if (currentVelocity.magnitude < 5)
        {
            Debug.Log("Successfull Landing");
            return true;
        }


        Debug.Log("Crash Landing");
        return false;
    }

    private void CheckLanding()
    {
        var successfulLanding = IsLandingSuccessfull();
        if (successfulLanding)
        {
            m_Landed = successfulLanding;
            m_Update = LandedUpdate;
            m_FixedUpdate = LandedFixedUpdate;
        }
        else
        {

        }
    }
}
