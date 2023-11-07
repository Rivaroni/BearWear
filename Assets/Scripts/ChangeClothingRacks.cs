using System.Collections;
using UnityEngine;

public class ChangeClothingRacks : MonoBehaviour
{
    public GameObject[] clothingRacks;
    public int rackIndex = 0;
    public AudioClip clickSfx;
    public Animator animator;

    private bool isAnimating = false;
    public float seconds = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        DeactivateGameObjects();
    }

    public void NextBG()
    {
        if (!isAnimating)
        {
            AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);

            // Set the "DropCurtain" trigger
            animator.SetTrigger("DropCurtain");

            // Start a coroutine to wait for the animation to complete
            StartCoroutine(WaitForAnimation("DropCurtain", "next"));

            // Rest of your code after the animation
            DeactivateGameObjects();
        }
    }

    public void PrevBG()
    {
        if (!isAnimating)
        {
            AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);

            // Set the "DropCurtain" trigger
            animator.SetTrigger("DropCurtain");

            // Start a coroutine to wait for the animation to complete
            StartCoroutine(WaitForAnimation("DropCurtain", "prev"));

        }
    }

    private IEnumerator WaitForAnimation(string animationTrigger, string state)
    {
        // Ensure the animator is not null
        if (animator != null)
        {
            isAnimating = true;

            // Wait for the animation to complete
            yield return new WaitForSeconds(seconds);

            if(state == "prev")
            {
                rackIndex -= 1;

                if (rackIndex < 0)
                {
                    rackIndex = clothingRacks.Length - 1;
                }
            }
            else
            {
                rackIndex += 1;

                if (rackIndex >= clothingRacks.Length)
                {
                    rackIndex = 0;
                }

            }

            // Rest of your code after the animation
            DeactivateGameObjects();

            isAnimating = false;
        }
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
