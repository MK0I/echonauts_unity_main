using UnityEngine;

// TEMPORARY DIAGNOSTIC — delete once the spin bug is confirmed/fixed.
// Runs right after Animated_Pose_Cache (Order 0) and before Pose_Control
// (Order 100), so it logs the "animated" value exactly as FK_Control
// will read it this frame.
//
// What to look for:
//   - Stand still, don't aim. Watch NearUpperArm Z in the console.
//     It should be a fixed, unchanging number every frame (that's the
//     true idle pose). If it's slowly creeping even at rest, the bone
//     is unanimated and this confirms the theory immediately.
//   - Aim up hard, hold a second, release, stop aiming. NearUpperArm Z
//     should return to the SAME resting number as above. If it comes
//     back to a different (drifted) number instead of the original
//     baseline, that proves Animator never reclaimed the bone —
//     confirmed.
public sealed class Spin_Diagnostic : MonoBehaviour, IInit, ILateTick
{
    public int Order => 50;

    private Context context;
    private float lastLoggedFrame;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        var skeleton = context.Skeleton;

        float nearUpperArmZ = skeleton.NearUpperArmAnimatedRotation.eulerAngles.z;
        float upperSpineZ = skeleton.UpperSpineAnimatedRotation.eulerAngles.z;
        float headZ = skeleton.HeadAnimatedRotation.eulerAngles.z;

        Debug.Log(
            $"[Spin_Diagnostic] NearUpperArm(animated)={nearUpperArmZ:F2}  " +
            $"UpperSpine(animated)={upperSpineZ:F2}  Head(animated)={headZ:F2}");
    }
}