using UnityEngine;
using UnityEngine.Events;

public class MenuButtonsController : MonoBehaviour
{
    [Header("References")]
    public StartLevelButton startLevelButton;

    [Header("Buttons Settings")]
    public ChooseLevelButton choosenButton;

    [Header("Events")]
    public UnityEvent OnLevelSet;

    private void Start()
    {
        OnLevelSet.AddListener(startLevelButton.InitLevelSet);
    }

    public void DeselectChosenButton()
    {
        if (choosenButton == null) return;

        choosenButton.unchooseFeedback.PlayFeedbacks();
        choosenButton = null;
    }
}