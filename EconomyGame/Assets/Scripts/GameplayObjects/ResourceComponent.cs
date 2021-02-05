using System.Collections.Generic;
using UnityEngine;

public class ResourceComponent : Selectable
{
    [SerializeField] private List<AudioClip> m_onHitClips;
    [SerializeField] private AudioSource m_audioOnHit;
    [SerializeField] private ParticleSystem m_particlesOnHit;
    [SerializeField] private EResource m_resourceType;
    [SerializeField] private int m_resourceAmount;
    [SerializeField] private int m_maxHealth;
    private int m_currentHealth;

    private void Awake()
    {
        m_currentHealth = m_maxHealth;
    }

    public override void Damage(int amount)
    {
        m_audioOnHit.clip = m_onHitClips[Random.Range(0, m_onHitClips.Count - 1)];
        m_audioOnHit.Play();
        m_particlesOnHit.Play();
        m_currentHealth -= amount;
        m_currentHealth = Mathf.Max(m_currentHealth, 0);
        if (m_currentHealth == 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        m_particlesOnHit.transform.SetParent(null);
        var particlesMain = m_particlesOnHit.main;
        particlesMain.stopAction = ParticleSystemStopAction.Destroy;
        CharacterController.Instance.GetResources(m_resourceType, m_resourceAmount);
        base.Die();
    }
}
