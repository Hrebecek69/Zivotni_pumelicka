
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject gameOptionsPanel;
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public string gameScene;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        gameOptionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void Play()
    {
        mainMenuPanel.SetActive(false);
        gameOptionsPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    
    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        gameOptionsPanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        gameOptionsPanel.SetActive(false);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
