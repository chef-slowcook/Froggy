using UnityEngine;

public class FlyAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StopAnimation()
    {
        animator.StopPlayback();
    }
}
