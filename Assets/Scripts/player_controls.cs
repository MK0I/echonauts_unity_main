using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // RB2D checker


public class player_controls : MonoBehaviour
{
    private Rigidbody2D _playerAvatar; // RB2D
    private Vector2 moveInput; // Movement
    private Animator anim; // Animator

    [SerializeField] private float moveSpeed = 10f;
    
    [Header("Limb Limit Controller")]
    [SerializeField] private Transform limbTarget;
    [SerializeField] private float flipThreshold = 100f;
    
    private bool facingRight = true;
    private bool isAiming;

    private void Awake()
    {
        _playerAvatar = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>(); // Grabs Animator

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        //Debug.Log(moveInput); // Input Check

    }

    public void OnAim(InputAction.CallbackContext context)
    {
        if (context.performed)
            isAiming = true;
        else if (context.canceled)
            isAiming = false;
    }

    private void Update()
    {
        if (isAiming)
        {
            // Limb Limit Flipper
            float angle = limbTarget.localEulerAngles.z;
            if (angle > 180) angle -= 360;

            if (facingRight && angle > flipThreshold)
            {
                Flip();
            }
            else if (!facingRight && angle < -flipThreshold)
            {
                Flip();
            }
                
        }
        else
        {
            // Movement Based Flipper
            if (moveInput.x > 0 && !facingRight)
            {
                Flip();
            } 
            else if (moveInput.x < 0 && facingRight)
            {
                Flip();
            }
                
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        // Movement Calculations
        _playerAvatar.linearVelocity = new Vector2(moveInput.x * moveSpeed, _playerAvatar.linearVelocity.y);
        
        // Animation Reference
        float speed = _playerAvatar.linearVelocity.magnitude;
        anim.SetFloat("Speed", speed);

    }

}
