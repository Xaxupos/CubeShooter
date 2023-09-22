using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawnManager : MonoBehaviour
{
    [Header("References")]
    public Square squarePrefab;
    public Transform squaresParent;

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
        GameManager.Instance.remainingSquares = new List<Square>();

        for(int i=0; i< LevelDataStorageManager.Instance.currentLevelData.squareCount; i++)
        {
            Square square = Instantiate(squarePrefab);
            GameManager.Instance.remainingSquares.Add(square);
            square.SetSquareRandomFreePosition();
            square.spawnFeedback.PlayFeedbacks();
            square.squareSpriteRenderer.color = LevelDataStorageManager.Instance.currentLevelData.squareColor;
            square.transform.SetParent(squaresParent, true);
            yield return new WaitForFixedUpdate();
        }
    }

    public void StartRespawnCoroutine(Square square, float delay)
    {
        StartCoroutine(RespawnCoroutine(square, delay));
    }

    //Created this so the coroutine doesn't end after object being disabled.
    //Could also just disable sprite renderer and collider
    //but I wanted to make it this way, it's more readable and gives more control
    public IEnumerator RespawnCoroutine(Square square, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (square == null) yield break;

        square.gameObject.SetActive(true);
        square.SetSquareRandomFreePosition();
        square.spawnFeedback.PlayFeedbacks();
    }
}
