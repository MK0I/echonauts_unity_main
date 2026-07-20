using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Player_Control : MonoBehaviour, IInit, ITick
{
    Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Tick(Context context)
    {
        Input_State input = context.InputState;

        context.GetComponent<Movement_Control>().SetMoveInput(input.Move);

        Animation_State animation = context.Animation_State;

        animation.MoveSpeed = Mathf.Abs(context.Rigidbody.linearVelocity.x);

        animation.VerticalVelocity = context.Rigidbody.linearVelocity.y;

        animation.Grounded = context.Ground_Control.IsGrounded;

        if (context.Ground_Control.Landed)
        {
            animation.Landed = true;
        }
            
    }
}