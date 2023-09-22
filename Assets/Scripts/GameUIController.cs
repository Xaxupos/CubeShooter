using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [Header("References")]
    public TMP_Text levelName;
    public TMP_Text enemiesLeftCount;

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