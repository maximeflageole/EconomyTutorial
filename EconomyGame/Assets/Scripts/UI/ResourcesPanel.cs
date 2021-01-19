using UnityEngine;

public class ResourcesPanel : MonoBehaviour
{
    //TODO: Abstract this into a dictionary in a later episode
    [SerializeField] private ResourcePanel m_copperResourcePanel;
    [SerializeField] private ResourcePanel m_ironResourcePanel;

    public void UpdateCopper(int newAmount)
    {
        m_copperResourcePanel.UpdateAmount(newAmount);
    }

    public void UpdateIron(int newAmount)
    {
        m_ironResourcePanel.UpdateAmount(newAmount);
    }
}
