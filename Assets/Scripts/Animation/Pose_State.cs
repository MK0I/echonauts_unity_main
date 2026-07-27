using UnityEngine;

public sealed class Pose_State : MonoBehaviour
{
    // Core
    public float HipRootRotation;
    public float Hip2Rotation;

    // Spine
    public float LowerSpineRotation;
    public float UpperSpineRotation;

    public float NeckRotation;
    public float HeadRotation;

    // Near Arm
    public float NearUpperArmRotation;
    public float NearLowerArmRotation;
    public float NearHandRotation;

    // Far Arm
    public float FarUpperArmRotation;
    public float FarLowerArmRotation;
    public float FarHandRotation;

    // Near Leg
    public float NearThighRotation;
    public float NearLegRotation;
    public float NearFootRotation;
    public float NearToesRotation;

    // Far Leg
    public float FarThighRotation;
    public float FarLegRotation;
    public float FarFootRotation;
    public float FarToesRotation;

    public void Clear()
    {
        HipRootRotation = 0f;
        Hip2Rotation = 0f;

        LowerSpineRotation = 0f;
        UpperSpineRotation = 0f;
        NeckRotation = 0f;
        HeadRotation = 0f;

        NearUpperArmRotation = 0f;
        NearLowerArmRotation = 0f;
        NearHandRotation = 0f;

        FarUpperArmRotation = 0f;
        FarLowerArmRotation = 0f;
        FarHandRotation = 0f;

        NearThighRotation = 0f;
        NearLegRotation = 0f;
        NearFootRotation = 0f;
        NearToesRotation = 0f;

        FarThighRotation = 0f;
        FarLegRotation = 0f;
        FarFootRotation = 0f;
        FarToesRotation = 0f;
    }
}