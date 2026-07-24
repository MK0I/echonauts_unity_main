using UnityEngine;

public sealed class Aim_Pose : MonoBehaviour, IInit, IPoseModifier
{
    public int Order => 200;

    private Context context;

    [Header("Body Rotation")]
    [SerializeField] private float spineWeight = 0.18f;
    [SerializeField] private float neckWeight = 0.35f;

    [Header("Rotation Limits")]
    [SerializeField] private float spineLimit = 18f;
    [SerializeField] private float neckLimit = 30f;

    [Header("Upper Arm Rotation")]
    [SerializeField] private float upperArmNearWeight = 0.70f;
    [SerializeField] private float upperArmFarWeight = 0.45f;

    [Header("Upper Arm Limits")]
    [SerializeField] private float upperArmNearLimit = 55f;
    [SerializeField] private float upperArmFarLimit = 35f;

    [Header("Lower Arm Weights")]
    [SerializeField] private float lowerArmNearWeight = 0.25f;
    [SerializeField] private float lowerArmFarWeight = 0.18f;

    [Header("Lower Arm Limits")]
    [SerializeField] private float lowerArmNearLimit = 20f;
    [SerializeField] private float lowerArmFarLimit = 15f;

    [Header("Shoulder Bias")]
    [SerializeField] private float nearArmUpBias = 1.00f;
    [SerializeField] private float nearArmDownBias = 0.60f;

    [SerializeField] private float farArmUpBias = 0.65f;
    [SerializeField] private float farArmDownBias = 1.00f;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Apply(Pose_State pose)
    {
        if (!context.Aim_Control.IsAiming)
            return;

        float angle = GetAimAngle();

        ApplyTorso(pose, angle);
        ApplyArms(pose, angle);

    }

    private float GetAimAngle()
    {
        float angle = context.Aim_Control.AimAngle;

        if (!context.Direction_Control.FacingRight)
        {
            angle = 180f - angle;
        }
            
        return Mathf.DeltaAngle(0f, angle);
    }

    private void ApplyTorso(Pose_State pose, float angle)
    {
        pose.SpineRotation += Mathf.Clamp(angle * spineWeight, -spineLimit, spineLimit);

        pose.NeckRotation += Mathf.Clamp(angle * neckWeight, -neckLimit, neckLimit);

    }

    private void ApplyArms(Pose_State pose, float angle)
    {
        float normalized = Mathf.InverseLerp(-90f, 90f, angle);

        float nearBias = Mathf.Lerp(nearArmDownBias, nearArmUpBias, normalized);

        float farBias = Mathf.Lerp(farArmDownBias, farArmUpBias, normalized);

        pose.UpperArmNearRotation +=
            Mathf.Clamp(angle * upperArmNearWeight * nearBias, -upperArmNearLimit, upperArmNearLimit);

        pose.UpperArmFarRotation +=
            Mathf.Clamp(angle * upperArmFarWeight * farBias, -upperArmFarLimit, upperArmFarLimit);

        pose.LowerArmNearRotation +=
            Mathf.Clamp(angle * lowerArmNearWeight, -lowerArmNearLimit, lowerArmNearLimit);

        pose.LowerArmFarRotation +=
            Mathf.Clamp( angle * lowerArmFarWeight, -lowerArmFarLimit, lowerArmFarLimit);

        pose.HandNearRotation += -pose.LowerArmNearRotation;

        pose.HandFarRotation += -pose.LowerArmFarRotation;

    }

}