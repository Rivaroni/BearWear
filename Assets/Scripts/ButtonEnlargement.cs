using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonEnlargement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Vector3 originalScale;

    private void Start()
    {
        button = GetComponent<Button>();
        originalScale = button.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Enlarge the button smoothly using DOTween
        button.transform.DOScale(originalScale * 1.1f, 0.2f); // You can adjust the duration
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Return the button to its original size smoothly
        button.transform.DOScale(originalScale, 0.2f); // You can adjust the duration
    }
}
