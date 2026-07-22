using UnityEngine;

public sealed class Pose_Control : MonoBehaviour, IInit, ITick
{
    private Context context;

    [Header("Settings")]
    [SerializeField] private float maxArmRotation = 25f;
    [SerializeField] private float smoothSpeed = 18f;

    private Quaternion upperArmNearDefaultRotation;
    private Quaternion upperArmFarDefaultRotation;

    public void Initialize(Context ctx)
    {
        context = ctx;

        upperArmNearDefaultRotation = context.UpperArmNear.localRotation;
        upperArmFarDefaultRotation = context.UpperArmFar.localRotation;
    }

    public void Tick()
    {
        if (!context.Aim_Control.IsAiming)
        {
            context.UpperArmNear.localRotation =
                Quaternion.Slerp(
                    context.UpperArmNear.localRotation,
                    upperArmNearDefaultRotation,
                    Time.deltaTime * smoothSpeed);

            context.UpperArmFar.localRotation =
                Quaternion.Slerp(
                    context.UpperArmFar.localRotation,
                    upperArmFarDefaultRotation,
                    Time.deltaTime * smoothSpeed);

            return;
        }

        float angle = context.Aim_Control.AimAngle;

        if (!context.Direction_Control.FacingRight)
        {
            angle = 180f - angle;
        }

        angle = Mathf.Clamp(angle, -90f, 90f);

        float armRotation = (angle / 90f) * maxArmRotation;

        Quaternion nearTarget =
            upperArmNearDefaultRotation *
            Quaternion.Euler(0f, 0f, armRotation);

        Quaternion farTarget =
            upperArmFarDefaultRotation *
            Quaternion.Euler(0f, 0f, armRotation);

        context.UpperArmNear.localRotation =
            Quaternion.Slerp(
                context.UpperArmNear.localRotation,
                nearTarget,
                Time.deltaTime * smoothSpeed);

        context.UpperArmFar.localRotation =
            Quaternion.Slerp(
                context.UpperArmFar.localRotation,
                farTarget,
                Time.deltaTime * smoothSpeed);
    }
}