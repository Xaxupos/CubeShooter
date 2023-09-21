using DG.Tweening;
using System;
using UnityEngine;

public class FadeTransitionManager : MonoBehaviour
{
    [Header("References")]
    public CanvasGroup transitionCanvasGroup;

    [Header("Settings")]
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 1.0f;

    public void FadeIn(Action onComplete)
    {
        transitionCanvasGroup.DOFade(1, fadeInTime).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }

    public void FadeOut(Action onComplete)
    {
        transitionCanvasGroup.DOFade(0, fadeOutTime).SetEase(Ease.Linear).SetUpdate(true).OnComplete(() =>
        {
            onComplete?.Invoke();
        });
    }
}