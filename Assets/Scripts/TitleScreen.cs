using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimationController : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public string animationName; // Name of the animation to play

    private void Start()
    {
        // Find the Animator component on the same GameObject or a specified one
        if (animator == null)
            animator = GetComponent<Animator>();

        // Attach the button click event handler
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayAnimation);
    }

    private void PlayAnimation()
    {
        // Play the specified animation
        animator.Play(animationName);
    }
}
