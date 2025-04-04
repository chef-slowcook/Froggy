using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FrogJump), typeof(FrogGrounding))]
public class Frog : MonoBehaviour
{
    private FrogJump frogJump;
    private FrogGrounding frogGrounding;
    private InputSystem_Actions _input;

    void Awake()
    {
        // Assign declared variables
        frogJump = GetComponent<FrogJump>();
        frogGrounding = GetComponent<FrogGrounding>();
        InputConfiguration();
    }

    private void InputConfiguration()
    {
        _input = new InputSystem_Actions();
        _input.Player.Enable();
        _input.Player.Jump.performed += ctx => frogJump.Jump(frogGrounding.IsGrounded());
    }



}
