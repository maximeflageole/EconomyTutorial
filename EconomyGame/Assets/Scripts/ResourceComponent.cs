using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ResourceComponent : Selectable
{
    [SerializeField] private EResource m_resourceType;
    [SerializeField] private int m_resourceAmount;
    [SerializeField] private int m_hitPoints;

    public override void Damage(int amount)
    {
        m_hitPoints -= amount;
        m_hitPoints = Mathf.Max(m_hitPoints, 0);
        if (m_hitPoints == 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        CharacterController.Instance.GetResources(m_resourceType, m_resourceAmount);
        base.Die();
    }
}
