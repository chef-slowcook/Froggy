using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class FrogGrounding : MonoBehaviour
{
    [Header("Private References")]
    private Rigidbody2D rb2d;
    private Bounds bounds;

    [Header("Editor Parameters")]
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float groundCheckDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Raycast Cache")]
    private Vector2 leftRayOrigin;
    private Vector2 centerRayOrigin;
    private Vector2 rightRayOrigin;
    private float raySpacing;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bounds = GetComponent<Collider2D>().bounds;
        raySpacing = (bounds.size.x / 2) + 0.1f;
        if (rayOrigin == null) rayOrigin = transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            Stick();
        }
    }

    private void Stick()
    {
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f;
    }

    public bool IsGrounded()
    {
        // Update ray positions only once per check
        float xPos = rayOrigin.position.x;
        float yPos = rayOrigin.position.y;
        //Center ray origin
        centerRayOrigin.x = xPos;
        centerRayOrigin.y = yPos;
        //Left ray origin
        leftRayOrigin.x = xPos - raySpacing;
        leftRayOrigin.y = yPos;
        //Right ray origin
        rightRayOrigin.x = xPos + raySpacing;
        rightRayOrigin.y = yPos;

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
