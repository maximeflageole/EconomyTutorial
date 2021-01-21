using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform m_target;
    [SerializeField] private float m_lerpSpeed = 0.1f;
    private Vector3 m_offset;

    void Awake()
    {
        m_offset = transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = m_target.position;
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, targetPosition + m_offset, m_lerpSpeed);
        transform.position = lerpedPosition;
    }
}
