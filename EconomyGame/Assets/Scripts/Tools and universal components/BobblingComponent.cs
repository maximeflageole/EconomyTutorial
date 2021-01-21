using UnityEngine;

public class BobblingComponent : MonoBehaviour
{
    [SerializeField] private float m_amplitude;
    [SerializeField] private float m_frequency;
    [SerializeField] private AnimationCurve m_animation;
    private float m_currentTimer;
    private float m_yOffset;

    void Start()
    {
        m_yOffset = transform.localPosition.y;
    }
    // Update is called once per frame
    void Update()
    {
        m_currentTimer += Time.deltaTime;
        m_currentTimer %= m_frequency;

        var localPosition = transform.localPosition;
        localPosition = new Vector3(localPosition.x, m_yOffset + m_animation.Evaluate(m_currentTimer/m_frequency) * m_amplitude,  localPosition.z);
        transform.localPosition = localPosition;
    }
}
