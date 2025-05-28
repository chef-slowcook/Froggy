using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] Frog frog;
    private InputSystem_Actions _input;

    void Awake()
    {
        _input = new InputSystem_Actions();
        _input.Player.Enable();
        AssignInputs();
    }

    private void AssignInputs()
    {
        // Left Click
        _input.Player.Attack.performed += ctx => TonguePerformed();
        _input.Player.Attack.canceled += ctx => TongueReleased();
        // Right Click
        _input.Player.Jump.performed += ctx => JumpPerformed();
        _input.Player.Jump.canceled += ctx => JumpReleased();
    }

    //Left click on Mouse, West-Button on Controller
    private void TonguePerformed()
    {
        frog.TryProjectTongue();
    }

    private void TongueReleased()
    {
        frog.TryRetractTongue();
    }

    //Right Click on Mouse, South-Button on Controller
    private void JumpPerformed()
    {
        frog.TryChargeJump();
    }

    private void JumpReleased()
    {
        frog.TryJump();
    }

    ///// ENABLE/DISABLE inputs
    private void OnEnable()
    {
        _input.Player.Enable();
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }
}
