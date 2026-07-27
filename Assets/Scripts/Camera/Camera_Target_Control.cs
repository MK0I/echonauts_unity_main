using UnityEngine;

public class Camera_Target_Control : MonoBehaviour, IInit, ILateTick
{
    public int Order => 500;

    [Header("Camera")]
    [SerializeField] private float aimOffset = 2.5f;
    [SerializeField] private float followSpeed = 10f;
    [SerializeField] private float returnSpeed = 6f;

    private Context context;
    private Aim_Control aim;

    public void Initialize(Context context)
    {
        this.context = context;

        aim = context.Aim_Control;
    }

    public void LateTick()
    {
        Vector3 desiredPosition = context.player_root.position;

        if (aim.IsAiming)
        {
            desiredPosition += (Vector3)(aim.AimDirection * aimOffset);
        }

        desiredPosition.z = context.CameraTarget.position.z;

        float speed = aim.IsAiming
            ? followSpeed
            : returnSpeed;

        context.CameraTarget.position = Vector3.Lerp(
            context.CameraTarget.position,
            desiredPosition,
            speed * Time.deltaTime);
    }
}
