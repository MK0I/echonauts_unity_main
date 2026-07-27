using UnityEngine;

public sealed class Idle_Pose : MonoBehaviour, IInit, IPoseModifier
{
    public int Order => 100;

    private Context context;

    [SerializeField] private float lowerSpineRotation;
    [SerializeField] private float upperSpineRotation;

    [SerializeField] private float nearUpperArmRotation;
    [SerializeField] private float nearLowerArmRotation;
    [SerializeField] private float nearHandRotation;

    [SerializeField] private float farUpperArmRotation;
    [SerializeField] private float farLowerArmRotation;
    [SerializeField] private float farHandRotation;

    [SerializeField] private float headRotation;
    [SerializeField] private float neckRotation;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Apply(Pose_State pose)
    {
        pose.LowerSpineRotation += lowerSpineRotation;
        pose.UpperSpineRotation += upperSpineRotation;

        pose.NeckRotation += neckRotation;
        pose.HeadRotation += headRotation;

        pose.NearUpperArmRotation += nearUpperArmRotation;
        pose.NearLowerArmRotation += nearLowerArmRotation;
        pose.NearHandRotation += nearHandRotation;

        pose.FarUpperArmRotation += farUpperArmRotation;
        pose.FarLowerArmRotation += farLowerArmRotation;
        pose.FarHandRotation += farHandRotation;

    }
}