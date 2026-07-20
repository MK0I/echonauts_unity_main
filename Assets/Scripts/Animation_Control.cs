using UnityEngine;

public class Animation_Control : MonoBehaviour
{
    private Context context;
    private Animator animator;
    private Animation_State state;

    public void Initialize(Context context)
    {
        this.context = context;

        animator = context.Animator;
        state = context.Animation_State;
    }

    public void Tick(Context context)
    {
        UpdateState(context);
        UpdateAnimator();
    }

    public void LateTick()
    {
        Animation_State state = context.Animation_State;

        animator.SetFloat(AnimatorHashes.MoveSpeed, state.MoveSpeed);

        animator.SetFloat(AnimatorHashes.VerticalVelocity, state.VerticalVelocity);

        animator.SetBool(AnimatorHashes.Grounded, state.Grounded);

        if (state.Landed)
        {
            animator.SetTrigger(AnimatorHashes.Landed);

            state.Landed = false;
        }
    }

    private void UpdateState(Context context)
    {
        state.MoveSpeed = Mathf.Abs(context.Rigidbody.linearVelocity.x);

        state.VerticalVelocity = context.Rigidbody.linearVelocity.y;

        state.Grounded = context.Ground_Control.IsGrounded;

        state.Moving = state.MoveSpeed > 0.05f;

        state.Jumping =
            !state.Grounded &&
            state.VerticalVelocity > 0.05f;

        state.Falling =
            !state.Grounded &&
            state.VerticalVelocity < -0.05f;

        state.FacingRight = context.Direction_Control.FacingRight;

        state.AimAngle = context.Aim_Control.AimAngle;
    }

    private void UpdateAnimator()
    {
        animator.SetFloat(AnimatorHashes.MoveSpeed, state.MoveSpeed);

        animator.SetFloat(
            AnimatorHashes.VerticalVelocity,
            state.VerticalVelocity);

        animator.SetBool(
            AnimatorHashes.Grounded,
            state.Grounded);

        //animator.SetBool(AnimatorHashes.Moving, state.Moving);

        animator.SetFloat(
            AnimatorHashes.AimAngle,
            state.AimAngle);
    }
}
