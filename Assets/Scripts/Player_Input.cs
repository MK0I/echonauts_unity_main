using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Player_Input : MonoBehaviour
{
    public Input_State State;

    private Player_Input_Actions controls;

    private Camera mainCamera;

    private void Awake()
    {
        controls = new Player_Input_Actions();

        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Player.Jump.performed += OnJump;

        controls.Player.Fire.performed += OnFireStarted;
        controls.Player.Fire.canceled += OnFireStopped;

        controls.Player.Reload.performed += OnReload;

        controls.Player.Sprint.performed += OnSprintStarted;
        controls.Player.Sprint.canceled += OnSprintStopped;

        controls.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        controls.Player.Jump.performed -= OnJump;

        controls.Player.Fire.performed -= OnFireStarted;
        controls.Player.Fire.canceled -= OnFireStopped;

        controls.Player.Reload.performed -= OnReload;

        controls.Player.Sprint.performed -= OnSprintStarted;
        controls.Player.Sprint.canceled -= OnSprintStopped;

        controls.Player.Interact.performed -= OnInteract;

        controls.Disable();
    }

    private void Update()
    {
        State.Move = controls.Player.Move.ReadValue<Vector2>();

        State.MouseScreen = controls.Player.Look.ReadValue<Vector2>();

        State.MouseWorld = mainCamera.ScreenToWorldPoint(State.MouseScreen);
    }

    private void LateUpdate()
    {
        State.Jumped = false;

        State.Reloaded = false;

        State.Interacted = false;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        State.Jumped = true;
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        State.Fired = true;
    }

    private void OnFireStopped(InputAction.CallbackContext context)
    {
        State.Fired = false;
    }

    private void OnReload(InputAction.CallbackContext context)
    {
        State.Reloaded = true;
    }

    private void OnSprintStarted(InputAction.CallbackContext context)
    {
        State.Sprinted = true;
    }

    private void OnSprintStopped(InputAction.CallbackContext context)
    {
        State.Sprinted = false;
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        State.Interacted = true;
    }
}