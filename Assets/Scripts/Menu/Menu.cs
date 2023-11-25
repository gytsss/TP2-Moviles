using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private string level1SceneName = "Level1";
    [SerializeField] private string level2SceneName = "Level2";
    [SerializeField] private string level3SceneName = "Level3";
    [SerializeField] private string levelSelectorSceneName = "LevelSelector";
    [SerializeField] private string creditsSceneName = "Credits";
    [SerializeField] private string mainMenuSceneName = "Menu";
    [SerializeField] private string optionsSceneName = "Options";
    [SerializeField] private string shopSceneName = "Shop";

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
        LoadScene(level1SceneName);
    }
    public void PlayLevel2()
    {
        LoadScene(level2SceneName);
    }
    public void PlayLevel(int level)
    {
        switch (level)
        {
            case 1:
                LoadScene(level1SceneName);
                break;
            case 2:
                LoadScene(level2SceneName);
                break;
            case 3:
                LoadScene(level3SceneName);
                break;
            case 4:
                Debug.Log("No hay mas niveles, volviendo al menu!");
                GoMainMenu();
                break;
                
        }
    }
    public void PlayLevel3()
    {
        LoadScene(level3SceneName);
    }
    public void PlayLevelSelector()
    {
        LoadScene(levelSelectorSceneName);
    }

    public void ShowCredits()
    {
        LoadScene(creditsSceneName);
    }

    public void GoMainMenu()
    {
        LoadScene(mainMenuSceneName);
    }
    public void GoShop()
    {
        LoadScene(shopSceneName);
    }

    public void GoOptions()
    {
        LoadScene(optionsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
