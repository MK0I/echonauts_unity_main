using UnityEngine;

public sealed class Skeleton_Map : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private Transform hip;
    [SerializeField] private Transform spine;
    [SerializeField] private Transform neck;
    [SerializeField] private Transform head;

    [Header("Arms")]
    [SerializeField] private Transform upperArmNear;
    [SerializeField] private Transform lowerArmNear;
    [SerializeField] private Transform handNear;

    [SerializeField] private Transform upperArmFar;
    [SerializeField] private Transform lowerArmFar;
    [SerializeField] private Transform handFar;

    [Header("Rotations")]
    public Quaternion HipRestRotation { get; private set; }
    public Quaternion SpineRestRotation { get; private set; }
    public Quaternion NeckRestRotation { get; private set; }

    public Quaternion UpperArmNearRestRotation { get; private set; }
    public Quaternion LowerArmNearRestRotation { get; private set; }
    public Quaternion HandNearRestRotation { get; private set; }

    public Quaternion UpperArmFarRestRotation { get; private set; }
    public Quaternion LowerArmFarRestRotation { get; private set; }
    public Quaternion HandFarRestRotation { get; private set; }

    public Transform Hip => hip;
    public Transform Spine => spine;
    public Transform Neck => neck;
    public Transform Head => head;

    public Transform UpperArmNear => upperArmNear;
    public Transform LowerArmNear => lowerArmNear;
    public Transform HandNear => handNear;

    public Transform UpperArmFar => upperArmFar;
    public Transform LowerArmFar => lowerArmFar;
    public Transform HandFar => handFar;

    private void Awake()
    {
        HipRestRotation = hip.localRotation;
        SpineRestRotation = spine.localRotation;
        NeckRestRotation = neck.localRotation;

        UpperArmNearRestRotation = upperArmNear.localRotation;
        LowerArmNearRestRotation = lowerArmNear.localRotation;
        HandNearRestRotation = handNear.localRotation;

        UpperArmFarRestRotation = upperArmFar.localRotation;
        LowerArmFarRestRotation = lowerArmFar.localRotation;
        HandFarRestRotation = handFar.localRotation;
    }
}