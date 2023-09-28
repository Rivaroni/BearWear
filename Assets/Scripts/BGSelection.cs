using UnityEngine;

public class BGSelection : MonoBehaviour
{
    public SpriteRenderer bearSprite;
    public Sprite[] bgSprites;
    public int bgSpriteIndex = 0;
    public AudioClip clickSfx;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBearSprite();
    }

    public void NextBG()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);
        // Increment the index and wrap around if it goes out of bounds
        bgSpriteIndex += 1;

        if (bgSpriteIndex >= bgSprites.Length)
        {
            bgSpriteIndex = 0;
        }

        UpdateBearSprite();
    }

    public void PrevBG()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);
        // Decrement the index and wrap around if it goes out of bounds
        bgSpriteIndex -= 1;
   
        if (bgSpriteIndex < 0)
        {
            bgSpriteIndex = bgSprites.Length - 1;
        }

        UpdateBearSprite();
    }

    private void UpdateBearSprite()
    {
        bearSprite.sprite = bgSprites[bgSpriteIndex];
    }
}
