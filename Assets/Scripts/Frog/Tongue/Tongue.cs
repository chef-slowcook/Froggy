using UnityEngine;

//Brain class for the tongue system, responsible for launching and aiming the tongue
[RequireComponent(typeof(TongueLaunch), typeof(TongueAim))]
public class Tongue : MonoBehaviour
{
    [Header("Script References")]
    private TongueLaunch tongueLaunch;
    private TongueAim tongueAim;
    [Header("Transform References")]
    [SerializeField] private Transform tonguePivot;
    [Header("Boolean Flags")]
    private bool readyToLaunch = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tongueLaunch = GetComponent<TongueLaunch>();
        tongueAim = GetComponent<TongueAim>();
    }

    void Update()
    {
        tongueAim.DrawTongueLine(tonguePivot.position, transform.position);
        if (readyToLaunch)
        {
            tongueAim.TongueRotation(tonguePivot);
        }
    }

    public void LaunchTongue()
    {
        tongueLaunch.LaunchToMouse(tonguePivot);
        readyToLaunch = false;
    }
    public void PrepareTongue()
    {
        readyToLaunch = true;
    }
}
