using UnityEngine;

[RequireComponent(typeof(TongueLaunch), typeof(TongueAim), typeof(TongueAnimation))]
public class Tongue : MonoBehaviour
{
    [Header("Script References")]
    private TongueLaunch tongueLaunch;
    private TongueAim tongueAim;
    private TongueAnimation tongueAnimation;

    [Header("Component References")]
    [SerializeField] private Transform originPivot;

    void Start()
    {
        tongueAim = GetComponent<TongueAim>();
        tongueAnimation = GetComponent<TongueAnimation>();
        tongueLaunch = GetComponent<TongueLaunch>();
        RetractTongue();
    }

    // This is called from the FrogController script
    public void ProjectTongue()
    {
        tongueAim.StopAiming();
        tongueAnimation.StartDrawing(originPivot, transform);
        tongueLaunch.LaunchToMouse(originPivot);
    }

    // This is called from the FrogController script
    public void RetractTongue()
    {
        tongueAim.StartAiming(originPivot);
        tongueAnimation.StopDrawing();
    }
}