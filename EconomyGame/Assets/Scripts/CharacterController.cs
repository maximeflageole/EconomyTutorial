using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_acceleration = 50.0f;
    [SerializeField] private float m_maxSpeed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
