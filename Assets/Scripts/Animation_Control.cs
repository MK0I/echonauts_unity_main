using UnityEngine;

public sealed class Animation_Control : MonoBehaviour, IInit, ITick, ILateTick
{
    private Context context;
    private Animator animator;
    private Animation_State state;

    public void Initialize(Context ctx)
    {
        context = ctx;

        animator = context.Animator;
        state = context.Animation_State;
    }

    public void Tick()
    {
        state.MoveSpeed = Mathf.Abs(context.InputState.Move.x) * 10f;

        state.VerticalVelocity = context.Rigidbody.linearVelocity.y;

        state.Grounded = context.Ground_Control.IsGrounded;

        state.Moving = state.MoveSpeed > 0.05f;

        if (context.Ground_Control.Landed)
        {
            state.Landed = true;
        }

        state.Jumping =
            !state.Grounded &&
            state.VerticalVelocity > 0.05f;

        state.Falling =
            !state.Grounded &&
            state.VerticalVelocity < -0.05f;

        state.FacingRight = context.Direction_Control.FacingRight;

        state.AimAngle = context.Aim_Control.AimAngle;
    }

    public void LateTick()
    {
        animator.SetFloat(
            AnimatorHashes.MoveSpeed,
            state.MoveSpeed);

        animator.SetFloat(
            AnimatorHashes.VerticalVelocity,
            state.VerticalVelocity);

        animator.SetBool(
            AnimatorHashes.Grounded,
            state.Grounded);

        animator.SetFloat(
            AnimatorHashes.AimAngle,
            state.AimAngle);

        if (state.Landed)
        {
            animator.SetTrigger(
                AnimatorHashes.Landed);

            state.Landed = false;
        }

    }

}