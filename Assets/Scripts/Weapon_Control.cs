using UnityEngine;

public sealed class Weapon_Control : MonoBehaviour, IInit, ILateTick
{
    private Context _context;
    private double _lastFireTime;

    [SerializeField] private float fireCooldown = 0.25f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 12f;

    public void Initialize(Context context)
    {
        _context = context;
    }

    public void LateTick()
    {
        if (_context.Aim_Control.IsAiming)
        {
            UpdatePivot();
        }

        if (_context.InputState.Fire &&
            Time.timeAsDouble >= _lastFireTime + fireCooldown)
        {
            Fire();
        }
    }

    private void UpdatePivot()
    {
        float angle = _context.Aim_Control.AimAngle;

        if (_context.Direction_Control.FacingRight)
        {
            _context.WeaponPivot.localRotation =
                Quaternion.Euler(0f, 0f, angle);
        }
        else
        {
            _context.WeaponPivot.localRotation =
                Quaternion.Euler(0f, 0f, 180f - angle);
        }
    }

    private void Fire()
    {
        _lastFireTime = Time.timeAsDouble;

        float angle = _context.Aim_Control.AimAngle;

        Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

        GameObject bullet = Instantiate(
            projectilePrefab,
            _context.Muzzle.position,
            rotation);

        if (bullet.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity =
                _context.Aim_Control.AimDirection * projectileSpeed;
        }
    }
}