using Unity.Cinemachine;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField]
    private Camera_Target target;

    [SerializeField]
    private float smoothTime = .12f;

    private Vector3 velocity;

    private void LateUpdate()
    {
        Vector3 desired = target.Position;

        desired.z = transform.position.z;

        transform.position = Vector3.SmoothDamp( transform.position, desired, ref velocity, smoothTime);
    }
}