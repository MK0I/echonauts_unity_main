using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] // RB2D checker


public class player_controls : MonoBehaviour
{
    private Rigidbody2D _playerAvatar; // RB2D

    private Vector2 moveInput; // Movement

    private Animator anim; // Animator

    [SerializeField] private float moveSpeed = 10f;

    private void Awake()
    {
        _playerAvatar = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>(); // Grabs Animator

    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
        Debug.Log(moveInput); // Input Check

    }

    private void Update() // Asset Flip
    {
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
            
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
