using UnityEngine;
using UnityEngine.InputSystem;

public class FrogJump : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;
    [Header("Parameters")]
    [SerializeField] private float jumpForce = 10f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Jump(bool grounded)
    {
        if (!grounded) return;
        Vector3 direction = MouseAssistant.DirectionToMouse(transform);
        rb2d.AddForce(direction * jumpForce, ForceMode2D.Impulse);
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb2d;
    }

}
