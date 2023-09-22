
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameUIController gameUIController;

    [Header("Settings")]
    public List<Square> remainingSquares = new List<Square>();
    public bool gameStarted = false;
    public bool gameEnded = false;

    [Header("Events")]
    public UnityEvent OnSquareRemovedCompletely;
    public UnityEvent OnGameOver;

    #region Singleton Setup
    public static GameManager Instance;

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
        OnSquareRemovedCompletely.AddListener(EnemyDie);
    }

    private void EnemyDie()
    {
        gameUIController.UpdateEnemiesLeftCount(remainingSquares.Count);
        if(remainingSquares.Count <= 1)
        {
            gameEnded = true;
            OnGameOver?.Invoke();
        }
    }
}