using UnityEngine;
using UnityEngine.InputSystem;

public class camera_control_hybrid : MonoBehaviour
{
    // Inspector Settings and Fine Tuning
    [Header("Targets")]
    public Transform cameraTarget;
    public Transform followTarget;
    public Transform aimTarget;

    [Header("Input Actions")]
    public InputActionReference player_move;
    public InputActionReference player_aim;

    [Header("Settings")]
    public float cameraOffset = 6f;
    public float cameraSmoothing = 10f;
    public float cameraBlending = 0.5f;

    // Declarations
    private Vector2 moveInput;
    private bool isAiming;

    private Camera cam;

    void Awake() // Camera Reference
    {
        cam = Camera.main;
    }

    void OnEnable() // Toggle Logic on Enable
    {
        player_move.action.performed += OnMove;
        player_move.action.canceled += OnMove;

        player_aim.action.started += OnAimStarted;
        player_aim.action.canceled += OnAimCanceled;
    }

    void OnDisable() // Toggle Logic on Disable
    {
        player_move.action.performed -= OnMove;
        player_move.action.canceled -= OnMove;

        player_aim.action.started -= OnAimStarted;
        player_aim.action.canceled -= OnAimCanceled;
    }

    void OnMove(InputAction.CallbackContext ctx) // On Move
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    void OnAimStarted(InputAction.CallbackContext ctx) // On Aim
    {
        isAiming = true;
    }

    void OnAimCanceled(InputAction.CallbackContext ctx) // Off Aim
    {
        isAiming = false;
    }

    void Update() // Loop
    {
        UpdateAimTarget();
        UpdateFollowTarget();
    }

    void UpdateAimTarget() // Mouse Position Calculation
    {
        Vector3 mouse = Mouse.current.position.ReadValue();

        Vector3 world = cam.ScreenToWorldPoint(mouse);
        world.z = 0f;

        aimTarget.position = world;
    }

    void UpdateFollowTarget() // Camera Offset Calculation Relative to Movement Input
    {
        Vector3 basePos = cameraTarget.position;

        Vector3 moveOffset = new Vector3(moveInput.x, moveInput.y, 0f) * cameraOffset;

        Vector3 targetPos;

        if (isAiming) // Aiming Check
        {
            // Mouse Position Prio
            targetPos = Vector3.Lerp(
                basePos + moveOffset,
                aimTarget.position,
                cameraBlending
            );
        }
        else
        {
            targetPos = basePos + moveOffset;
        }

        followTarget.position = Vector3.Lerp(
            followTarget.position,
            targetPos,
            Time.deltaTime * cameraSmoothing
        );
    }
}