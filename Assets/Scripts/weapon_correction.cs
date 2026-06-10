using UnityEngine;

public class weapon_correction : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private Transform mouseRef;

    void LateUpdate()
    {
        transform.position = hand.position;

        Vector2 dir = mouseRef.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (transform.root.localScale.x < 0)
        {
            angle += 180f;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
