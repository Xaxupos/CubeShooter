using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup gameOverPanel;
    public Button returnToMenuButton;
    public TMP_Text levelName;
    public TMP_Text enemiesLeftCount;

    [Header("Settings")]
    public float gameOverScreenFade = 0.5f;

    private void Start()
    {
        UpdateLevelName(LevelDataStorageManager.Instance.currentLevelData.levelName);
        UpdateEnemiesLeftCount(LevelDataStorageManager.Instance.currentLevelData.squareCount);

        returnToMenuButton.onClick.AddListener(LoadingManager.Instance.LoadMainMenu);
    }

    public void ShowGameOverScreen()
    {
        gameOverPanel.gameObject.SetActive(true);
        gameOverPanel.DOFade(1f, gameOverScreenFade);
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