using UnityEngine;

public class Camera_Anchor : MonoBehaviour, IInit, ITick
{
    private Context context;

    [Header("Look Ahead")]
    [SerializeField] private float movementLookAhead = 1.25f;
    [SerializeField] private float aimLookAhead = 2f;

    [Header("Zoom")]
    [SerializeField] private float defaultZoom = 6f;
    [SerializeField] private float aimZoom = 5f;

    public Vector3 TargetPosition { get; private set; }
    public float TargetZoom { get; private set; }

    // Unused Camera_State For Future Features
    //public Camera_State State { get; private set; }

    public void Initialize(Context context)
    {
        this.context = context;

        TargetPosition = context.CameraTarget.position;
        TargetZoom = defaultZoom;

        /*
        State = new Camera_State
        {
            Position = context.CameraTarget.position,
            Zoom = defaultZoom
        };
        */
    }

    public void Tick(Context context)
    {
        TargetPosition = CalculateTargetPosition();
        TargetZoom = CalculateZoom();

        /*
        State = new Camera_State
        {
            Position = CalculateTargetPosition(),
            Zoom = CalculateZoom()
        };
        */
    }

    private Vector3 CalculateTargetPosition()
    {
        return context.CameraTarget.position + CalculateMovementOffset() + CalculateAimOffset();
    }

    private Vector3 CalculateMovementOffset()
    {
        Vector2 move = context.InputState.Move;

        if (move.sqrMagnitude > 1f)
        {
            move.Normalize();
        }
            
        return (Vector3)move * movementLookAhead;
    }

    private Vector3 CalculateAimOffset()
    {
        Vector2 aim = context.Aim_Control.AimDirection;

        if (aim.sqrMagnitude > 1f)
        {
            aim.Normalize();
        }

        return (Vector3)aim * aimLookAhead;
    }

    private float CalculateZoom()
    {
        return context.InputState.Fired ? aimZoom : defaultZoom;
    }
}