using UnityEngine;

public class ChangeClothingRacks : MonoBehaviour
{
    public GameObject[] clothingRacks;
    public int rackIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateGameObjects();
    }

    public void NextBG()
    {
        // Increment the index and wrap around if it goes out of bounds
        rackIndex += 1;

        if (rackIndex >= clothingRacks.Length)
        {
            rackIndex = 0;
        }
        Debug.Log("Next Func" + rackIndex);
        DeactivateGameObjects();
    }

    public void PrevBG()
    {
        // Decrement the index and wrap around if it goes out of bounds
        rackIndex -= 1;

        if (rackIndex < 0)
        {
            rackIndex = clothingRacks.Length - 1;
        }

        Debug.Log("Prev Func" + rackIndex);
        DeactivateGameObjects();
    }

    private void DeactivateGameObjects()
    {
        for (int i = 0; i < clothingRacks.Length; i++)
        {
            if (i == rackIndex)
            {
                // Activate the game object at the current index
                clothingRacks[i].SetActive(true);
            }
            else
            {
                // Deactivate all other game objects
                clothingRacks[i].SetActive(false);
            }
        }
    }
}
