using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Aim_Control : MonoBehaviour, IInit, ITick
{
    private Context context;

    [Header("Presentation")]
    [SerializeField] private float headDistance = 0.4f;
    [SerializeField] private bool rotateHead = true;

    public Vector2 AimDirection { get; private set; }
    public float AimAngle { get; private set; }
    
    public void Initialize(Context context)
    {
        this.context = context;
    }

    public void Tick(Context context)
    {
        Input_State input = this.context.InputState;

        AimDirection = (input.MouseWorld - (Vector2)this.context.transform.position).normalized;

        AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg;

        UpdateWeaponPivot();

        UpdateHeadTarget();
    }

    private void UpdateWeaponPivot()
    {
        context.WeaponPivot.localRotation =
            Quaternion.Euler(0f, 0f, AimAngle);
    }

    private void UpdateHeadTarget()
    {
        if (!rotateHead)
            return;

        context.HeadTarget.localRotation =
            Quaternion.Euler(0f, 0f, AimAngle);
    }

}