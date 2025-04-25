using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Timer))]
public class FrogJump : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb2d;
    private Timer jumpTimer;

    [Header("Parameters")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float maxChargeTime = 3f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jumpTimer = GetComponent<Timer>();
        jumpTimer.SetMaxTime(maxChargeTime);
    }

    private void Jump(float charge)
    {
        Vector3 direction = MouseAssistant.DirectionToMouse(transform);
        rb2d.AddForce(direction * jumpForce * charge, ForceMode2D.Impulse);
        //Charge is a normalized float value (0 to 1)
    }

    public void StartCharging()
    {
        jumpTimer.RestartTimer();
    }

    public void ReleaseJump(bool grounded)
    {
        if (!grounded) return;
        float currentCharge = jumpTimer.StopTimer() / maxChargeTime; //Normalized
        Jump(currentCharge);
    }

}
