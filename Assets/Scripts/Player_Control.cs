using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Player_Control : MonoBehaviour, IInit, ITick
{
    Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Tick()
    {
        Input_State input = context.InputState;

        context.Movement_Control.SetMoveInput(input.Move);

    }

}