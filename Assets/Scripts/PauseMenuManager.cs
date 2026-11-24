using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuPanel;

    private void Start()
    {
        PauseMenuPanel.SetActive(false);
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !PauseMenuPanel.activeSelf)
        {
            OpenPauseMenu();
        } 
        else if (Keyboard.current.escapeKey.wasPressedThisFrame && PauseMenuPanel.activeSelf)
        {
            ClosePauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        PauseMenuPanel.SetActive(true);
    }

    private void ClosePauseMenu()
    {
        PauseMenuPanel.SetActive(false);
    }
}
