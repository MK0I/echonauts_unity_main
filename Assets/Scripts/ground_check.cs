using UnityEngine;

public class ground_check : MonoBehaviour
{
    public enum shapeType // Database of Shapes
    {
        Capsule,
        Box
    }

    // Inspector Settings and Fine Tuning

    [Header("Shape Type Settings")]
    public shapeType shape = shapeType.Capsule;

    public Vector2 size = new Vector2(0.5f, 0.2f);
    public float radius = 0.25f;

    [Header("Detection Setting")]
    public LayerMask groundLayer;
    public Vector2 offset = new Vector2(0f, -0.5f);

    // Ground Check Proper; Encapsulated for Reusability
    public bool isGrounded { get; private set; }

    void Update()
    {
        Vector2 worldPos = (Vector2)transform.position + offset;

        switch (shape) // Checks for shapes
        {
            case shapeType.Capsule:
                isGrounded = Physics2D.OverlapCapsule(
                   worldPos,                            // Position of the check
                   size,                                // Size
                   CapsuleDirection2D.Vertical,         // Capsule Direction
                   0f,                                  // Rotation
                   groundLayer                          // Tag
                );

                break;

            case shapeType.Box:
                isGrounded = Physics2D.OverlapBox(
                    worldPos,
                    size,
                    0f,
                    groundLayer
                );

                break;
        }
    }

    void OnDrawGizmosSelected() // Visualizer in Editor
    {
        Gizmos.color = Color.green;
        Vector2 worldPos = (Vector2)transform.position + offset;

        Gizmos.DrawWireCube(worldPos, size);
  
    }

}
