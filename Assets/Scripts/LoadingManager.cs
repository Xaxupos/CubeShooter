using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [Header("References")]
    public FadeTransitionManager fadeTransitionManager;

    #region Singleton Setup
    public static LoadingManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    public void LoadGameLevel(LevelDataSO levelData)
    {
        fadeTransitionManager.FadeIn(() => LoadSceneAsync(levelData));
    }

    private void LoadSceneAsync(LevelDataSO levelData)
    {
        var operation = SceneManager.LoadSceneAsync(levelData.sceneToLoadName);
        StartCoroutine(CheckLoadingComplete(operation));
    }

    public IEnumerator CheckLoadingComplete(UnityEngine.AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
            yield return null;

        fadeTransitionManager.FadeOut(null);
    }
}