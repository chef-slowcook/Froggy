using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FrogAnimation : MonoBehaviour
{
    [Header("Component References")]
    private Animator animator;
    [Header("Animation States")]
    private string currentAnimation;
    public const string FROG_IDLE = "Froggy_Idle";
    public const string FROG_CROUCH_IDLE = "Froggy_CrouchIdle";
    public const string FROG_CROUCH = "Froggy_Crouch";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
        ChangeAnimation(FROG_IDLE);
    }

    public void ChangeAnimation(string newAnimation)
    {
        if (currentAnimation == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimation = newAnimation;
    }

    public string GetCurrentAnimation()
    {
        return currentAnimation;
    }
}