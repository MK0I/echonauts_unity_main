using UnityEngine;
using UnityEngine.InputSystem;

public class Context : MonoBehaviour
{
    [Header("Core")]
    public Rigidbody2D Rigidbody { get; private set; }
    public CapsuleCollider2D CapsuleCollider { get; private set; }

    public State_Control State { get; private set; }
    public Player_Input PlayerInput { get; private set; }
    public Player_Control Controller { get; private set; }

    public Input_State InputState => PlayerInput.State;

    [Header("Character")]
    public Movement_Control Movement { get; private set; }
    public Direction_Control Facing { get; private set; }
    public Aim_Control Aim { get; private set; }
    public Camera_Anchor CameraAnchor { get; private set; }

    [Header("Visual Hierarchy")]
    [SerializeField] private Transform visualRoot;
    [SerializeField] private Transform skeletonRoot;

    [Header("Weapon")]
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private Transform weaponSocket;

    [Header("IK Targets")]
    [SerializeField] private Transform leftHandTarget;
    [SerializeField] private Transform rightHandTarget;
    [SerializeField] private Transform headTarget;

    [Header("Camera")]
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Transform offsetTarget;

    [Header("Ground")]
    [SerializeField] private Transform groundCheck;

    public Transform VisualRoot => visualRoot;
    public Transform SkeletonRoot => skeletonRoot;

    public Transform WeaponPivot => weaponPivot;
    public Transform WeaponSocket => weaponSocket;

    public Transform LeftHandTarget => leftHandTarget;
    public Transform RightHandTarget => rightHandTarget;
    public Transform HeadTarget => headTarget;

    public Transform CameraTarget => cameraTarget;
    public Transform OffsetTarget => offsetTarget;

    public Transform GroundCheck => groundCheck;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();

        State = GetComponent<State_Control>();
        PlayerInput = GetComponent<Player_Input>();
        Controller = GetComponent<Player_Control>();

        Movement = GetComponent<Movement_Control>();
        Facing = GetComponent<Direction_Control>();
        Aim = GetComponent<Aim_Control>();
        CameraAnchor = GetComponent<Camera_Anchor>();
    }
}