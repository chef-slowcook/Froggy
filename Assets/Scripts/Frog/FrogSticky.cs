using UnityEngine;

[RequireComponent(typeof(Frog))]
public class FrogSticky : MonoBehaviour
{
    Frog frog;

    void Start()
    {
        frog = GetComponent<Frog>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            frog.GetRigidbody2D().linearVelocity = Vector2.zero;
            frog.GetRigidbody2D().angularVelocity = 0f;
        }
    }
}
