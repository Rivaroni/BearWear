using UnityEngine;

public class SaveFitManager : MonoBehaviour
{
    public Sprite[] savedClothing1;
    public SpriteRenderer[] bearClothingRef;

    public void SaveFit()
    {
        Debug.Log("Save");
        for (int i = 0; i < bearClothingRef.Length; i++)
        {
            savedClothing1[i] = bearClothingRef[i].sprite;
        }
            
        
    }

    public void LoadFit()
    {
        Debug.Log("Load");
        for (int i = 0; i < bearClothingRef.Length; i++)
        {
            bearClothingRef[i].sprite = savedClothing1[i];
        }


    }
}
