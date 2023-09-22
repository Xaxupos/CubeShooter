using System.Collections;
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

    public void LoadMainMenu()
    {
        LevelDataStorageManager.Instance.isLevelSelected = false;
        fadeTransitionManager.FadeIn(() => LoadSceneAsync("Main Menu"));
    }

    public void LoadGameLevel(LevelDataSO levelData)
    {
        fadeTransitionManager.FadeIn(() => LoadSceneAsync(levelData.sceneToLoadName)) ;
    }

    private void LoadSceneAsync(string levelName)
    {
        var operation = SceneManager.LoadSceneAsync(levelName);
        StartCoroutine(CheckLoadingComplete(operation));
    }

    public IEnumerator CheckLoadingComplete(UnityEngine.AsyncOperation asyncOperation)
    {
        while (!asyncOperation.isDone)
            yield return null;

        fadeTransitionManager.FadeOut(null);
    }
}