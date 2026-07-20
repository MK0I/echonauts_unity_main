using UnityEngine;

public class State_Control : MonoBehaviour
{
    public bool IsGrounded { get; internal set; }
    public bool IsMoving { get; internal set; }
    public bool IsFacingRight { get; internal set; }
    public bool IsAiming { get; internal set; }
    public Vector2 AimDirection { get; internal set; }
}

