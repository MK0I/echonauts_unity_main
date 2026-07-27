using UnityEngine;

public sealed class FK_Control : MonoBehaviour, IInit, ILateTick
{
    private Context context;

    public int Order => 200;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        Skeleton_Map skeleton = context.Skeleton;
        Pose_State pose = context.Pose_State;

        // Core
        ApplyRotation(skeleton.HipRoot, skeleton.HipRootAnimatedRotation, pose.HipRootRotation);
        ApplyRotation(skeleton.Hip2, skeleton.Hip2AnimatedRotation, pose.Hip2Rotation);

        // Spine
        ApplyRotation(skeleton.LowerSpine, skeleton.LowerSpineAnimatedRotation, pose.LowerSpineRotation);
        ApplyRotation(skeleton.UpperSpine, skeleton.UpperSpineAnimatedRotation, pose.UpperSpineRotation);

        ApplyRotation(skeleton.Neck, skeleton.NeckAnimatedRotation, pose.NeckRotation);
        ApplyRotation(skeleton.Head, skeleton.HeadAnimatedRotation, pose.HeadRotation);

        // Near Arm
        ApplyRotation(skeleton.NearUpperArm, skeleton.NearUpperArmAnimatedRotation, pose.NearUpperArmRotation);
        ApplyRotation(skeleton.NearLowerArm, skeleton.NearLowerArmAnimatedRotation, pose.NearLowerArmRotation);
        ApplyRotation(skeleton.NearHand, skeleton.NearHandAnimatedRotation, pose.NearHandRotation);

        // Far Arm
        ApplyRotation(skeleton.FarUpperArm, skeleton.FarUpperArmAnimatedRotation, pose.FarUpperArmRotation);
        ApplyRotation(skeleton.FarLowerArm, skeleton.FarLowerArmAnimatedRotation, pose.FarLowerArmRotation);
        ApplyRotation(skeleton.FarHand, skeleton.FarHandAnimatedRotation, pose.FarHandRotation);

        // Near Leg
        ApplyRotation(skeleton.NearThigh, skeleton.NearThighAnimatedRotation, pose.NearThighRotation);
        ApplyRotation(skeleton.NearLeg, skeleton.NearLegAnimatedRotation, pose.NearLegRotation);
        ApplyRotation(skeleton.NearFoot, skeleton.NearFootAnimatedRotation, pose.NearFootRotation);
        ApplyRotation(skeleton.NearToes, skeleton.NearToesAnimatedRotation, pose.NearToesRotation);

        // Far Leg
        ApplyRotation(skeleton.FarThigh, skeleton.FarThighAnimatedRotation, pose.FarThighRotation);
        ApplyRotation(skeleton.FarLeg, skeleton.FarLegAnimatedRotation, pose.FarLegRotation);
        ApplyRotation(skeleton.FarFoot, skeleton.FarFootAnimatedRotation, pose.FarFootRotation);
        ApplyRotation(skeleton.FarToes, skeleton.FarToesAnimatedRotation, pose.FarToesRotation);
    }

    private static void ApplyRotation(
        Transform bone,
        Quaternion animatedRotation,
        float offset)
    {
        bone.localRotation =
            animatedRotation *
            Quaternion.Euler(0f, 0f, offset);
    }
}