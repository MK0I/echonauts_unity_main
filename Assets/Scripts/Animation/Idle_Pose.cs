using UnityEngine;

public sealed class Idle_Pose : MonoBehaviour, IInit, IPoseModifier
{
    public int Order => 100;

    private Context context;

    [Header("Body")]

    [SerializeField] private float spineRotation = 0f;
    [SerializeField] private float neckRotation = 0f;

    [Header("Near Arm")]

    [SerializeField] private float upperArmNearRotation = 0f;
    [SerializeField] private float lowerArmNearRotation = 0f;
    [SerializeField] private float handNearRotation = 0f;

    [Header("Far Arm")]

    [SerializeField] private float upperArmFarRotation = 0f;
    [SerializeField] private float lowerArmFarRotation = 0f;
    [SerializeField] private float handFarRotation = 0f;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void Apply(Pose_State pose)
    {
        pose.SpineRotation += spineRotation;
        pose.NeckRotation += neckRotation;

        pose.UpperArmNearRotation += upperArmNearRotation;
        pose.LowerArmNearRotation += lowerArmNearRotation;
        pose.HandNearRotation += handNearRotation;

        pose.UpperArmFarRotation += upperArmFarRotation;
        pose.LowerArmFarRotation += lowerArmFarRotation;
        pose.HandFarRotation += handFarRotation;
    }
}