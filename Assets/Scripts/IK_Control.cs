using UnityEngine;

public sealed class IK_Control : MonoBehaviour, IInit, ILateTick
{
    private Context context;

    [Header("Aim Offset")]
    [SerializeField] private float forwardOffset = 0.18f;
    [SerializeField] private float upwardOffset = 0.12f;

    [SerializeField] private float supportHandWeight = 0.8f;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        UpdateHands();
    }

    private void UpdateHands()
    {
        if (!context.Aim_Control.IsAiming)
        {
            context.RightHandTarget.SetPositionAndRotation(
                context.GripTarget.position,
                context.GripTarget.rotation);

            context.LeftHandTarget.SetPositionAndRotation(
                context.SupportTarget.position,
                context.SupportTarget.rotation);

            return;
        }

        Vector2 aim = context.Aim_Control.AimDirection.normalized;

        float weaponLength =
            Vector2.Distance(
                context.GripTarget.position,
                context.SupportTarget.position);

        Vector2 shoulderLift =
            aim * (weaponLength * 0.08f);

        context.RightHandTarget.SetPositionAndRotation(
            context.GripTarget.position + (Vector3)shoulderLift,
            context.GripTarget.rotation);

        context.LeftHandTarget.SetPositionAndRotation(
            context.SupportTarget.position + (Vector3)(shoulderLift * 0.75f),
            context.SupportTarget.rotation);
    }

}