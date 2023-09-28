using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeselectAll : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public AudioClip deselectClip;

    public void DeselectAllSprites()
    {
        AudioManagerScript.instance.PlaySoundEffect(deselectClip);
        for(int i = 0; i < sprites.Length; i++)
        {
            sprites[i].sprite = null;
        }
    }
}
