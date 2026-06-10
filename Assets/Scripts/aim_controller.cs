using UnityEngine;

public class aim_controller : MonoBehaviour
{
    [SerializeField] private Transform mouseRef;
    [SerializeField] private Transform shoulder;
    [SerializeField] private Transform IK_targetRef;

    [SerializeField] private float maxReach = 1.5f;

    void LateUpdate()
    {
        Vector3 shoulderPos = shoulder.position;

        Vector3 toAim = mouseRef.position - shoulderPos;
        float maxDist = maxReach;

        Vector3 clamped = Vector3.ClampMagnitude(toAim, maxDist);

        IK_targetRef.position = shoulderPos + clamped;
    }
}
