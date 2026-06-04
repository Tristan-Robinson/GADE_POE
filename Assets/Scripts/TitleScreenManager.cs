using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject mainMenuPanel;
    public GameObject playMenuPanel;
    public GameObject levelSelectPanel;

    public void StartGame()
    {
        mainMenuPanel.SetActive(true);
        playMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
    }

    //Play Menu
    public void OpenPlayMenu()
    {
        mainMenuPanel.SetActive(false);
        playMenuPanel.SetActive(true);
    }

    //New Game
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    //Level Select
    public void OpenLevelSelect()
    {
        playMenuPanel.SetActive(false);
        levelSelectPanel.SetActive(true);
    }
    public void CloseLevelSelect()
    {
        mainMenuPanel.SetActive(true);
        levelSelectPanel.SetActive(false);
    }

    //Levels
    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(3);
    }

    public void ClosePlayMenu()
    {
        mainMenuPanel.SetActive(true);
        playMenuPanel.SetActive(false);
    }

    //Settings Menu
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    //Close Game
   public void QuitGame()
    {
        Application.Quit();
    }
}
