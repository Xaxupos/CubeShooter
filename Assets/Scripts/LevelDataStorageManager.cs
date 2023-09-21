using UnityEngine;

public class LevelDataStorageManager : MonoBehaviour
{
    [Header("Storage Info")]
    public bool isLevelSelected;
    public LevelDataSO currentLevelData;

    #region Singleton Setup
    public static LevelDataStorageManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
}