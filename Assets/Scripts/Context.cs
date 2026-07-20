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

    // ===============================================

    [Header("Character")]
    public Movement_Control Movement_Control { get; private set; }
    public Direction_Control Direction_Control { get; private set; }
    public Aim_Control Aim_Control { get; private set; }
    public Camera_Anchor Camera_Anchor { get; private set; }

    // ===============================================

    [Header("Visual Hierarchy")]
    [SerializeField] private Transform visualRoot;
    [SerializeField] private Transform skeletonRoot;

    // ===============================================

    [Header("Weapon")]
    [SerializeField] private Transform weaponPivot;
    [SerializeField] private Transform weaponSocket;

    // ===============================================

    [Header("IK Targets")]
    [SerializeField] private Transform leftHandTarget;
    [SerializeField] private Transform rightHandTarget;
    [SerializeField] private Transform headTarget;

    // ===============================================

    [Header("Camera")]
    [SerializeField] private Camera_Anchor camera_Anchor;
    [SerializeField] private Transform cameraTarget;

    // ===============================================

    [Header("Ground")]

    [SerializeField] private Ground_Control ground_Control;
    [SerializeField] private Ground_Check ground_Check;
    [SerializeField] private Transform groundCheckPoint;
    public Ground_Control Ground_Control => ground_Control;
    public Ground_Check Ground_Check => ground_Check;

    // ===============================================

    [Header("Animation")]
    public Animator Animator { get; private set; }
    public Animation_State Animation_State { get; private set; }
    public Animation_Control Animation_Controller { get; private set; }

    // ===============================================
    // Public Accessors
    //
    // Core
    public Transform VisualRoot => visualRoot;
    public Transform SkeletonRoot => skeletonRoot;

    // Weapon
    public Transform WeaponPivot => weaponPivot;
    public Transform WeaponSocket => weaponSocket;

    // IK
    public Transform LeftHandTarget => leftHandTarget;
    public Transform RightHandTarget => rightHandTarget;
    public Transform HeadTarget => headTarget;

    // Camera
    public Camera_Anchor CameraAnchor => camera_Anchor;
    public Transform CameraTarget => cameraTarget;

    // Ground
    public Transform GroundCheckPoint => groundCheckPoint;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();

        State = GetComponent<State_Control>();
        PlayerInput = GetComponent<Player_Input>();
        Controller = GetComponent<Player_Control>();

        Movement_Control = GetComponent<Movement_Control>();
        Direction_Control = GetComponent<Direction_Control>();
        Aim_Control = GetComponent<Aim_Control>();
        Camera_Anchor = GetComponent<Camera_Anchor>();
    }
}