using UnityEngine;

[RequireComponent(typeof(Frog), typeof(Collider2D))]
public class FrogGrounding : MonoBehaviour
{
    private Rigidbody2D rb2d;
    Bounds bounds;
    [SerializeField]
    private float groundCheckDistance = 0.2f;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform rayOrigin;

    void Start()
    {
        rb2d = GetComponent<Frog>().GetRigidbody2D();
        bounds = GetComponent<Collider2D>().bounds;
        if (rayOrigin == null) rayOrigin = transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Stick();
        }
    }

    private void Stick()
    {
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
    }

    //TODO: optimize by caching Vector positions
    public bool IsGrounded()
    {
        // Create three raycast positions: left edge, center, and right edge
        float raySpacing = (bounds.size.x / 2) + 0.1f;
        Vector2 leftRayOrigin = new Vector2(rayOrigin.position.x - raySpacing, rayOrigin.position.y);
        Vector2 centerRayOrigin = rayOrigin.position;
        Vector2 rightRayOrigin = new Vector2(rayOrigin.position.x + raySpacing, rayOrigin.position.y);

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
