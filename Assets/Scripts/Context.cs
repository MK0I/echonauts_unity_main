using UnityEngine;

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
    public IK_Control IK_Control { get; private set; }


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

    [SerializeField] private Transform leftHandTarget;
    [SerializeField] private Transform rightHandTarget;

    [SerializeField] private Transform muzzle;
    [SerializeField] private Transform ejection;

    public Transform VisualRoot => visualRoot;
    public Transform Skeleton => skeleton;

    public Transform WeaponPivot => weaponPivot;
    public Transform WeaponSocket => weaponSocket;

    public Transform HeadTarget => headTarget;

    public Transform LeftHandTarget => leftHandTarget;
    public Transform RightHandTarget => rightHandTarget;

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

        Movement_Control = GetComponent<Movement_Control>();
        Direction_Control = GetComponent<Direction_Control>();
        Aim_Control = GetComponent<Aim_Control>();

        Camera_Anchor = GetComponent<Camera_Anchor>();

        Animation_State = GetComponent<Animation_State>();
        Animation_Control = GetComponent<Animation_Control>();
        IK_Control = GetComponent<IK_Control>();

        Animator = GetComponentInChildren<Animator>();

        Validate();
    }

    // Validation
    private void Validate()
    {
        Check(Rigidbody, nameof(Rigidbody));
        Check(CapsuleCollider, nameof(CapsuleCollider));

        Check(PlayerInput, nameof(PlayerInput));
        Check(Controller, nameof(Controller));

        Check(Movement_Control, nameof(Movement_Control));
        Check(Direction_Control, nameof(Direction_Control));
        Check(Aim_Control, nameof(Aim_Control));

        Check(Animation_State, nameof(Animation_State));
        Check(Animation_Control, nameof(Animation_Control));
        Check(IK_Control, nameof(IK_Control));

        Check(ground_Control, nameof(ground_Control));
        Check(ground_Check, nameof(ground_Check));

        Check(cameraTarget, nameof(cameraTarget));
        Check(groundCheckPoint, nameof(groundCheckPoint));

        Check(visualRoot, nameof(visualRoot));
        Check(skeleton, nameof(skeleton));

        Check(weaponPivot, nameof(weaponPivot));
        Check(weaponSocket, nameof(weaponSocket));

        Check(headTarget, nameof(headTarget));

        Check(leftHandTarget, nameof(leftHandTarget));
        Check(rightHandTarget, nameof(rightHandTarget));

        Check(muzzle, nameof(muzzle));
        Check(ejection, nameof(ejection));
    }

    // Checker
    private void Check(Object obj, string name)
    {
        if (obj == null)
            Debug.LogError($"Context Missing Reference: {name}", this);
    }
}