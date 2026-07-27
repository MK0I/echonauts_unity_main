using UnityEngine;

public sealed class Weapon_Graphics : MonoBehaviour, IInit, ILateTick
{
    public int Order => 400;

    private Context context;

    public void Initialize(Context ctx)
    {
        context = ctx;
    }

    public void LateTick()
    {
        
    }
}
