using UnityEngine;

public class InfoPopupManager : MonoBehaviour
{
    public GameObject infoPanel;

    public void ShowPanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(true);
            Debug.Log("Info Panel Shown!");
        }
    }

    public void HidePanel()
    {
        if (infoPanel != null)
        {
            infoPanel.SetActive(false);
        }
    }
}
