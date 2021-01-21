using System;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] private Transform m_mainCharTransform;
    [SerializeField] private CircleCollider2D m_rangeCollider;
    [SerializeField] private float m_radius;
    [SerializeField] private Transform m_selector;
    [SerializeField] private CyclicAnimation m_selectorAnim;
    private Selectable m_selectedObject;

    private void Start()
    {
        m_rangeCollider.radius = m_radius;
    }

    public void Hit(int damage)
    {
        if (m_selectedObject != null)
        {
            m_selectedObject.Damage(damage);
        }
    }
    
    void Update()
    {
        UpdateLocking();
        if (m_selectedObject == null)
            return;
        UpdateSelectionAnimation();
    }

    private void UpdateLocking()
    {
        var layer = LayerMask.GetMask("Selectables");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layer);

        if (hit.collider != null)
        {
            if (!m_rangeCollider.IsTouching(hit.collider))
            {
                Detach();
                return;
            }
            var selectable = hit.collider.GetComponent<Selectable>();
            if (selectable != null)
            {
                if (m_selectedObject == null || selectable != m_selectedObject)
                {
                    Attach(selectable);
                }
                return;
            }
        }
        Detach();
    }

    private void Attach(Selectable selectable)
    {
        if (m_selectedObject != null)
        {
            m_selectedObject.OnDetachSelector();
        }
        selectable.OnAttachSelector(this);
        m_selector.GetComponent<SpriteRenderer>().enabled = true;
        m_selectedObject = selectable;
    }
    
    public void Detach()
    {
        if (m_selectedObject == null)
        {
            return;
        }
        m_selectedObject.OnDetachSelector();
        m_selector.GetComponent<SpriteRenderer>().enabled = false;
        m_selector.parent = m_mainCharTransform;
        m_selectedObject = null;
    }

    private void UpdateSelectionAnimation()
    {
        var scale = m_selectorAnim.Evaluate(Time.time);
        m_selector.localScale = new Vector3(scale, scale, scale);
    }
}
