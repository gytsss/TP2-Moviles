using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private string _gameSceneName = "Game";
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
        LoadScene(_gameSceneName);
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
        UnityEditor.EditorApplication.isPlaying = false;
    }

    #endregion
}
