using System.Collections.Generic;
using UnityEngine;

public class SaveFitManager : MonoBehaviour
{
    [System.Serializable]
    public class Outfit
    {
        public List<string> clothingItems; // Ensure this is public or [SerializeField] if private

        public Outfit(List<string> clothingItems)
        {
            this.clothingItems = clothingItems ?? new List<string>();
        }
    }

    [System.Serializable]
    private class Serialization<T>
    {
        [SerializeField]
        public T[] items;

        public Serialization(T[] items)
        {
            this.items = items;
        }
    }

    private List<Outfit> savedOutfits = new List<Outfit>();
    public SpriteRenderer[] bearClothingRef;
    public GameObject overwriteUI;
    private const string SaveKey = "SavedFits";
    public SpriteManager spriteManager; // Assumed to be a class that manages Sprites

    private void Start()
    {
        overwriteUI.SetActive(false);
        LoadAllFits();

        //RemoveAllPlayerPrefs();

        // Initialize empty outfits if none are loaded
        if (savedOutfits.Count == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                savedOutfits.Add(new Outfit(new List<string>(new string[bearClothingRef.Length])));
            }
        }
    }

    public void SaveFit()
    {
        for (int i = 0; i < savedOutfits.Count; i++)
        {
            if (IsOutfitEmpty(savedOutfits[i]))
            {
                Debug.Log($"Saving outfit in slot {i + 1}.");
                OverwriteSave(i + 1);
                return;
            }
        }

        Debug.Log("All slots full, please overwrite an existing slot.");
        overwriteUI.SetActive(true);
    }

    private void SaveAllFits()
    {
        Serialization<Outfit> outfitSerialization = new Serialization<Outfit>(savedOutfits.ToArray());
        string json = JsonUtility.ToJson(outfitSerialization);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
        Debug.Log("Saved outfits: " + json);
    }

    private void LoadAllFits()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            Serialization<Outfit> outfitSerialization = JsonUtility.FromJson<Serialization<Outfit>>(json);
            if (outfitSerialization != null && outfitSerialization.items != null)
            {
                savedOutfits = new List<Outfit>(outfitSerialization.items);
            }
            Debug.Log("Loaded outfits: " + json);
        }
        else
        {
            Debug.Log("No saved data to load.");
        }
    }

    public void LoadFit(int index)
    {
        if (index < 1 || index > savedOutfits.Count)
        {
            Debug.Log("Invalid slot index.");
            return;
        }

        Outfit outfit = savedOutfits[index - 1];
        bool hasSavedItem = false;

        for (int i = 0; i < outfit.clothingItems.Count; i++)
        {
            string spriteName = outfit.clothingItems[i];
            if (!string.IsNullOrEmpty(spriteName))
            {
                bearClothingRef[i].sprite = GetSpriteByName(spriteName);
                hasSavedItem = true;
            }
            else
            {
                // If it's the first sprite and there's no saved sprite, set it to BearColor_4
                if (i == 0)
                {
                    bearClothingRef[i].sprite = GetSpriteByName("BearColor_4");
                }
                else
                {
                    bearClothingRef[i].sprite = null;
                }
            }
        }

        if (!hasSavedItem)
        {
            Debug.Log($"No outfits saved in loadout {index}, defaulting first sprite to BearColor_4.");
            // TODO: Here you will trigger your UI popup in the future
        }
    }



    public void OverwriteSave(int index)
    {
        if (index < 1 || index > savedOutfits.Count)
        {
            Debug.Log("Invalid slot index.");
            return;
        }

        List<string> currentOutfit = new List<string>();
        foreach (var spriteRenderer in bearClothingRef)
        {
            currentOutfit.Add(spriteRenderer.sprite != null ? spriteRenderer.sprite.name : null);
        }

        savedOutfits[index - 1] = new Outfit(currentOutfit);
        SaveAllFits();

        overwriteUI.SetActive(false);
    }

    private Sprite GetSpriteByName(string name)
    {
        // Implement your logic to get a Sprite by its name
        return spriteManager.GetSpriteByName(name);
    }

    private bool IsOutfitEmpty(Outfit outfit)
    {
        return outfit.clothingItems.TrueForAll(string.IsNullOrEmpty);
    }

    public void RemoveAllPlayerPrefs()
    {
        // Clear PlayerPrefs
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("All PlayerPrefs have been removed.");

        // Clear current outfits list
        savedOutfits.Clear();

        // Optionally reset the bearClothingRef sprites to a default state, if needed
        foreach (var renderer in bearClothingRef)
        {
            renderer.sprite = null; // Or set it to a default sprite
        }

        // Log the removal
        Debug.Log("All loadout saves have been removed from this session.");
    }

}
