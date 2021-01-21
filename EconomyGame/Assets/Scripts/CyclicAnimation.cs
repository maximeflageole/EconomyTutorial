using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CyclicAnimation
{
    [SerializeField] public AnimationCurve m_animationCurve;
    [SerializeField] public float m_cycleTime;
    [SerializeField] public float m_lowerValue;
    [SerializeField] public float m_upperValue;

    public float Evaluate(float time)
    {
        var cycleTime = (time % m_cycleTime)/m_cycleTime;
        var eval =  m_animationCurve.Evaluate(cycleTime);
        Debug.Log(eval);
        return (m_lowerValue + eval * (m_upperValue - m_lowerValue));
    }
}
