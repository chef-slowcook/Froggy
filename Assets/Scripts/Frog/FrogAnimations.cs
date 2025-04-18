using UnityEngine;

public class FrogAnimations : MonoBehaviour
{
    [Header("Component References")]
    Animator animator;
    [Header("Animation States")]
    [SerializeField] const string FROG_IDLE = "frog_idle";
    [SerializeField] const string FROG_CHARGEJUMP = "frog_chargeJump";
    [SerializeField] const string FROG_JUMP = "frog_jump";
    [SerializeField] const string FROGUE_TONGUESHOOT = "frog_tongueShoot";
    private string currentAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeAnimation(FROG_IDLE);
    }

    void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }
}
