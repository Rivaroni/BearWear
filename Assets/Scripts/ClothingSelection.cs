using UnityEngine;
using UnityEngine.UI;

public class ClothingSelection : MonoBehaviour
{
    private Sprite clothingSprite;
    public SpriteRenderer bearClothingSprite; // Actual bear shirt sprite
    public SpriteRenderer optionalSprite = null; // Optional

    private void Start()
    {
        clothingSprite = GetComponent<Image>().sprite;
        if(optionalSprite == null)
        {
            optionalSprite = bearClothingSprite;
        }
        DeactivateAllShirts();
    }

    public void ActivateShirt()
    {
        // Deactivate all shirts
        DeactivateAllShirts();

        // Activate the selected shirt
        bearClothingSprite.sprite = clothingSprite;
    }

    public void DeactivateAllShirts()
    {
        if (optionalSprite == null)
        {
            optionalSprite = bearClothingSprite;
        }

        bearClothingSprite.sprite = null;
        optionalSprite.sprite = null;
    }
}
