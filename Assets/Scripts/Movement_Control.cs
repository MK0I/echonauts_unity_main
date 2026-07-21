using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement_Control : MonoBehaviour, IInit, IFixedTick
{
    Context context;

    Rigidbody2D rb;

    Vector2 movement;

    [SerializeField]
    float moveSpeed = 10f;

    public void Initialize(Context ctx)
    {
        context = ctx;

        rb = context.Rigidbody;

        // Debug.Log($"Movement initialized. rb = {rb}");
    }

    public void SetMoveInput(Vector2 input)
    {
        movement = input;
    }

    public void FixedTick()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
}