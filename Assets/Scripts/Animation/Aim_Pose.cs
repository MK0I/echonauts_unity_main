using UnityEngine;

public sealed class Aim_Pose : MonoBehaviour, IInit, IPoseModifier
{
    public int Order => 200; // runs after Idle_Pose (100)

    [Header("Near Shoulder (primary aiming)")]
    [SerializeField] private float nearShoulderWeight = 1.0f;
    [SerializeField] private float nearShoulderLimitDeg = 55f;

    [Header("Support Shoulder (follows)")]
    [SerializeField] private float supportShoulderMultiplier = 1.2f;
    [SerializeField] private float supportShoulderLimitDeg = 70f;

    [Header("Secondary presentation")]
    [SerializeField] private float spineFollowDeg = 8f;
    [SerializeField] private float headFollowDeg = 6f;

    private Context context;
    private Aim_Control aim;

    public void Initialize(Context ctx)
    {
        context = ctx;
        aim = context.Aim_Control;
    }

    public void Apply(Pose_State pose)
    {
        float rawAngle = aim.AimAngle;

        float nearOffset = Mathf.Clamp(
            rawAngle * nearShoulderWeight,
            -nearShoulderLimitDeg,
            nearShoulderLimitDeg);

        float supportOffset = Mathf.Clamp(
            rawAngle * supportShoulderMultiplier,
            -supportShoulderLimitDeg,
            supportShoulderLimitDeg);

        float spineOffset = Mathf.Clamp(rawAngle * 0.15f, -spineFollowDeg, spineFollowDeg);
        float headOffset = Mathf.Clamp(rawAngle * 0.10f, -headFollowDeg, headFollowDeg);

        pose.NearUpperArmRotation += nearOffset;
        pose.FarUpperArmRotation += supportOffset;
        pose.UpperSpineRotation += spineOffset;
        pose.HeadRotation += headOffset;
    }
}
