using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FrogJump), typeof(FrogGrounding))]
public class FrogController : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private TongueController tongue;
    private FrogJump frogJump;
    private FrogGrounding frogGrounding;

    void Awake()
    {
        frogJump = GetComponent<FrogJump>();
        frogGrounding = GetComponent<FrogGrounding>();
    }
    ///////////////////
    ///// INPUT HANDLERS
    // Jump HANDLERS
    public void PrepareJump()
    {
        frogJump.StartCharging();
    }

    public void Jump()
    {
        frogJump.ReleaseJump(frogGrounding.IsGrounded());
    }

    // Tongue HANDLERS
    public void PrepareTongue()
    {
        tongue.PrepareTongue();
    }

    public void LaunchTongue()
    {
        tongue.LaunchTongue();
    }
}
