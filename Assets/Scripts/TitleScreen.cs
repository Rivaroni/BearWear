using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName; // Name of the animation to play
    public bool playAnimation = false;
    public static bool alreadyClicked = false;
    public GameObject clickToStart;
    public AudioClip curtainSfx;
    bool sfxPlayed = false;

    private void Start()
    {
        // Find the Animator component on the same GameObject or a specified one
        if (animator == null)
            animator = GetComponent<Animator>();

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
            if(!alreadyClicked)
                button.onClick.AddListener(PlayAnimation);
                alreadyClicked = true;
        }
 
    }

    private void PlayAnimation()
    {
        // Play the specified animation
        if(!sfxPlayed && AudioManagerScript.instance != null)
            AudioManagerScript.instance.PlaySoundEffect(curtainSfx, 1.0f);

        sfxPlayed = true;
        animator.Play(animationName);
    }

    public void CloseAnimation()
    {
        AudioManagerScript.instance.PlaySoundEffect(curtainSfx, 0.3f);
        if (clickToStart.activeInHierarchy)
            clickToStart.SetActive(false);
        animator.Play("CloseCurtain");
    }
}
