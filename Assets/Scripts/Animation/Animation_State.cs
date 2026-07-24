using UnityEngine;

public class Animation_State : MonoBehaviour
{
    [Header("Movement")]
    public float MoveSpeed { get; set; }
    public float VerticalVelocity { get; set; }

    [Header("Ground")]
    public bool Grounded { get; set; }

    [Header("State")]
    public bool Moving;
    public bool Jumping;
    public bool Falling;
    public bool Landed { get; set; }

    [Header("Direction")]
    public bool FacingRight;

    [Header("Aim")]
    public float AimAngle;


}