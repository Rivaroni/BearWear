using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomClothingScript : MonoBehaviour
{
    public AudioClip clickSfx;

    public Sprite[] bearColorSprites;
    public Sprite[] bgSprites;
    public Sprite[] hatSprites;
    public Sprite[] accessoriesSprites;
    public Sprite[] shirtSprites;
    public Sprite[] jacketSprites;
    public Sprite[] pantsSprites;
    public Sprite[] socksSprites;
    public Sprite[] shoesSprites;

    public SpriteRenderer bearSpriteRenderer;
    public SpriteRenderer bgSpriteRenderer;
    public SpriteRenderer hatSpriteRenderer;
    public SpriteRenderer accessoriesSpriteRenderer;
    public SpriteRenderer shirtSpriteRenderer;
    public SpriteRenderer jacketSpriteRenderer;
    public SpriteRenderer pantsSpriteRenderer;
    public SpriteRenderer socksSpriteRenderer;
    public SpriteRenderer shoesSpriteRenderer;

    public void RandomClothingSelection()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx);
        // Randomly select sprites for each clothing item
        bearSpriteRenderer.sprite = RandomSprite(bearColorSprites);
        bgSpriteRenderer.sprite = RandomSprite(bgSprites);
        hatSpriteRenderer.sprite = RandomSprite(hatSprites);
        accessoriesSpriteRenderer.sprite = RandomSprite(accessoriesSprites);
        shirtSpriteRenderer.sprite = RandomSprite(shirtSprites);
        jacketSpriteRenderer.sprite = RandomSprite(jacketSprites);
        pantsSpriteRenderer.sprite = RandomSprite(pantsSprites);
        socksSpriteRenderer.sprite = RandomSprite(socksSprites);
        shoesSpriteRenderer.sprite = RandomSprite(shoesSprites);
    }

    private Sprite RandomSprite(Sprite[] spriteArray)
    {
        // Check if the spriteArray is empty
        if (spriteArray == null || spriteArray.Length == 0)
        {
            Debug.LogError("The sprite array is empty.");
            return null;
        }

        // Generate a random index within the bounds of the array
        int randomIndex = Random.Range(0, spriteArray.Length);

        // Return the random sprite
        return spriteArray[randomIndex];
    }
}
