using UnityEngine;

[CreateAssetMenu(fileName = "ClothingDatabase", menuName = "BearWear/Clothing Database")]
public class ClothingDatabase : ScriptableObject
{
    public ClothingItems hats;
    public ClothingItems pants;
    public ClothingItems socks;
    public ClothingItems shorts;

    [System.Serializable]
    public class ClothingItems
    {
        public Sprite[] items;

        public Sprite GetItemByName(string name)
        {
            foreach (var item in items)
            {
                if (item != null && item.name == name)
                {
                    return item;
                }
            }
            return null; // Or handle the case where the item is not found.
        }
    }

    public Sprite GetSpriteByName(string category, string name)
    {
        switch (category)
        {
            case "Hats": return hats.GetItemByName(name);
            case "Pants": return pants.GetItemByName(name);
            case "Socks": return socks.GetItemByName(name);
            case "Shorts": return shorts.GetItemByName(name);
            default: return null; // Or throw an error if the category is unknown.
        }
    }
}
