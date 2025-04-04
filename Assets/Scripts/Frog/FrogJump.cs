using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Frog))]
public class FrogJump : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;
    [Header("Parameters")]
    [SerializeField]
    private float jumpForce = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void Jump(bool grounded)
    {
        if (!grounded) return;
        Vector3 direction = DirectionToMouse();
        rb2d.AddForce(direction * jumpForce, ForceMode2D.Impulse);
    }

    private Vector3 DirectionToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - transform.position).normalized;
        return direction;
    }


}
