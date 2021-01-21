﻿using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public static CharacterController Instance { get; private set; }
    [SerializeField] private float m_acceleration = 50.0f;
    [SerializeField] private float m_maxSpeed = 10.0f;
    [SerializeField] private Animator m_animator;
    [SerializeField] private Selector m_selector;
    [SerializeField] private MeleeWeapon m_weapon;

    [SerializeField] private ResourcesPanel m_resourcesPanel;

    private int m_copperAmount = 0;
    private int m_ironAmount = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Swing");
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

    private void Hit()
    {
        m_selector.Hit(m_weapon.GetDamage());
    }

    public void GetResources(EResource type, int qty)
    {
        switch (type)
        {
            case EResource.Copper:
                m_copperAmount += qty;
                break;
            case EResource.Iron:
                m_ironAmount += qty;
                break;
            default:
                break;
        }
    }
}
