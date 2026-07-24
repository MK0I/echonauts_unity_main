using UnityEngine;

public sealed class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifetime = 2f;

    private void Awake() => Destroy(gameObject, lifetime);

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.fixedDeltaTime;
    }
}
