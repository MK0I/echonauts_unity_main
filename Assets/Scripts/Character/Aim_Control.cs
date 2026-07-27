using UnityEngine;

public sealed class Aim_Control : MonoBehaviour, IInit, ITick
{
    private Context context;

    public Vector2 AimDirection { get; private set; }
    public float AimAngle { get; private set; }
    public Vector2 AimWorldPosition { get; private set; }
    public bool IsAiming { get; private set; }

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Tick()
    {
        IsAiming = context.InputState.AimHeld;

        if (!IsAiming)
            return;

        AimWorldPosition = context.InputState.MouseWorld;

        Vector2 origin = context.Muzzle.position;

        AimDirection = (AimWorldPosition - origin).normalized;

        AimAngle = Mathf.Atan2(
            AimDirection.y,
            AimDirection.x) * Mathf.Rad2Deg;

        Debug.DrawLine(
    origin,
    AimWorldPosition,
    Color.red);

        Debug.DrawRay(
    origin,
    AimDirection * 2f,
    Color.green);

    }
}