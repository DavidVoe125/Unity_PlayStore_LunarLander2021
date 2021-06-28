using System.Collections;
using System.Collections.Generic;
using LunarLander.Prototypes.BR.LandscapePrototype;
using Nvp.Events;
using UnityEngine;

public class Controller_Player2D : MonoBehaviour
{
    private Rigidbody2D m_Rb;

    [SerializeField] private Vector2 m_Input = Vector2.zero;

    [SerializeField] private float m_ForceFactor;

    [SerializeField] private Vector3 m_Force;

    [SerializeField] private float m_Torque;

    [SerializeField] private float m_Rotation;

    [SerializeField] private LayerMask m_GroundLayerMask;

    

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
        m_Input.x = Input.GetAxis("Horizontal");
        m_Input.y = Input.GetAxis("Vertical");
        m_torqueVector.z = Mathf.LerpAngle(this.m_torqueVector.z, -BR_InputController_scr.INPUT.x * m_Torque, Time.deltaTime);

        var vel = new Vector3(
                m_Rb.velocity.x,
                m_Rb.velocity.y,
                0);

        m_LineRenderer.SetPosition(0, this.transform.position + vel.normalized *0.25f);
        m_LineRenderer.SetPosition(1, this.transform.position + vel.normalized *0.35f);
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(m_torqueVector);

        m_Force = transform.up * Time.deltaTime * Mathf.Pow(BR_InputController_scr.INPUT.y,5) * m_ForceFactor;

        m_Rb.AddForce(m_Force, ForceMode2D.Force);

        m_Rb.AddTorque(m_Input.y * m_ForceFactor * Time.deltaTime, ForceMode2D.Force);
    }

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
        EventManager.Invoke("OnReportVelocityVertical", this, m_Rb.velocity.y);
        EventManager.Invoke("OnReportVelocityHorizontal", this, -m_Rb.velocity.x);
    }

    private void Helper_MeasureDistanceToGround()
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
