using UnityEngine;

public class ResourceComponent : Selectable
{
    [SerializeField] private SpriteRenderer m_renderer;
    [SerializeField] private ResourceData m_data;
    private EResource m_resourceType;
    private int m_resourceAmount;
    private int m_currentHealth;
    private int m_maxHealth;

    private void Awake()
    {
        m_resourceType = m_data.ResourceType;
        m_resourceAmount = m_data.ResourceAmount;
        m_currentHealth = m_data.Health;
        m_maxHealth = m_data.Health;
        m_renderer.sprite = m_data.Sprite;
    }

    public override void Damage(int amount)
    {
        m_currentHealth -= amount;
        m_currentHealth = Mathf.Max(m_currentHealth, 0);
        if (m_currentHealth == 0)
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
