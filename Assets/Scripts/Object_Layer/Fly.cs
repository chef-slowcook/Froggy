using UnityEngine;

[RequireComponent(typeof(FlyAnimation), typeof(FlyMovement))]
public class Fly : MonoBehaviour
{
    [Header("Script references")]
    private FlyAnimation flyAnimation;
    private FlyMovement flyMovement;

    private void Awake()
    {
        //Find and assign required components
        flyAnimation = GetComponent<FlyAnimation>();
        flyMovement = GetComponent<FlyMovement>();
    }

    public void StartMoving(Transform pivot)
    {
        flyMovement.StartMoving(pivot);
        flyAnimation.StartAnimation();
    }

    public void StopMoving()
    {
        flyMovement.StopMoving();
        flyAnimation.StopAnimation();
    }
}
