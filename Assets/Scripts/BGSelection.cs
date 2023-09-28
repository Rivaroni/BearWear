using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGSelection : MonoBehaviour
{
    public SpriteRenderer bearSprite;
    public Sprite[] bgSprites;
    private int bgSpriteIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateBearSprite();
    }

    public void NextBG()
    {
        // Check if bgSprites is empty or bearSprite is null
        if (bgSprites.Length == 0 || bearSprite == null)
        {
            Debug.LogError("bgSprites is empty or bearSprite is not set.");
            return;
        }

        bgSpriteIndex = (bgSpriteIndex + 1) % bgSprites.Length;
        UpdateBearSprite();
    }

    public void PrevBG()
    {
        // Check if bgSprites is empty or bearSprite is null
        if (bgSprites.Length == 0 || bearSprite == null)
        {
            Debug.LogError("bgSprites is empty or bearSprite is not set.");
            return;
        }

        bgSpriteIndex = (bgSpriteIndex - 1 + bgSprites.Length) % bgSprites.Length;
        UpdateBearSprite();
    }

    private void UpdateBearSprite()
    {
        Debug.Log(bgSpriteIndex);
        bearSprite.sprite = bgSprites[bgSpriteIndex];
    }
}
