using UnityEngine;

public sealed class FK_Control : MonoBehaviour, IInit, ILateTick
{
    private Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        ApplyPose();

    }

    private void ApplyPose()
    {
        Skeleton_Map skeleton = context.Skeleton;
        Pose_State pose = context.Pose_State;

        skeleton.Spine.localRotation =
            skeleton.SpineRestRotation *
            Quaternion.Euler(0f, 0f, pose.SpineRotation);

        skeleton.Neck.localRotation =
            skeleton.NeckRestRotation *
            Quaternion.Euler(0f, 0f, pose.NeckRotation);

        skeleton.UpperArmNear.localRotation =
            skeleton.UpperArmNearRestRotation *
            Quaternion.Euler(0f, 0f, pose.UpperArmNearRotation);

        skeleton.LowerArmNear.localRotation =
            skeleton.LowerArmNearRestRotation *
            Quaternion.Euler(0f, 0f, pose.LowerArmNearRotation);

        skeleton.HandNear.localRotation =
            skeleton.HandNearRestRotation *
            Quaternion.Euler(0f, 0f, pose.HandNearRotation);

        skeleton.UpperArmFar.localRotation =
            skeleton.UpperArmFarRestRotation *
            Quaternion.Euler(0f, 0f, pose.UpperArmFarRotation);

        skeleton.LowerArmFar.localRotation =
            skeleton.LowerArmFarRestRotation *
            Quaternion.Euler(0f, 0f, pose.LowerArmFarRotation);

        skeleton.HandFar.localRotation =
            skeleton.HandFarRestRotation *
            Quaternion.Euler(0f, 0f, pose.HandFarRotation);
    }

}