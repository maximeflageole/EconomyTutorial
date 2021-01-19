using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_acceleration = 50.0f;
    [SerializeField] private float m_maxSpeed = 10.0f;

    [SerializeField] private ResourcesPanel m_resourcesPanel;

    private int m_copperAmount = 0;
    private int m_ironAmount = 0;

    void Update()
    {
        //TODO: Remove this once resource collecting is done, it is purely for testing
        if (Input.GetKeyDown(KeyCode.C))
        {
            m_copperAmount += 10;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            m_ironAmount += 10;
        }
        UpdateResources();
    }
    
    void FixedUpdate()
    {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }

        if (movement.magnitude > 0f)
        {
            movement.Normalize();
        }
        
        var rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.AddForce(movement * m_acceleration);

        if (rigidbody2d.velocity.magnitude >= m_maxSpeed)
        {
            rigidbody2d.velocity = rigidbody2d.velocity.normalized * m_maxSpeed;
        }
    }

    void UpdateResources()
    {
        m_resourcesPanel.UpdateCopper(m_copperAmount);
        m_resourcesPanel.UpdateIron(m_ironAmount);
    }
}
