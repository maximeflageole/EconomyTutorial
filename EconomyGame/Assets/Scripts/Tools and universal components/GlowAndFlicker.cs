using System;
using UnityEngine;

public class GlowAndFlicker : MonoBehaviour
{
    [SerializeField] private Gradient m_colors;
    [SerializeField] private AnimationCurve m_sizeOverTime;
    [SerializeField] private float m_loopTime;
    private SpriteRenderer m_spriteRenderer;
    private float m_currentTime = 0;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        m_currentTime %= m_loopTime;
        m_currentTime += Time.deltaTime;
        float timePercentage = m_currentTime / m_loopTime;
        m_spriteRenderer.color = m_colors.Evaluate(timePercentage);
        float currentSize = m_sizeOverTime.Evaluate(timePercentage);
        transform.localScale = new Vector3(currentSize, currentSize, currentSize);
    }
}
