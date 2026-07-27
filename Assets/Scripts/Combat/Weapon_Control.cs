using UnityEngine;

public sealed class Weapon_Control : MonoBehaviour, IInit, ILateTick
{
    public int Order => 500;

    private Context context;
    private double lastFireTime;

    [SerializeField] private float fireCooldown = 0.25f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 12f;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        if (context.InputState.Fire &&
            Time.timeAsDouble >= lastFireTime + fireCooldown)
        {
            Fire();
        }

    }

    //private void UpdatePivot()
    //{
    //    float angle = context.Aim_Control.AimAngle;

    //    if (context.Direction_Control.FacingRight)
    //    {
    //        context.WeaponPivot.localRotation =
    //            Quaternion.Euler(0f, 0f, angle);
    //    }
    //    else
    //    {
    //        context.WeaponPivot.localRotation =
    //            Quaternion.Euler(0f, 0f, 180f - angle);
    //    }

    //    Debug.Log($"Aim Angle: {angle:F1}");
    //}

    private void Fire()
    {
        lastFireTime = Time.timeAsDouble;

        GameObject projectile = Instantiate(
            projectilePrefab,
            context.Muzzle.position,
            Quaternion.identity);

        if (projectile.TryGetComponent(out Projectile bullet))
        {
            bullet.Initialize(
                context.Aim_Control.AimDirection,
                projectileSpeed);

        }

    }

}