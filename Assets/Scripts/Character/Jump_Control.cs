using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public sealed class Jump_Control : MonoBehaviour, IInit, ITick
{
    private Context context;
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce = 12f;

    public void Initialize(Context ctx)
    {
        context = ctx;
        rb = context.Rigidbody;
    }

    public void Tick()
    {
        if (!context.InputState.Jump)
            return;

        if (!context.Ground_Control.IsGrounded)
            return;

        rb.linearVelocity = new Vector2(
            rb.linearVelocity.x,
            jumpForce);
    }
}