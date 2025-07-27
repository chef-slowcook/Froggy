using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FlyAnimation : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAnimation()
    {
        animator.Play("Fly_Idle");
    }

    public void StopAnimation()
    {
        animator.StopPlayback();
    }

}
