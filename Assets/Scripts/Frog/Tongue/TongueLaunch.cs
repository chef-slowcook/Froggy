using UnityEngine;

// Component class for launching the tongue
[RequireComponent(typeof(Rigidbody2D))]
public class TongueLaunch : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb2d;
    [Header("Launch Parameters")]
    [SerializeField] private float launchStrength = 10f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void LaunchToMouse(Transform origin)
    {
        Vector3 direction = MouseAssistant.DirectionToMouse(origin);
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.position = origin.position + direction;
        rb2d.AddForce(direction * launchStrength, ForceMode2D.Impulse);
    }

    //Stick to any object that the tongue collides with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TerrainCollision();
    }

    public void TerrainCollision()
    {
        //Anchor the tongue to the object it collides with
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.linearVelocity = Vector2.zero;
    }
}
