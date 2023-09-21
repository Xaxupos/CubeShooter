using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableExtension : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Events")]
    public UnityEvent OnSelect;
    public UnityEvent OnDeselect;

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnSelect?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnDeselect?.Invoke();
    }
}