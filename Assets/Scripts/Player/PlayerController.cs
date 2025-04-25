using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] FrogController frogController;
    private InputSystem_Actions _input;

    void Awake()
    {
        _input = new InputSystem_Actions();
        _input.Player.Enable();
        AssignInputs();
    }

    //////////////////////////
    ///// ASSIGN INPUTS
    // 
    private void AssignInputs()
    {
        // Left Click
        _input.Player.Attack.performed += ctx => LeftClickPerformed();
        _input.Player.Attack.canceled += ctx => LeftClickReleased();
        // Right Click
        _input.Player.Jump.performed += ctx => RightClickPerformed();
        _input.Player.Jump.canceled += ctx => RightClickReleased();
    }

    //////////////////////////
    ///// INPUT HANDLERS 
    //Left Click
    private void LeftClickPerformed()
    {
        frogController.PrepareTongue();
    }

    private void LeftClickReleased()
    {
        frogController.LaunchTongue();
    }

    //Right Click
    private void RightClickPerformed()
    {
        frogController.PrepareJump();
    }

    private void RightClickReleased()
    {
        frogController.Jump();
    }

    //////////////////////////
    ///// ENABLE/DISABLE 
    //
    private void OnEnable()
    {
        _input.Player.Enable();
    }

    private void OnDisable()
    {
        _input.Player.Disable();
    }


}
