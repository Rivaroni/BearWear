using UnityEngine;
using UnityEngine.UI;

public class ShirtSelection : MonoBehaviour
{
    private Sprite shirtSprite;
    public SpriteRenderer bearShirtSprite; // Actual bear shirt sprite

    private void Start()
    {
        shirtSprite = GetComponent<Image>().sprite;
        DeactivateAllShirts();
    }

    public void ActivateShirt()
    {
        // Deactivate all shirts
        DeactivateAllShirts();

        // Activate the selected shirt
        bearShirtSprite.sprite = shirtSprite;
    }

    public void DeactivateAllShirts()
    {
        bearShirtSprite.sprite = null;
    }
}
