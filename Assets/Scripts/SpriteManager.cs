using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public Dictionary<string, Sprite> spriteDictionary;

    private void Awake()
    {
        spriteDictionary = new Dictionary<string, Sprite>();
        LoadSpritesIntoDictionary("BearWear Assets/backgrounds");
        LoadSpritesIntoDictionary("BearWear Assets/bear colors");
        LoadSpritesIntoDictionary("BearWear Assets/accessories");
        LoadSpritesIntoDictionary("BearWear Assets/hats");
        LoadSpritesIntoDictionary("BearWear Assets/pants");
        LoadSpritesIntoDictionary("BearWear Assets/shirts");
        LoadSpritesIntoDictionary("BearWear Assets/shoes");
        LoadSpritesIntoDictionary("BearWear Assets/socks");
        // ... repeat for each category
    }

    private void LoadSpritesIntoDictionary(string path)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite sprite in sprites)
        {
            spriteDictionary[sprite.name] = sprite;
        }
    }

    public Sprite GetSpriteByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            UnityEngine.Debug.LogWarning("GetSpriteByName called with null or empty name.");
            return null;
        }

        if (spriteDictionary.TryGetValue(name, out Sprite foundSprite))
        {
            // Debug statement for successful retrieval
            return foundSprite;
        }

        UnityEngine.Debug.LogError($"Sprite with name {name} not found.");
        return null;
    }
}
