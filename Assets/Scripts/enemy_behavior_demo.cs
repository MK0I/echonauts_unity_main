using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class enemy_behavior_demo : MonoBehaviour
{
    [Header("Movement & Lifespan")]
    public float launchSpeed = 5f;
    public float lifetime = 4f;

    private Rigidbody2D rb_duck;

    void Start()
    {
        rb_duck = GetComponent<Rigidbody2D>();

        rb_duck.linearVelocity = Vector2.up * launchSpeed;

        Destroy(gameObject, lifetime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            Destroy(gameObject);
        }
    }
}
