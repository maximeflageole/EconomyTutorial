using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_amount;

    public void UpdateAmount(int amount)
    {
        m_amount.text = amount.ToString();
    }
}