using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player_Input : MonoBehaviour, IInit
{
    public Input_State State;

    private Player_Input_Actions controls;

    private Camera mainCamera;

    private void Awake()
    {
        controls = new Player_Input_Actions();

        mainCamera = Camera.main;
    }

    public void Initialize(Context context)
    {
        State = context.InputState;
    }

    private void OnEnable()
    {
        //Debug.Log($"controls == null: {controls == null}");

        if (controls == null) // Lazy Initialization
        {
            controls = new Player_Input_Actions();
            // Debug.Log("Recreated controls.");
        }

        // Debug.Log("About to Enable()");
        controls.Enable();
        // Debug.Log("Enable() finished");

        controls.Player.Jump.performed += OnJump;
        // Debug.Log("Subscribed Jump");

        controls.Player.Fire.performed += OnFirePerformed;
        controls.Player.Fire.canceled += OnFireStopped;

        controls.Player.Aim.performed += OnAimStarted;
        controls.Player.Aim.canceled += OnAimStopped;

        controls.Player.Reload.performed += OnReload;

        controls.Player.Sprint.performed += OnSprintPerformed;
        controls.Player.Sprint.canceled += OnSprintStopped;

        controls.Player.Interact.performed += OnInteract;

        // Debug.Log("Finished OnEnable()");

        // All Debug.Log is to bugfix initialization order error
    }

    private void OnDisable()
    {
        if (controls == null)
        {
            return;
        }

        controls.Player.Jump.performed -= OnJump;

        controls.Player.Fire.performed -= OnFirePerformed;
        controls.Player.Fire.canceled -= OnFireStopped;

        controls.Player.Aim.performed -= OnAimStarted;
        controls.Player.Aim.canceled -= OnAimStopped;

        controls.Player.Reload.performed -= OnReload;

        controls.Player.Sprint.performed -= OnSprintPerformed;
        controls.Player.Sprint.canceled -= OnSprintStopped;

        controls.Player.Interact.performed -= OnInteract;

        controls.Disable();
    }

    private void Update()
    {
        State.Move = controls.Player.Move.ReadValue<Vector2>();

        Vector2 mouseScreen = controls.Player.MousePosition.ReadValue<Vector2>();

        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(mouseScreen);

        State.MouseWorld = new Vector2(mouseWorld.x, mouseWorld.y);
    }

    private void LateUpdate()
    {
        State.Jump = false;

        State.Reload = false;

        State.Interact = false;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        State.Jump = true;
    }

    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        State.Fire = true;
    }

    private void OnFireStopped(InputAction.CallbackContext context)
    {
        State.Fire = false;
    }

    private void OnAimStarted(InputAction.CallbackContext context)
    {
        State.AimHeld = true;
    }

    private void OnAimStopped(InputAction.CallbackContext context)
    {
        State.AimHeld = false;
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        State.Reload = true;
    }

    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        State.Sprint = true;
    }

    private void OnSprintStopped(InputAction.CallbackContext context)
    {
        State.Sprint = false;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        State.Interact = true;
    }
}