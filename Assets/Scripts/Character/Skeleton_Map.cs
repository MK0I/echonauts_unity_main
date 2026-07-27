using UnityEngine;

public sealed class Skeleton_Map : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private Transform hipRoot;
    [SerializeField] private Transform hip2;

    [SerializeField] private Transform lowerSpine;
    [SerializeField] private Transform upperSpine;

    [SerializeField] private Transform neck;
    [SerializeField] private Transform head;

    [Header("Near Arm")]
    [SerializeField] private Transform nearUpperArm;
    [SerializeField] private Transform nearLowerArm;
    [SerializeField] private Transform nearHand;

    [Header("Far Arm")]
    [SerializeField] private Transform farUpperArm;
    [SerializeField] private Transform farLowerArm;
    [SerializeField] private Transform farHand;

    [Header("Near Leg")]
    [SerializeField] private Transform nearThigh;
    [SerializeField] private Transform nearLeg;
    [SerializeField] private Transform nearFoot;
    [SerializeField] private Transform nearToes;

    [Header("Far Leg")]
    [SerializeField] private Transform farThigh;
    [SerializeField] private Transform farLeg;
    [SerializeField] private Transform farFoot;
    [SerializeField] private Transform farToes;

    #region Animated Rotations

    public Quaternion HipRootAnimatedRotation { get; set; }
    public Quaternion Hip2AnimatedRotation { get; set; }

    public Quaternion LowerSpineAnimatedRotation { get; set; }
    public Quaternion UpperSpineAnimatedRotation { get; set; }

    public Quaternion NeckAnimatedRotation { get; set; }
    public Quaternion HeadAnimatedRotation { get; set; }

    public Quaternion NearUpperArmAnimatedRotation { get; set; }
    public Quaternion NearLowerArmAnimatedRotation { get; set; }
    public Quaternion NearHandAnimatedRotation { get; set; }

    public Quaternion FarUpperArmAnimatedRotation { get; set; }
    public Quaternion FarLowerArmAnimatedRotation { get; set; }
    public Quaternion FarHandAnimatedRotation { get; set; }

    public Quaternion NearThighAnimatedRotation { get; set; }
    public Quaternion NearLegAnimatedRotation { get; set; }
    public Quaternion NearFootAnimatedRotation { get; set; }
    public Quaternion NearToesAnimatedRotation { get; set; }

    public Quaternion FarThighAnimatedRotation { get; set; }
    public Quaternion FarLegAnimatedRotation { get; set; }
    public Quaternion FarFootAnimatedRotation { get; set; }
    public Quaternion FarToesAnimatedRotation { get; set; }

    #endregion

    #region Bone Accessors

    public Transform HipRoot => hipRoot;
    public Transform Hip2 => hip2;

    public Transform LowerSpine => lowerSpine;
    public Transform UpperSpine => upperSpine;

    public Transform Neck => neck;
    public Transform Head => head;

    public Transform NearUpperArm => nearUpperArm;
    public Transform NearLowerArm => nearLowerArm;
    public Transform NearHand => nearHand;

    public Transform FarUpperArm => farUpperArm;
    public Transform FarLowerArm => farLowerArm;
    public Transform FarHand => farHand;

    public Transform NearThigh => nearThigh;
    public Transform NearLeg => nearLeg;
    public Transform NearFoot => nearFoot;
    public Transform NearToes => nearToes;

    public Transform FarThigh => farThigh;
    public Transform FarLeg => farLeg;
    public Transform FarFoot => farFoot;
    public Transform FarToes => farToes;

    #endregion
}