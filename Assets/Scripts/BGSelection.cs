using UnityEngine;

public class BGSelection : MonoBehaviour
{
    public SpriteRenderer bearSprite;
    public Sprite[] bgSprites;
    public int bgSpriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBearSprite();
    }

    public void NextBG()
    {
        // Increment the index and wrap around if it goes out of bounds
        bgSpriteIndex += 1;

        if (bgSpriteIndex >= bgSprites.Length)
        {
            bgSpriteIndex = 0;
        }
        Debug.Log("Next Func" + bgSpriteIndex);
        UpdateBearSprite();
    }

    public void PrevBG()
    {
        // Decrement the index and wrap around if it goes out of bounds
        bgSpriteIndex -= 1;
   
        if (bgSpriteIndex < 0)
        {
            bgSpriteIndex = bgSprites.Length - 1;
        }

        Debug.Log("Prev Func" + bgSpriteIndex);
        UpdateBearSprite();
    }

    private void UpdateBearSprite()
    {
        bearSprite.sprite = bgSprites[bgSpriteIndex];
    }
}
