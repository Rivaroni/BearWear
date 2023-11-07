using System.Collections.Generic;
using UnityEngine;

public class SaveFitManager : MonoBehaviour
{
    // List to hold saved clothing arrays
    private List<Sprite[]> savedClothings = new List<Sprite[]>();

    public SpriteRenderer[] bearClothingRef;

    private void Start()
    {
        // Initialize the list with a specific number of slots.
        for (int i = 0; i < 5; i++)
        {
            savedClothings.Add(new Sprite[bearClothingRef.Length]);
        }
    }

    public void SaveFit()
    {
        Debug.Log("Save");
        for (int i = 0; i < savedClothings.Count; i++)
        {
            if (IsArrayEmpty(savedClothings[i]))
            {
                Debug.Log($"Save in slot {i + 1}");
                StoreFit(savedClothings[i]);
                return; // Break out of the loop once we've saved the fit
            }
        }

        Debug.Log("All slots full");
        // All slots are full, handle this case appropriately.
    }

    public void LoadFit(int index)
    {
        Debug.Log("Load");
        // Subtract 1 from index because list indices are 0-based
        if (index < 1 || index > savedClothings.Count)
        {
            Debug.Log("Invalid slot index.");
            return;
        }

        int slotIndex = index - 1;
        if (!IsArrayEmpty(savedClothings[slotIndex]))
        {
            ReloadFit(savedClothings[slotIndex]);
        }
        else
        {
            Debug.Log($"No fit saved in slot {index} to load.");
        }
    }

    void StoreFit(Sprite[] savedClothing)
    {
        for (int i = 0; i < bearClothingRef.Length; i++)
        {
            savedClothing[i] = bearClothingRef[i].sprite;
        }
    }

    void ReloadFit(Sprite[] savedClothing)
    {
        for (int i = 0; i < bearClothingRef.Length; i++)
        {
            bearClothingRef[i].sprite = savedClothing[i];
        }
    }

    private bool IsArrayEmpty(Sprite[] clothingArray)
    {
        // Assume array is not null as we initialize all in Start()
        foreach (Sprite clothing in clothingArray)
        {
            if (clothing != null)
            {
                return false;
            }
        }
        return true;
    }
}
