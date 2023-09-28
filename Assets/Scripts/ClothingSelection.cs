using UnityEngine;
using UnityEngine.UI;

public class ClothingSelection : MonoBehaviour
{
    private Sprite clothingSprite;
    public SpriteRenderer bearClothingSprite; // Actual bear shirt sprite
    public SpriteRenderer optionalSprite = null; // Optional
    public AudioClip selectedClip;
    public AudioClip deselectedClip;
    private bool start;

    private void Start()
    {
        clothingSprite = GetComponent<Image>().sprite;
        if(optionalSprite == null)
        {
            optionalSprite = bearClothingSprite;
        }
        start = true;
        DeactivateClothingLayer();
    }

    public void ActivateShirt()
    {
        // Deactivate all shirts
        DeactivateClothingLayer();

        // Activate the selected shirt
        AudioManagerScript.instance.PlaySoundEffect(selectedClip);
        bearClothingSprite.sprite = clothingSprite;
    }

    public void DeactivateClothingLayer()
    {
        if (optionalSprite == null)
        {
            optionalSprite = bearClothingSprite;
        }

        if(start)
        {
            start = false;
            bearClothingSprite.sprite = null;
            optionalSprite.sprite = null;
            return;
        }
        AudioManagerScript.instance.PlaySoundEffect(deselectedClip);
        bearClothingSprite.sprite = null;
        optionalSprite.sprite = null;
    }
}
