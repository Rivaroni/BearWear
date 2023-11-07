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

    public BGSelection[] bgScript;

    private Sprite RandomSprite(Sprite[] spriteArray, bool allowEmpty = false)
    {
        // Check if the spriteArray is empty or null
        if (spriteArray == null || spriteArray.Length == 0)
        {
            Debug.LogError("The sprite array is empty or null.");
            return null; // Or alternatively, return a default sprite
        }

        // Decide whether to leave this slot empty, only if allowed
        if (allowEmpty && Random.value < 0.35f) // 20% chance to leave empty
        {
            return null;
        }

        // Generate a random index within the bounds of the array
        int randomIndex = Random.Range(0, spriteArray.Length);

        // Return the random sprite
        return spriteArray[randomIndex];
    }

    public void RandomClothingSelection()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx);
        // Ensure bearSpriteRenderer.sprite is never null by not allowing an empty selection
        bearSpriteRenderer.sprite = RandomSprite(bearColorSprites, false); // false to not allow empty
                                                                           // For other sprites, it's okay to be null as per your original logic
        bgSpriteRenderer.sprite = RandomSprite(bgSprites, true);
        hatSpriteRenderer.sprite = RandomSprite(hatSprites, true);
        accessoriesSpriteRenderer.sprite = RandomSprite(accessoriesSprites, true);
        shirtSpriteRenderer.sprite = RandomSprite(shirtSprites, true);
        jacketSpriteRenderer.sprite = RandomSprite(jacketSprites, true);
        pantsSpriteRenderer.sprite = RandomSprite(pantsSprites, true);
        socksSpriteRenderer.sprite = RandomSprite(socksSprites, true);
        shoesSpriteRenderer.sprite = RandomSprite(shoesSprites, true);

        for (int i = 0; i < bgScript.Length; i++)
        {
            bgScript[i].InitializeIndex();
        }
    }


}
