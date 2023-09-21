using MoreMountains.Feedbacks;
using UnityEngine;

public class ChooseLevelButton : MonoBehaviour
{
    [Header("References")]
    public MMF_Player chooseFeedback;
    public MMF_Player unchooseFeedback;
    public MenuButtonsController buttonsController;
    public LevelDataSO levelToSelect;

    public void SetLevel()
    {
        if (buttonsController.choosenButton != null && buttonsController.choosenButton == this) return;

        buttonsController.DeselectChosenButton();

        chooseFeedback.PlayFeedbacks();
        buttonsController.choosenButton = this;
        buttonsController.OnLevelSet?.Invoke();

        LevelDataStorageManager.Instance.currentLevelData = levelToSelect;
        LevelDataStorageManager.Instance.isLevelSelected = true;
    }
}