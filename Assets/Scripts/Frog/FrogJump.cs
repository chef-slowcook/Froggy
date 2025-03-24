using UnityEngine;

[RequireComponent(typeof(Frog))]
public class FrogJump : MonoBehaviour
{
    private Frog frog;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float groundCheckDistance = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;


    void Start()
    {
        frog = GetComponent<Frog>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Left mouse button
        {
            if (GroundCheck())
            {
                Jump(DirectionToMouse());
            }

        }
    }

    private Vector3 DirectionToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - transform.position).normalized;
        return direction;
    }

    private void Jump(Vector3 direction)
    {
        frog.GetRigidbody2D().AddForce(direction * jumpForce, ForceMode2D.Impulse);
    }

    private bool GroundCheck()
    {
        // Get the collider bounds
        Bounds bounds = GetComponent<Collider2D>().bounds;

        // Create three raycast positions: left edge, center, and right edge
        float raySpacing = bounds.size.x / 2;
        Vector2 leftRayOrigin = new Vector2(transform.position.x - raySpacing - 0.1f, transform.position.y);
        Vector2 centerRayOrigin = transform.position;
        Vector2 rightRayOrigin = new Vector2(transform.position.x + raySpacing + 0.1f, transform.position.y);

        // Cast rays from all three positions
        RaycastHit2D leftHit = Physics2D.Raycast(leftRayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D centerHit = Physics2D.Raycast(centerRayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightRayOrigin, Vector2.down, groundCheckDistance, groundLayer);

        // Debug rays to visualize the ground checks in Scene view
        Debug.DrawRay(leftRayOrigin, Vector2.down * groundCheckDistance, leftHit ? Color.green : Color.red, 5f);
        Debug.DrawRay(centerRayOrigin, Vector2.down * groundCheckDistance, centerHit ? Color.green : Color.red, 5f);
        Debug.DrawRay(rightRayOrigin, Vector2.down * groundCheckDistance, rightHit ? Color.green : Color.red, 5f);

        // Return true if any of the rays hit the ground
        return (leftHit.collider != null || centerHit.collider != null || rightHit.collider != null);
    }
}
