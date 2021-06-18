using System.Collections;
using System.Collections.Generic;
using Nvp.Events;
using UnityEngine;

public class Controller_CameraDistance : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float m_MaxCameraSize;
    [SerializeField] private float m_MinCameraSize;

    private float sizeTarget;

    void Start()
    {
        sizeTarget = m_MaxCameraSize;
    }

    void Update()
    {
        m_Camera.orthographicSize = Mathf.Lerp(m_Camera.orthographicSize, sizeTarget, Time.deltaTime);
    }

    void OnEnable()
    {
        EventManager.AddEventListener("OnDistanceToGroundMeasured", OnDistanceToGroundMeasured);
    }

    void OnDisable()
    {
        EventManager.RemoveEventListener("OnDistanceToGroundMeasured", OnDistanceToGroundMeasured);
    }

    private void OnDistanceToGroundMeasured(object sender, object eventargs)
    {
        float diff = m_MaxCameraSize - m_MinCameraSize;

        float agl = ((float)eventargs);
        sizeTarget = Mathf.Clamp(
            m_MaxCameraSize - diff * (1f - (agl / 500))
            , m_MinCameraSize
            , m_MaxCameraSize);
        Debug.Log($"sizeTarget: {sizeTarget}");
    }
}
