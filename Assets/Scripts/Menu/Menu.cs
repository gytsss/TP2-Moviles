using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private string _level1SceneName = "Level1";
    [SerializeField] private string _level2SceneName = "Level2";
    [SerializeField] private string _level3SceneName = "Level3";
    [SerializeField] private string _levelSelectorSceneName = "LevelSelector";
    [SerializeField] private string _creditsSceneName = "Credits";
    [SerializeField] private string _mainMenuSceneName = "Menu";
    [SerializeField] private string _optionsSceneName = "Options";

    #endregion

    #region PUBLIC_METHODS

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayLevel1()
    {
        LoadScene(_level1SceneName);
    }
    public void PlayLevel2()
    {
        LoadScene(_level2SceneName);
    }
    public void PlayLevel3()
    {
        LoadScene(_level3SceneName);
    }
    public void PlayLevelSelector()
    {
        LoadScene(_levelSelectorSceneName);
    }

    public void ShowCredits()
    {
        LoadScene(_creditsSceneName);
    }

    public void GoMainMenu()
    {
        LoadScene(_mainMenuSceneName);
    }

    public void GoOptions()
    {
        LoadScene(_optionsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
