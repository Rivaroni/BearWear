using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeselectAll : MonoBehaviour
{
    public SpriteRenderer[] sprites;

    public void DeselectAllSprites()
    {
        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sprite = null;
        }
    }
}
