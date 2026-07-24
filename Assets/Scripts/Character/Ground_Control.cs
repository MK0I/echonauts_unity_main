using UnityEngine;

public class Ground_Control : MonoBehaviour, IInit, ITick
{
    private Context context;

    public bool IsGrounded { get; private set; }

    public bool Landed { get; private set; }

    public bool Jumped { get; private set; }

    public void Initialize(Context context)
    {
        this.context = context;
    }

    public void Tick()
    {
        context.Ground_Check.CheckGround(context.GroundCheckPoint);

        bool previousGrounded = IsGrounded;

        IsGrounded = context.Ground_Check.IsGrounded;

        Landed = !previousGrounded && IsGrounded;

        Jumped = previousGrounded && !IsGrounded;
    }
}