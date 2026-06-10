using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class weapon_handler : MonoBehaviour
{
    [Header("Handler")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzleCoord;

    [Header("Weapon Settings")]
    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private float fireRate = 0.2f;

    private float nextFireTime;
    
    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || muzzleCoord == null) return;

        GameObject bullet = Instantiate(bulletPrefab, muzzleCoord.position, muzzleCoord.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = muzzleCoord.right * bulletSpeed;
        }

        Destroy(bullet, 3f);
    }
}
