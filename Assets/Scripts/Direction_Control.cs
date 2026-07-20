using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Direction_Control : MonoBehaviour, IInit, ITick
{
    Context context;

    [SerializeField]
    Transform graphics;

    bool facingRight = true;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Tick(Context context)
    {
        Input_State input = context.InputState;

        bool right = input.MouseWorld.x > transform.position.x;

        if (right == facingRight)
            return;

        facingRight = right;

        Vector3 scale = graphics.localScale;

        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

        graphics.localScale = scale;

    }

}