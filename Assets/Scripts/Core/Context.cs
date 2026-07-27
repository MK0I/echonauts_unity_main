using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Context : MonoBehaviour
{
    // Core Systems
    public Rigidbody2D Rigidbody { get; private set; }
    public CapsuleCollider2D CapsuleCollider { get; private set; }

    public State_Control State { get; private set; }
    public Player_Input PlayerInput { get; private set; }
    public Player_Control Controller { get; private set; }

    public Input_State InputState { get; } = new Input_State();


    // Gameplay Systems
    public Movement_Control Movement_Control { get; private set; }
    public Direction_Control Direction_Control { get; private set; }
    public Aim_Control Aim_Control { get; private set; }
    public Weapon_Control Weapon_Control { get; private set; }


    // Ground Check
    [SerializeField] private Ground_Control ground_Control;
    [SerializeField] private Ground_Check ground_Check;

    public Ground_Control Ground_Control => ground_Control;
    public Ground_Check Ground_Check => ground_Check;


    // Camera System
    public Camera_Anchor Camera_Anchor { get; private set; }

    [SerializeField] private Transform cameraTarget;
    public Transform CameraTarget => cameraTarget;


    // Animation
    public Animator Animator { get; private set; }

    public Animation_State Animation_State { get; private set; }
    public Animation_Control Animation_Control { get; private set; }
    public Animated_Pose_Cache Animated_Pose_Cache { get; private set; }
    public Pose_Control Pose_Control { get; private set; }
    public Pose_State Pose_State { get; private set; }
    public Skeleton_Map Skeleton { get; private set; }
    public FK_Control FK_Control { get; private set; }

    public Jump_Control Jump_Control { get; private set; }

    // Ground Reference
    [SerializeField] private Transform groundCheckPoint;
    public Transform GroundCheckPoint => groundCheckPoint;


    // Graphics
    [Header("Visual Root")]

    [SerializeField] private Transform visualRoot;
    [SerializeField] private Transform skeleton;

    [SerializeField] private Transform weaponPivot;
    [SerializeField] private Transform weaponSocket;

    [SerializeField] private Transform headTarget;

    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform ejection;


    // Public Accessors
    public Transform VisualRoot => visualRoot;
    public Transform player_root { get; private set; }

    public Aim_Pose Aim_Pose { get; private set; }

    public Transform WeaponPivot => weaponPivot;
    public Transform WeaponSocket => weaponSocket;
    public Weapon_Graphics Weapon_Graphics { get; private set; }

    public Transform HeadTarget => headTarget;

    public Transform Muzzle => muzzle;
    public Transform Ejection => ejection;


    // Initialization 
    public void Build()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        CapsuleCollider = GetComponent<CapsuleCollider2D>();

        State = GetComponent<State_Control>();
        PlayerInput = GetComponent<Player_Input>();
        Controller = GetComponent<Player_Control>();

        player_root = transform;

        Movement_Control = GetComponent<Movement_Control>();
        Direction_Control = GetComponent<Direction_Control>();
        Aim_Control = GetComponent<Aim_Control>();
        Weapon_Control = GetComponent<Weapon_Control>();

        Camera_Anchor = GetComponent<Camera_Anchor>();

        Skeleton = skeleton.GetComponent<Skeleton_Map>();
        
        Animator = GetComponentInChildren<Animator>();
        Animation_State = GetComponent<Animation_State>();
        Animation_Control = GetComponent<Animation_Control>();

        Animated_Pose_Cache = GetComponent<Animated_Pose_Cache>();

        Pose_Control = GetComponent<Pose_Control>();
        Pose_State = GetComponent<Pose_State>();

        //Aim_Pose = GetComponent<Aim_Pose>();

        FK_Control = GetComponent<FK_Control>();

        Jump_Control = GetComponent<Jump_Control>();

        Weapon_Graphics = GetComponent<Weapon_Graphics>();

        Validate();
    }

    // Validation
    private void Validate()
    {
        // Physics
        Check(Rigidbody, nameof(Rigidbody));
        Check(CapsuleCollider, nameof(CapsuleCollider));

        // Input
        Check(PlayerInput, nameof(PlayerInput));
        Check(Controller, nameof(Controller));

        // Controllers
        Check(Movement_Control, nameof(Movement_Control));
        Check(Direction_Control, nameof(Direction_Control));
        Check(Aim_Control, nameof(Aim_Control));
        Check(Weapon_Control, nameof(Weapon_Control));

        // Ground Check
        Check(ground_Control, nameof(ground_Control));
        Check(ground_Check, nameof(ground_Check));
        Check(groundCheckPoint, nameof(groundCheckPoint));

        // Visuals
        Check(visualRoot, nameof(visualRoot));

        // Animation
        Check(Animation_State, nameof(Animation_State));
        Check(Animation_Control, nameof(Animation_Control));
        Check(Animated_Pose_Cache, nameof(Animated_Pose_Cache));

        // Pose
        Check(Pose_Control, nameof(Pose_Control));
        Check(Pose_State, nameof(Pose_State));

        //Check(Aim_Pose, nameof(Aim_Pose));

        Check(Skeleton, nameof(Skeleton));

        Check(FK_Control, nameof(FK_Control));

        // Camera
        Check(cameraTarget, nameof(cameraTarget));
        
        // Weapon
        Check(weaponPivot, nameof(weaponPivot));
        Check(weaponSocket, nameof(weaponSocket));

        Check(headTarget, nameof(headTarget));

        Check(muzzle, nameof(muzzle));
        Check(ejection, nameof(ejection));

        Check(Jump_Control, nameof(Jump_Control));

        //Check(Weapon_Graphics, nameof(Weapon_Graphics));

    }

    // Checker
    private void Check(Object obj, string name)
    {
        if (obj == null)
            Debug.LogError($"Context is Missing Reference: {name}", this);

    }
}
