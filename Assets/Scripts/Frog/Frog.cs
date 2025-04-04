using UnityEngine;
using UnityEngine.InputSystem;
public class Frog : MonoBehaviour
{
    private FrogJump frogJump;
    private FrogGrounding frogGrounding;
    private Rigidbody2D rb2d;
    private InputSystem_Actions _input;
    void Awake()
    {
        frogJump = GetComponent<FrogJump>();
        frogGrounding = GetComponent<FrogGrounding>();
        rb2d = GetComponent<Rigidbody2D>();
        InputConfiguration();
    }

    public Rigidbody2D GetRigidbody2D()
    {
        return rb2d;
    }

    private void InputConfiguration()
    {
        _input = new InputSystem_Actions();
        _input.Player.Enable();
        _input.Player.Jump.performed += ctx => frogJump.Jump(frogGrounding.IsGrounded());
    }



}
