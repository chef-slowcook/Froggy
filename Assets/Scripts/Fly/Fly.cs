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
        flyAnimation = GetComponent<FlyAnimation>();
        flyMovement = GetComponent<FlyMovement>();
        StartMoving();
    }
    public void StartMoving()
    {
        flyMovement.StartMoving(pivot);
    }

    public void StopMoving()
    {
        flyMovement.StopMoving();
    }
}
