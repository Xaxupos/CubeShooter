using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelButton : MonoBehaviour
{
    [Header("References")]
    public GameObject dpadObject;
    public MMF_Player onLevelSetFeedbacks;
    public Image backgroundImage;

    [Header("Settings")]
    public Sprite levelSetSprite;
    public bool initDone = false;

    public void InitLevelSet()
    {
        if (initDone) return;

        backgroundImage.sprite = levelSetSprite;
        dpadObject.SetActive(true);
        onLevelSetFeedbacks.PlayFeedbacks();
        initDone = true;
    }

    public void LoadLevel()
    {
        if(!initDone) return;

        LoadingManager.Instance.LoadGameLevel(LevelDataStorageManager.Instance.currentLevelData);
    }

}