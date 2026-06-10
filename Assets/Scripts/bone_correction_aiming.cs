using UnityEngine;

public class bone_correction_aiming : MonoBehaviour
{
    [SerializeField] private Transform handBone;
    [SerializeField] private Transform mouseRef;

    void LateUpdate()
    {
        Vector2 dir = mouseRef.position - handBone.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (transform.root.localScale.x < 0)
        {
            angle += 180f;
        }

        handBone.rotation = Quaternion.Euler(0, 0, angle);
    }
}
