using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb2d;
    }
}
