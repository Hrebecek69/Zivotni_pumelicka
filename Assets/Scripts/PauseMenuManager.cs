using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject SettingsMenuPanel;

    private void Start()
    {
        PauseMenuPanel.SetActive(false);
        SettingsMenuPanel.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
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
