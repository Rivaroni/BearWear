using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonEnlargement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = image.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Enlarge the button smoothly using DOTween
        image.transform.DOScale(originalScale * 1.05f, 0.2f); // You can adjust the duration
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Return the button to its original size smoothly
        image.transform.DOScale(originalScale, 0.2f); // You can adjust the duration
    }
}
