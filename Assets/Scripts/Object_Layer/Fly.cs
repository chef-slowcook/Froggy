using UnityEngine;

[RequireComponent(typeof(FlyAnimation), typeof(FlyMovement))]
public class Fly : MonoBehaviour
{
    [Header("Script references")]
    private FlyAnimation flyAnimation;
    private FlyMovement flyMovement;

    [Header("Target")]
    [SerializeField] private Transform pivot;

    private void Start()
    {
        //Find and assign required components
        flyAnimation = GetComponent<FlyAnimation>();
        flyMovement = GetComponent<FlyMovement>();
        StartMoving();
    }
    public void StartMoving()
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
