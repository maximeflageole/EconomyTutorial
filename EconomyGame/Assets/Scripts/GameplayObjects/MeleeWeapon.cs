using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private int m_damage = 10;

    public int GetDamage()
    {
        return m_damage;
    }
}
