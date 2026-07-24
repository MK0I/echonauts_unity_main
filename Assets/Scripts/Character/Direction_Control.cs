using UnityEngine;

public class Direction_Control : MonoBehaviour, IInit, ITick
{
    private Context context;

    [SerializeField] private Transform graphics;

    private bool facingRight = true;
    public bool FacingRight => facingRight;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Tick()
    {
        Input_State input = context.InputState;

        bool desiredFacing = facingRight;

        if (context.Aim_Control.IsAiming)
        {
            // Mouse Aiming Priority
            desiredFacing = input.MouseWorld.x >= transform.position.x;
        }
        else
        {
            // Movement Direction Priority
            if (Mathf.Abs(input.Move.x) > 0.01f)
            {
                desiredFacing = input.Move.x > 0f;
            }
        }

        if (desiredFacing == facingRight)
            return;

        facingRight = desiredFacing;

        Vector3 scale = graphics.localScale;
        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        graphics.localScale = scale;
    }
}