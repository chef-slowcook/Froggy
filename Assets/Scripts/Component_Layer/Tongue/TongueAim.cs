using System.Collections;
using UnityEngine;

// Component class for aiming the tongue
public class TongueAim : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb2d;

    [Header("Rotation Parameters")]
    [SerializeField] private float rotationSpeed = 100f;

    [Header("Boolean Flags")]
    private bool isAiming = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void StartAiming(Transform originPivot)
    {
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.linearVelocity = Vector2.zero;
        isAiming = true;
        StartCoroutine(Aim(originPivot));
    }

    private IEnumerator Aim(Transform originPivot)
    {
        while (isAiming)
        {
            TongueRotation(originPivot);
            yield return null; // Wait for next frame
        }
    }

    public void StopAiming()
    {
        isAiming = false;
    }

    // Would be called every frame
    public void TongueRotation(Transform originPivot)
    {
        // Get the target direction
        Vector3 aimDirection = MouseAssistant.DirectionToMouse(originPivot);
        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.FromToRotation(Vector3.right, aimDirection);
        // Smoothly rotate towards the target rotation
        originPivot.rotation = Quaternion.RotateTowards(originPivot.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb2d.MovePosition(originPivot.position + aimDirection * 0.1f);
    }
}
