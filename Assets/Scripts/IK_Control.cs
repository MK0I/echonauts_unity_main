using UnityEngine;

public class IK_Control : MonoBehaviour, IInit, ILateTick
{
    private Context context;

    [Header("Head")]
    [SerializeField] private float headDistance = 0.4f;
    [SerializeField] private float headVerticalOffset = 0.15f;

    [Header("Hands")]
    [SerializeField] private Vector2 rightHandOffset;
    [SerializeField] private Vector2 leftHandOffset;

    public void Initialize(Context context)
    {
        this.context = context;
    }

    public void LateTick()
    {
        // UpdateWeaponPivot();
        UpdateHeadTarget();
        // UpdateRightHand();
        // UpdateLeftHand();
    }

    /*
    private void UpdateWeaponPivot()
    {
        Vector2 aim = context.Aim_Control.AimDirection;

        float angle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg;

        context.WeaponPivot.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    */

    private void UpdateHeadTarget()
    {
        Vector2 target = (Vector2)context.Skeleton.position + context.Aim_Control.AimDirection * headDistance;

        target.y += headVerticalOffset;

        context.HeadTarget.position = target;

    }

    /*
    private void UpdateRightHand()
    {
        context.RightHandTarget.position = context.WeaponSocket.position + (Vector3)rightHandOffset;

    }
    */

    /*
    private void UpdateLeftHand()
    {
        context.LeftHandTarget.position = context.WeaponSocket.position + (Vector3)leftHandOffset;

    }
    */
}