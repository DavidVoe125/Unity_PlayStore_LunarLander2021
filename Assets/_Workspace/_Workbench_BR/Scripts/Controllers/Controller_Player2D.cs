using System.Collections;
using System.Collections.Generic;
using LunarLander.Prototypes.BR.LandscapePrototype;
using Nvp.Events;
using UnityEngine;

public class Controller_Player2D : MonoBehaviour
{
    [SerializeField] private Vector2 m_Input = Vector2.zero;
    [SerializeField] private float m_ForceFactor;
    [SerializeField] private float m_Torque;
    [SerializeField] private LayerMask m_GroundLayerMask;
    [SerializeField] private float m_Fuel = 1000f;
    [SerializeField] private float m_FuelConsumptionFactor = 1f;

    private Rigidbody2D m_Rb;
    public Vector3 m_Force;
    private float m_Rotation;
    private Vector3 m_torqueVector;
    private LineRenderer m_LineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_LineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(
            MeasureGroundDistanceCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        m_Input.x = Input.GetAxis("Horizontal") - BR_InputController_scr.INPUT.x;
        m_Input.y = Input.GetAxis("Vertical") + BR_InputController_scr.INPUT.y;
        m_torqueVector.z = Mathf.LerpAngle(this.m_torqueVector.z, m_Input.x * m_Torque, Time.deltaTime);

        var vel = new Vector3(
                m_Rb.velocity.x,
                m_Rb.velocity.y,
                0);

        m_LineRenderer.SetPosition(0, this.transform.position + vel.normalized * 0.25f );
        m_LineRenderer.SetPosition(1, this.transform.position + vel.normalized * Mathf.Clamp(vel.magnitude * 0.5f, 0.35f, 1.0f) );

        m_Fuel -= m_Input.y * m_FuelConsumptionFactor * Time.deltaTime;
        //Debug.Log(m_Input.y);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(m_torqueVector);

        m_Force = transform.up * Time.deltaTime * Mathf.Pow(m_Input.y,5) * m_ForceFactor;

        m_Rb.AddForce(m_Force, ForceMode2D.Force);

        m_Rb.AddTorque(m_Input.y * m_ForceFactor * Time.deltaTime, ForceMode2D.Force);
    }

    private IEnumerator MeasureGroundDistanceCoroutine()
    {
        while (true)
        {
            Helper_ReportDistanceToGround();
            Helper_ReportSensorData();
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Helper_ReportSensorData()
    {
        EventManager.Invoke("OnReportVelocityVertical", this, m_Rb.velocity.y);
        EventManager.Invoke("OnReportVelocityHorizontal", this, -m_Rb.velocity.x);
        EventManager.Invoke("OnReportRemainingFuel", this, Mathf.Round(m_Fuel));
        EventManager.Invoke("OnReportThrottle", this, m_Input.y);
        EventManager.Invoke("OnReportPosition", this, this.transform.position.x);
    }

    private void Helper_ReportDistanceToGround()
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
}
