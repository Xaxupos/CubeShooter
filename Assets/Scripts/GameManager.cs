
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameUIController gameUIController;

    [Header("Settings")]
    public List<Square> remainingSquares = new List<Square>();

    [Header("Events")]
    public UnityEvent OnSquareRemovedCompletely;

    private void Start()
    {
        OnSquareRemovedCompletely.AddListener(() => gameUIController.UpdateEnemiesLeftCount(remainingSquares.Count));
    }

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
}
