using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Aim_Control : MonoBehaviour, IInit, ITick
{
    public Vector2 AimDirection { get; private set; }

    public float AimAngle { get; private set; }

    public void Initialize(Context context)
    {

    }

    public void Tick(Context context)
    {
        Input_State input = context.InputState;

        AimDirection = (input.MouseWorld - (Vector2)transform.position).normalized;

        AimAngle = Mathf.Atan2( AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;
    }
}