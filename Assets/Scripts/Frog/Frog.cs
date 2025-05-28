using UnityEngine;

[RequireComponent(typeof(FrogAnimation), typeof(FrogGrounding), typeof(FrogJump))]
public class Frog : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private Tongue tongue;
    private FrogAnimation frogAnimation;
    private FrogGrounding frogGrounding;
    private FrogJump frogJump;

    void Start()
    {
        frogAnimation = GetComponent<FrogAnimation>();
        frogGrounding = GetComponent<FrogGrounding>();
        frogJump = GetComponent<FrogJump>();
    }

    // TONGUE
    public void TryProjectTongue()
    {
        frogAnimation.ChangeAnimation(FrogAnimation.FROG_CROUCH);
        tongue.ProjectTongue();
    }

    public void TryRetractTongue()
    {
        frogAnimation.ChangeAnimation(FrogAnimation.FROG_IDLE);
        tongue.RetractTongue();
    }

    // JUMP
    public void TryChargeJump()
    {
        frogAnimation.ChangeAnimation(FrogAnimation.FROG_CROUCH_IDLE);
        frogJump.StartCharging();
    }

    public void TryJump()
    {
        frogAnimation.ChangeAnimation(FrogAnimation.FROG_IDLE);
        frogJump.ReleaseJump(frogGrounding.IsGrounded());
    }
}
