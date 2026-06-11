using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class weapon_handler : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzleCoord;
    [SerializeField] private Transform mouseRef;

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

    void Update() // Debug Purposes
    {
        if (muzzleCoord == null) return;

        Debug.DrawLine(muzzleCoord.position, muzzleCoord.position + muzzleCoord.right * 2f, Color.green);
    }


    void Shoot()
    {
        if (bulletPrefab == null || muzzleCoord == null) return;

        GameObject bullet = Instantiate(bulletPrefab, muzzleCoord.position, muzzleCoord.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 dir = (mouseRef.position - muzzleCoord.position).normalized;
            rb.linearVelocity = dir * bulletSpeed;



            /*Vector2 dir = muzzleCoord.right;

            if (transform.root.localScale.x < 0)
            {
                dir = -dir;
            }*/

            /*rb.linearVelocity = dir * bulletSpeed;*/
        }

        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();

        if (playerCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, playerCollider);
        }

        Destroy(bullet, 3f);
    }

    private void OnDrawGizmos() // Debug Purposes
    {
        if (muzzleCoord == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(muzzleCoord.position, muzzleCoord.position + muzzleCoord.right * 2f);
    }

}
