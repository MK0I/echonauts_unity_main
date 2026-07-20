using UnityEngine;

public class Camera_Anchor : MonoBehaviour, IInit, ILateTick
{
    Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        // camera code
    }
}