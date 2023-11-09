using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName; // Name of the animation to play
    public bool playAnimation = false;
    public bool alreadyClicked = false;
    public GameObject clickToStart;

    private void Start()
    {
        // Find the Animator component on the same GameObject or a specified one
        if (animator == null)
            animator = GetComponent<Animator>();

        //TODO: fix bug so that u always click to start for beginning of game
        if(PlayerPrefs.GetInt("Active") == 1)
        {
            alreadyClicked = true;
        }

        // Attach the button click event handler
        Button button = GetComponent<Button>();
        if(playAnimation || alreadyClicked)
        {
            if (clickToStart.activeInHierarchy)
                clickToStart.SetActive(false);
            PlayAnimation();
        }
        else
        {
            button.onClick.AddListener(PlayAnimation);
            PlayerPrefs.SetInt("Active", 1);
        }
 
    }

    private void PlayAnimation()
    {
        // Play the specified animation
        animator.Play(animationName);
    }

    public void CloseAnimation()
    {
        if(clickToStart.activeInHierarchy)
            clickToStart.SetActive(false);
        animator.Play("CloseCurtain");
    }
}
