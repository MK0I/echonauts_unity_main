using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Camera_Control : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Context context;

    [Header("Position")]
    [SerializeField] private float positionSmoothTime = 0.12f;

    [Header("Zoom")]
    [SerializeField] private float zoomSmoothTime = 0.15f;

    private Camera cameraComponent;

    private Vector3 positionVelocity;
    private float zoomVelocity;

    private void Awake()
    {
        cameraComponent = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (context == null)
            return;

        UpdatePosition();
        UpdateZoom();
    }

    private void UpdatePosition()
    {
        Vector3 desired = context.Camera_Anchor.TargetPosition;
        desired.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, desired, ref positionVelocity, positionSmoothTime);
    }

    private void UpdateZoom()
    {
        cameraComponent.orthographicSize = Mathf.SmoothDamp(cameraComponent.orthographicSize, context.Camera_Anchor.TargetZoom, ref zoomVelocity,zoomSmoothTime);
    }
}