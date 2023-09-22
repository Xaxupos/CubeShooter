using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawnManager : MonoBehaviour
{
    [Header("References")]
    public Square squarePrefab;

    [Header("Settings")]
    public List<Square> remainingSquares = new List<Square>();

    #region Singleton Setup
    public static SquareSpawnManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    private void Start()
    {
        Camera.main.orthographicSize = LevelDataStorageManager.Instance.currentLevelData.cameraSize;
        StartCoroutine(SpawnInitialSquares());
    }

    private IEnumerator SpawnInitialSquares()
    {
        remainingSquares = new List<Square>();

        for(int i=0; i< LevelDataStorageManager.Instance.currentLevelData.squareCount; i++)
        {
            Square square = Instantiate(squarePrefab);
            remainingSquares.Add(square);
            square.SetSquareRandomFreePosition();
            square.spawnFeedback.PlayFeedbacks();
            square.squareSpriteRenderer.color = LevelDataStorageManager.Instance.currentLevelData.squareColor;
            yield return new WaitForFixedUpdate();
        }
    }

    //Created this so the coroutine doesn't end after object being disabled.
    //Could also just disable sprite renderer and collider
    //but I wanted to make it this way, it's more readable and gives more control
    public IEnumerator RespawnCoroutine(Square square, float delay)
    {
        yield return new WaitForSeconds(delay);

        square.gameObject.SetActive(true);
        square.SetSquareRandomFreePosition();
        square.spawnFeedback.PlayFeedbacks();
    }
}