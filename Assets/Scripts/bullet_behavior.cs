using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class bullet_behavior : MonoBehaviour
{
    public float speed = 30f;
    public float lifetime = 3f;
    private Rigidbody2D rb_bullet;

    void Start()
    {
        rb_bullet = GetComponent<Rigidbody2D>();
        rb_bullet.linearVelocity = transform.right * speed;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        if (hitinfo.CompareTag("Enemy"))
        {
            Debug.Log("Bullet has hit something");
        }

        Destroy(gameObject);
    }
}
