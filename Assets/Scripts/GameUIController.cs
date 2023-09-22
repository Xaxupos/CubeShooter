using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [Header("References")]
    public TMP_Text levelName;
    public TMP_Text enemiesLeftCount;

    #region Singleton Setup
    public static GameUIController Instance;

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
        UpdateLevelName(LevelDataStorageManager.Instance.currentLevelData.levelName);
        UpdateEnemiesLeftCount(LevelDataStorageManager.Instance.currentLevelData.squareCount);
    }


    public void UpdateLevelName(string lvlName)
    {
        levelName.text = lvlName;
    }

    public void UpdateEnemiesLeftCount(int enemiesLeft)
    {
        enemiesLeftCount.text = enemiesLeft.ToString();
    }
}
