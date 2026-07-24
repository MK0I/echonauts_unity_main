using UnityEngine;

public class Ground_Check : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radius = 0.15f;

    public bool IsGrounded { get; private set; }
    public Collider2D GroundCollider { get; private set; }

    public void CheckGround(Transform checkPoint)
    {
        Collider2D hit = Physics2D.OverlapCircle(
            checkPoint.position,
            radius,
            groundLayer);

        GroundCollider = hit;
        IsGrounded = hit != null;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}