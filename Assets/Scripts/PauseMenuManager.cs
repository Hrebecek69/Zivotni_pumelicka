using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject SettingsMenuPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        PauseMenuPanel.SetActive(true);
        SettingsMenuPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        PauseMenuPanel.SetActive(false);
        SettingsMenuPanel.SetActive(true);
    }
}
