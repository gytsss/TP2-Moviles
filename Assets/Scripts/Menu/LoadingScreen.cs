using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    #region EXPOSED_FIELDS

    [SerializeField] private GameObject loadingScreen;

    #endregion

    #region UNITY_CALLS

    private void Awake()
    {
        loadingScreen.SetActive(false);
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    #endregion

    #region PUBLIC_METHODS

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    #endregion
}