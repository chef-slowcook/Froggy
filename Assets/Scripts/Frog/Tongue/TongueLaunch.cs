using UnityEngine;

// Component class for launching the tongue
[RequireComponent(typeof(Rigidbody2D))]
public class TongueLaunch : MonoBehaviour
{
    [Header("Component References")]
    private Rigidbody2D rb2d;
    [Header("Launch Parameters")]
    [SerializeField] private float launchStrength = 10f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void LaunchToMouse(Transform fromPoint)
    {
        Vector2 direction = MouseAssistant.DirectionToMouse(fromPoint);
        //Reset the postiion of the tongue to the pivot point + the direction
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.position = fromPoint.position + (Vector3)direction * 0.5f;
        rb2d.AddForce(direction * launchStrength, ForceMode2D.Impulse);
    }

    //Stick to any object that the tongue collides with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.bodyType = RigidbodyType2D.Kinematic;
        rb2d.linearVelocity = Vector2.zero;
    }
}
