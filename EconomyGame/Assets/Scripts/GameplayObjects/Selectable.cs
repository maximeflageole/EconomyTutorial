using UnityEngine;

public class Selectable : MonoBehaviour
{
    public Selector m_selector;
    
    public void OnAttachSelector(Selector selector)
    {
        m_selector = selector;
        selector.transform.parent = transform;
        selector.transform.localPosition = Vector3.zero;
    }

    public void OnDetachSelector()
    {
        m_selector = null;
    }
    
    public virtual void Damage(int amount)
    {
        
    }

    public virtual void Die()
    {
        if (m_selector != null)
        {
            m_selector.Detach();
        }
        Destroy(gameObject);
    }
}
