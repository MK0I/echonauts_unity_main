using UnityEngine;

public sealed class Animated_Pose_Cache : MonoBehaviour, IInit, ILateTick
{
    public int Order => 0;

    private Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        Skeleton_Map skeleton = context.Skeleton;

        // Core
        skeleton.HipRootAnimatedRotation = skeleton.HipRoot.localRotation;
        skeleton.Hip2AnimatedRotation = skeleton.Hip2.localRotation;

        // Spine
        skeleton.LowerSpineAnimatedRotation = skeleton.LowerSpine.localRotation;
        skeleton.UpperSpineAnimatedRotation = skeleton.UpperSpine.localRotation;
        skeleton.NeckAnimatedRotation = skeleton.Neck.localRotation;
        skeleton.HeadAnimatedRotation = skeleton.Head.localRotation;

        // Near Arm
        skeleton.NearUpperArmAnimatedRotation = skeleton.NearUpperArm.localRotation;
        skeleton.NearLowerArmAnimatedRotation = skeleton.NearLowerArm.localRotation;
        skeleton.NearHandAnimatedRotation = skeleton.NearHand.localRotation;

        // Far Arm
        skeleton.FarUpperArmAnimatedRotation = skeleton.FarUpperArm.localRotation;
        skeleton.FarLowerArmAnimatedRotation = skeleton.FarLowerArm.localRotation;
        skeleton.FarHandAnimatedRotation = skeleton.FarHand.localRotation;

        // Near Leg
        skeleton.NearThighAnimatedRotation = skeleton.NearThigh.localRotation;
        skeleton.NearLegAnimatedRotation = skeleton.NearLeg.localRotation;
        skeleton.NearFootAnimatedRotation = skeleton.NearFoot.localRotation;
        skeleton.NearToesAnimatedRotation = skeleton.NearToes.localRotation;

        // Far Leg
        skeleton.FarThighAnimatedRotation = skeleton.FarThigh.localRotation;
        skeleton.FarLegAnimatedRotation = skeleton.FarLeg.localRotation;
        skeleton.FarFootAnimatedRotation = skeleton.FarFoot.localRotation;
        skeleton.FarToesAnimatedRotation = skeleton.FarToes.localRotation;

    }

}